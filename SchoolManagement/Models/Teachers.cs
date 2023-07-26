using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Teachers
    {
        [Display(Name = "Ref No ")]
         public int TeacherId { get; set; }

        [Display(Name = "Name ")]
        [Required(ErrorMessage = "Name is Required")]
        public string TeacherName { get; set; }

        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile Number is Required")]
        public string TeacherMobileNo { get; set; }


        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string TeacherAddress { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string TeacherEmail { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get; set; }

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Qualification is Required")]
        public string Qualification { get; set; }
    }
}