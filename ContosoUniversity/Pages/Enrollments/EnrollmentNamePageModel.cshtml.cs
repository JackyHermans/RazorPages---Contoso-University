using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.DataAccess;
using ContosoUniversity.DataAccess.Entities;
using ContosoUniversity.DataAccess.Models.SchoolViewModels;

namespace ContosoUniversity.Pages.Enrollments
{
    public class EnrollmentNamePageModel : PageModel
    {
        public SelectList StudentFullNameSL { get; set; }

        public void PopulateStudentsDropDownList(SchoolContext _context, object selectedStudent = null)
        {
            var StudentsQuery = from s in _context.Student
                                orderby (s.FullName) // sort by full name
                                select s;

            StudentFullNameSL = new SelectList(StudentsQuery.AsNoTracking(),
                "StudentFullName", "FullName", selectedStudent);
        }

        public SelectList CoursesTitleSL { get; set; }

        public void PopulateCoursesDropDownList(SchoolContext _context, object selectedCourse = null)
        {
            var CourseQuery = from c in _context.Courses
                              orderby (c.Title) // sort by title
                              select c;

            CoursesTitleSL = new SelectList(CourseQuery.AsNoTracking(),
                "CourseTitle", "Title", selectedCourse);
        }
    }
}