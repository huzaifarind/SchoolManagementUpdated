using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Guardians
    {
        [Display(Name = "Ref No ")]      
        public int GuardianId { get; set; }

        [Display(Name = "Guardian Name ")]
        [Required(ErrorMessage = "Guardian Name is Required")]
        public string GuardianName { get; set; }

        [Display(Name = "Guardian Mobile Number ")]
        [Required(ErrorMessage = "Guardian Mobile Number is Required")]
        public string GuardianMobNo { get; set; }

        [Display(Name = "Guardian Email ")]
        [Required(ErrorMessage = "Guardian Email is Required")]
        public string GuardianEmail { get; set; }
    }
}