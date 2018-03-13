using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCtake2.Controllers
{
    public class HomePageController : Controller
    {
        public ActionResult Detail()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                return new RedirectResult("/");
            }

            return new ContentResult()
            {
                Content = "It's the Home Page!"
            };
        }
    }
}