using MVCtake2.Data;
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
        private GameRepo _gameRepo = null;

        public HomePageController()
        {
            _gameRepo = new GameRepo();
        }

        public ActionResult Index()
        {
            var games = _gameRepo.GetGames();

            return View(games);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var game = _gameRepo.GetGame((int)id);
            return View(game);
        }
    }
}