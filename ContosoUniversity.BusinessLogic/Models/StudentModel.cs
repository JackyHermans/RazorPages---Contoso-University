using System;
using System.Collections.Generic;
using System.Text;
using ContosoUniversity.DataAccess.Entities;
using ContosoUniversity.DataAccess;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ContosoUniversity.BusinessLogic.Models
{
    public class StudentModel
    {
        public int IdModel { get; set; }
        public string LastNameModel { get; set; }
        public string FirstMidNameModel { get; set; }
        public DateTime EnrollmentDateModel { get; set; }

        public Student emptyStudentModel = new Student();

        public StudentModel()
        {
            this.IdModel = emptyStudentModel.ID;
            this.LastNameModel = emptyStudentModel.LastName;
            this.FirstMidNameModel = emptyStudentModel.FirstMidName;
            this.EnrollmentDateModel = emptyStudentModel.EnrollmentDate;
        }
    }
}
