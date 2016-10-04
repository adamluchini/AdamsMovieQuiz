using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie2 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MementoAnswer()
        {
            ViewBag.movieResult = MementoClass.GetMovie();
            return View();
        }
        public IActionResult MementoAnswer2()
        {
            ViewBag.movieResult = MementoClass.GetMovie();
            return View();
        }
        public IActionResult MementoAnswer3()
        {
            ViewBag.movieResult = MementoClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = MementoClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "memento")
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
