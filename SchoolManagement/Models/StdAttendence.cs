using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StdAttendence
    {
        [Display(Name = "Ref No")]
         public int AttendenceId { get; set; }
        [Display(Name = "Attendence")]
        [Required(ErrorMessage = "Select Present Or Absent")]
        public string Attendence { get; set; }
        [Display(Name = "Class")]
        [Required(ErrorMessage = "Class Is Required")]
         public int ClassId { get; set; }

        [Display(Name = "Student")]
        [Required(ErrorMessage = "Student Is Required")]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime Date { get; set; }
    }
}