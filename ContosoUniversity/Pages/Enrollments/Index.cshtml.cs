using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.DataAccess.Entities;
using ContosoUniversity.DataAccess.Models.SchoolViewModels;

namespace ContosoUniversity.Pages.Enrollments
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.DataAccess.Entities.SchoolContext _context;

        public IndexModel(ContosoUniversity.DataAccess.Entities.SchoolContext context)
        {
            _context = context;
        }

        public EnrollmentIndexData Enrollment { get;set; }
        public int EnrollmentID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Enrollment = new EnrollmentIndexData();
            Enrollment.Enrollments = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .ToListAsync();
        }
    }
}
