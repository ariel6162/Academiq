using Academiq.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academiq.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
    }

}
