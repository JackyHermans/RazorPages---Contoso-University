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
    public class EnrollmentNamePageModelModel : PageModel
    {
        public SelectList StudentFullNameSL { get; set; }

        public void PopulateStudentsDropDownList(SchoolContext _context, object selectedStudent = null)
        {
            var StudentsQuery = from s in _context.Students
                                orderby s.FullName  // sort by full name
                                select s;

            StudentFullNameSL = new SelectList(StudentsQuery.AsNoTracking(),
                "StudentID", "FullName", selectedStudent);
        }
    }
}