using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Fee
    {
        [Display(Name = "Class")]
        public int FeeId { get; set; }
        [Display(Name = "Total Fee")]
        [Required(ErrorMessage = "Total Fee Is Required")]
        public Decimal TotalFee { get; set; }
        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "TStudent Name Is Required")]
        public int StudentId { get; set; }
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
    }
}