using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContosoUniversity.DataAccess.Entities;
using ContosoUniversity.BusinessLogic.Models;
using ContosoUniversity.BusinessLogic;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentModel StudentModel { get; set; }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyStudent = new Student();                  // oorspronkelijke emptyStudent - behouden om de koppeling te maken naar emptyStudentModel

            var emptyStudentModel = new StudentModel();

            // aangepast
            if (await TryUpdateModelAsync<StudentModel>(
                emptyStudentModel,
                "studentModel",  // Prefix for form value.
                s => s.FirstMidNameModel, s => s.LastNameModel, s => s.EnrollmentDateModel))
            {
                // einde aangepast

                // nieuw
                emptyStudent.FirstMidName = emptyStudentModel.FirstMidNameModel;
                emptyStudent.LastName = emptyStudentModel.LastNameModel;
                emptyStudent.EnrollmentDate = emptyStudentModel.EnrollmentDateModel;
                // einde nieuw

                //// origineel
                //if (await TryUpdateModelAsync<Student>(
                //        emptyStudent,
                //        "student",  // Prefix for form value.
                //        s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
                //{
                //    // einde origineel
                _context.Student.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return null;
        }
    }
}