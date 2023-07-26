using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentDetailsController : Controller
    {
        // GET: StudentDetails
        public ActionResult StudentDetails()
        {
         
            StudentsDbHandle dbHandle = new StudentsDbHandle();

            List<Students> students = dbHandle.GetStudent();

            return View(students);
        }
    }
}