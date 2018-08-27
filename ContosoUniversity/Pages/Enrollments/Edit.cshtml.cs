using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.DataAccess.Entities;

namespace ContosoUniversity.Pages.Enrollments
{
    public class EditModel : EnrollmentNamePageModel
    {
        private readonly ContosoUniversity.DataAccess.Entities.SchoolContext _context;

        public EditModel(ContosoUniversity.DataAccess.Entities.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
           //ViewData["CourseTitle"] = new SelectList(_context.Courses, "CourseID", "CourseID");
           ViewData["StudentFullName"] = new SelectList(_context.Student, "FullName", "FullName");

            Enrollment = await _context.Enrollment
                .Include(e => e.Course.Title)
                .Include(e => e.Student.FullName)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.EnrollmentID == id);

            if (Enrollment == null)
            {
                return NotFound();
            }
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }

        //    var enrollmentToUpdate = await _context.Enrollment
        //        .Include(e => e.Course.Title)
        //        .Include(e => e.Student.FullName)
        //        .FirstOrDefaultAsync(m => m.EnrollmentID == id);

        //    if (await TryUpdateModelAsync<Student>(
        //        enrollmentToUpdate,
        //        "enrollmentStudent",
        //        e => e.FullName))
        //    {
        //        await _context.SaveChangesAsync();))
        //    }
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Enrollment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentExists(Enrollment.EnrollmentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.EnrollmentID == id);
        }
    }
}
