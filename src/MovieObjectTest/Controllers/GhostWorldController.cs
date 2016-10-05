using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie9 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GattacaAnswer()
        {
            ViewBag.movieResult = GattacaClass.GetMovie();
            return View();
        }
        public IActionResult GattacaAnswer2()
        {
            ViewBag.movieResult = GattacaClass.GetMovie();
            return View();
        }
        public IActionResult GattacaAnswer3()
        {
            ViewBag.movieResult = GattacaClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = GattacaClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "gattaca")
            {

                return View("Correct");
            }
            else if (userguess.ToLower() == "gatacca")
            {
                return View("Correct");
            }
            else
            {
                return View("Reveal");
            }
        }
    }
}
