using MVCtake2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCtake2.Data
{
    public class GameRepo
    {
        private static Game[] _games = new Game[]
        {
            new Game()
            {
                Id = 1,
                Title = "Super Smash Bros",
                Genre = "Fighting",
                Description = "<p>A high octane brawler!</p>",
                Developers = new string[]
                {"Nintendo", "The Kirby Guy"},
                Favorite = false
            },
            new Game()
            {
                Id = 2,
                Title = "Super Smash Bros Melee",
                Genre = "Fighting",
                Description = "<p>The stupifying experience continues!</p>",
                Developers = new string[]
                {"Nintendo", "The Kirby Guy"},
                Favorite = true
            }
    };

        public Game GetGame(int id)
        {
            Game gameToReturn = null;
            foreach (var game in _games)
            {
                if (game.Id == id)
                {
                    gameToReturn = game;
                    break;
                }
            }
            return gameToReturn;
        }
    }
}