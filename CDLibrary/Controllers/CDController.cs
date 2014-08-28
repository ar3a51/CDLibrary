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

    }
}
