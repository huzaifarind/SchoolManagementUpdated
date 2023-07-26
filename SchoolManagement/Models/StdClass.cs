using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class StdClass
    {
        [Display(Name = "Ref No")]
        public int ClassId { get; set; }
        [Display(Name = "Class")]
        [Required(ErrorMessage = "Class Is Required")]
        public string Class { get; set;}
        [Display(Name = "Student")]
        [Required(ErrorMessage = "Student Is Required")]
        public string StudentId { get; set; }
        [Display(Name = "Section")]
        [Required(ErrorMessage = "Section Is Required")]
        public string SectionId { get; set; }
    }
}