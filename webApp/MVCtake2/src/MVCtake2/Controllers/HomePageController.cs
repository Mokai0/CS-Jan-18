using MVCtake2.Models;
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
            var game = new Game()
            {
                Title = "Super Smash Bros",
                Genre = "Fighting",
                Description = "<p>A high octane brawler!</p>",
                Developers = new string[]
                {"Nintendo", "The Kirby Guy"},
                Favorite = true
            };

            return View(game);
        }
    }
}