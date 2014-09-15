using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CDLibrary.BL;
using CDLibrary.Common;

namespace CDLibrary.Controllers
{
    public class CDController : HomeController
    {
        //
        // GET: /CD/

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Details(long? id)
        {
            CD cd = CDRepository.FindCDById((long)id, "me");

            return View(cd);

        }

        [HttpPost]
        public ActionResult UpdateCD(CD cdDetails)
        {
            if(ModelState.IsValid)
            {
                CDRepository.updateCD(cdDetails);
            }

            return RedirectToAction("Details", "CD", new { id = cdDetails.CDid });

        }

        [HttpPost]
        public ActionResult addNewCD(CD cdDetails)
        {
            int CDid;
            if (ModelState.IsValid)
            {
                cdDetails.insertBy = "me";
                cdDetails.updateDate = DateTime.Now;
                cdDetails.insertDate = DateTime.Now;

                CDid = CDRepository.AddNewCD(cdDetails);
                return RedirectToAction("Details", "CD", new { id = cdDetails.CDid });
                
            }
            else
                return RedirectToAction("Add", "CD");

            

        }

    }
}
