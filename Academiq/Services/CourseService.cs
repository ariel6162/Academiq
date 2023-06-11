using Academiq.Interfaces;
using Academiq.Models;
using System.Collections.Generic;

namespace Academiq.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Course> GetAvailableCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }
    }
}
