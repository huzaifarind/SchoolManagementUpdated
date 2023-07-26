using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class StudentAttendenceController : Controller
    {
        // GET: StudentAttendence
        public ActionResult StudentAttendence()
        {
            StdAttendenceDbHandle dbHandle = new StdAttendenceDbHandle();

            List<StdAttendence> attendences = dbHandle.GetAttendence();

            return View(attendences);
        }
    }
}