using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoUniversity.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.DAL.Models;
using ContosoUniversity.DAL.Data;

namespace ContosoUniversity.Pages
{
    public class AboutModel : PageModel
    {
        private readonly SchoolContext _context;

        public AboutModel(SchoolContext context)
        {
            _context = context;
        }

        //public IList<EnrollmentDateGroup> Student { get; set; }
        public IList<ContosoUniversity.DAL.Models.SchoolViewModels.EnrollmentDateGroup> Student { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<ContosoUniversity.DAL.Models.SchoolViewModels.EnrollmentDateGroup> data =
                from student in _context.Student
                group student by student.EnrollmentDate into dateGroup
                select new ContosoUniversity.DAL.Models.SchoolViewModels.EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };
            
            Student = await data.AsNoTracking().ToListAsync();
        }
    }
}
