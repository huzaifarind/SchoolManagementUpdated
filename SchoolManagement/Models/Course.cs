using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Course
    {
        [Display(Name = "Ref No")]
        public int CourseId { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Course Name Is Required")]
        public string CourseName { get; set; }
        
        [Display(Name = "Teacher")]
        [Required(ErrorMessage = "Teacher Is Required")]
        public int TeacherId { get; set; }

        [Display(Name = "Student")]
        [Required(ErrorMessage = "Student Is Required")]
        public int StudentId { get; set; }


    }
}