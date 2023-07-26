using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Students
    {
        [Display(Name = " Ref No")]
         public int StudentId { get; set; }

        [Display(Name = "Enrollment Number ")]
        [Required(ErrorMessage = "Name is Required")]
        public string EnrollmentNo { get; set; }

        [Display(Name ="Name ")]
        [Required(ErrorMessage = "Name is Required")]
        public string StudentName { get; set; }

        [Display(Name = "Mobile Number ")]
        [Required(ErrorMessage = "Mobile Number is Required")]
        public string StudentMobNo { get; set; }

        [Display(Name = "Address ")]
        [Required(ErrorMessage = " Address is Required")]
        public string StudentAddress { get; set; }

        [Display(Name = "Email ")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]
        [Required(ErrorMessage = " Email is Required")]
        public string StudentEmail { get; set; }

        [Display(Name = "Gender ")]
        [Required(ErrorMessage = " Gender is Required")]
        public string Gender { get; set; }


        [Display(Name = "Guardian")]
        [Required(ErrorMessage = " Guardian is Required")]
        public int GuardianId { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
         public DateTime DOB { get; set; }
    }
}