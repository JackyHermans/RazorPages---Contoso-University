using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.DataAccess.Entities;

namespace ContosoUniversity.DataAccess.Models.SchoolViewModels
{
    class EnrollmentIndexData
    {
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
