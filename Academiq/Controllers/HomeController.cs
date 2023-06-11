using Academiq.Interfaces;
using Academiq.Models;
using Academiq.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Academiq.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService _courseService;

        public HomeController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public ActionResult Dashboard()
        {
            var registration = (Registration)Session["CurrentRegistration"] ?? new Registration
            {
                Course = new List<Course>(),
                Status = null
            };

            Session["CurrentRegistration"] = registration;

            return View(new DashboardViewModel
            {
                AllAvailableCourses = _courseService.GetAvailableCourses(),
                StudentRegistration = registration
            });
        }

        [HttpPost]
        public PartialViewResult CreateRegistration()
        {
            var registration = new Registration
            {
                Course = new List<Course>(),
                Status = (int?)RegistrationStatus.InProgress
            };

            Session["CurrentRegistration"] = registration;

            return PartialView("_StudentRegistrationData", registration);
        }

        [HttpPost]
        public ActionResult AddCourseToRegistration(int courseId)
        {
            var currentRegistration = Session["CurrentRegistration"] as Registration;

            if (currentRegistration == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Registration not found in session");
            }

            var courseToBeAdded = _courseService.GetCourseById(courseId);

            // Ensure a Course with the given ID exists; if not, return an error
            if (courseToBeAdded == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Course not found");
            }

            // Check for duplicate and conflicting registrations
            var validationResult = ValidateCourseRegistration(currentRegistration, courseToBeAdded);
            if (!validationResult.IsValid)
            {
                return Json(new { Status = "Error", error = validationResult.ErrorMessage }, JsonRequestBehavior.AllowGet);
            }

            currentRegistration.Course.Add(courseToBeAdded);

            Session["CurrentRegistration"] = currentRegistration;

            return Json(new { Status = "Success" });
        }



        [HttpPost]
        public JsonResult CancelRegistration()
        {
            ((Registration)Session["CurrentRegistration"])?.Cancel();

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public JsonResult ClearAllCourses()
        {
            ((Registration)Session["CurrentRegistration"])?.ClearAllCourses();

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public JsonResult CompleteRegistration()
        {
            ((Registration)Session["CurrentRegistration"])?.CompleteRegistration();

            return Json(new { Status = "Success" });
        }

        [HttpPost]
        public JsonResult Payment()
        {
            ((Registration)Session["CurrentRegistration"])?.Pay();

            return Json(new { Status = "Success" });
        }

        // Helper method to validate the course registration
        private static (bool IsValid, string ErrorMessage) ValidateCourseRegistration(Registration currentRegistration, Course courseToBeAdded)
        {
            foreach (var existingCourse in currentRegistration.Course)
            {
                if (existingCourse.Id == courseToBeAdded.Id)
                {
                    return (false, "This course is already registered");
                }

                if (HasTimeConflict(existingCourse, courseToBeAdded))
                {
                    return (false, "This course conflicts with another course you have registered");
                }
            }

            return (true, string.Empty);
        }

        // Helper method to check if two courses conflict by time
        private static bool HasTimeConflict(Course existingCourse, Course newCourse)
        {
            return existingCourse.DayOfWeek == newCourse.DayOfWeek &&
                   ((newCourse.StartTime >= existingCourse.StartTime && newCourse.StartTime < existingCourse.EndTime) ||
                    (newCourse.EndTime > existingCourse.StartTime && newCourse.EndTime <= existingCourse.EndTime));
        }
    }
}
