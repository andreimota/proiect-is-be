using ProiectIS_BE.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Interfaces
{
    public interface ICourseService
    {
        IEnumerable<Course> GetCourses();

        Course GetCourse(int courseId);
    }
}
