using Academiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academiq.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Course> AllAvailableCourses { get; set; }
        public Registration StudentRegistration { get; set; }
    }
}