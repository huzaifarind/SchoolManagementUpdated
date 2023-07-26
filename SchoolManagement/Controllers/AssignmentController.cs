using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Assignment()
        {
            // Create an instance of AssignmentDbHandle
            AssignmentDbHandle dbHandle = new AssignmentDbHandle();

            // Get the list of assignments from the database
            List<Assignment> assignments = dbHandle.GetAssigment();

            // Pass the list of assignments to the view
            return View(assignments);
        }
    }
}
