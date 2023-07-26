using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SchoolManagement.Models
{
    public class Assignment
    {
        [Display(Name = "Ref No ")]
        public int AssignmentId { get; set; }
        [Display(Name = "Assignment")]
        [Required(ErrorMessage = "Assignment is Required")]
        public string AssignmentName { get; set; }
        [Display(Name = "Assignment Type")]
        [Required(ErrorMessage = "Assignment Type is Required")]
        public string AssignmentType { get; set; }
        [Display(Name = "Submission Date")]
        [Required(ErrorMessage = "Submission Date is Required")]
        public DateTime SubmissionDate { get; set; }

    }
}