using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContosoUniversity.DataAccess.Entities;

namespace ContosoUniversity.DataAccess.Models.SchoolViewModels
{
    public class EnrollmentIndexData
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
