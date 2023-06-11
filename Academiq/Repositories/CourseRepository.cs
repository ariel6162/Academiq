using Academiq.Interfaces;
using Academiq.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;

namespace Academiq.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AcademiqDBEntities _context;

        public CourseRepository(AcademiqDBEntities context)
        {
            _context = context;
            context.Database.Log = s => Debug.WriteLine(s);

        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Course.Include(c => c.Lecturer).ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Course.Include(c => c.Lecturer).SingleOrDefault(c => c.Id == id);
        }
    }
}
