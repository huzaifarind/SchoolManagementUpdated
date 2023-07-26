using SchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement.Controllers
{
    public class GuardiansController : Controller
    {
        // GET: Guardians
        public ActionResult Guardians()
        {

            GuardiansDbHandle dbHandle = new GuardiansDbHandle();

            List<Guardians> guardians = dbHandle.GetGuardians();

            return View(guardians);
        }
    }
}