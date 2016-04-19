using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotepadApp.Controllers
{
    public class NotatkiController : Controller
    {
        // GET: Notatki
        public ActionResult AddNew()
        {
            return View("NotatkiPage");
        }
    }
}