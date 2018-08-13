using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public IndexModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFiler { get; set; }
        public string CurrentSort { get; set; }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync(string SortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            DateSort = SortOrder == "Date" ? "date_desc" : "Date";
            CurrentFiler = searchString;

            IQueryable<Student> studentIQ = from s in _context.Student
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.LastName.Contains(searchString) || s.FirstMidName.Contains(searchString));
            }

            switch (SortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentIQ = studentIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.LastName);
                    break;
            }

            Student = await studentIQ.AsNoTracking().ToListAsync();
        }
    }
}
