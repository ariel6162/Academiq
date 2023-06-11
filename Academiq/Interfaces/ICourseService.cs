using Academiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academiq.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAvailableCourses();
        Course GetCourseById(int id);
    }
}
