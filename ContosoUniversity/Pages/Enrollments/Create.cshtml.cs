using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.DataAccess.Entities;

namespace ContosoUniversity.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly ContosoUniversity.DataAccess.Entities.SchoolContext _context;

        public CreateModel(ContosoUniversity.DataAccess.Entities.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "CourseID");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}