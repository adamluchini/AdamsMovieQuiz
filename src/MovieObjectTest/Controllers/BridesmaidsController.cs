using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie4 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BridesmaidsAnswer()
        {
            ViewBag.movieResult = BridesmaidsClass.GetMovie();
            return View();
        }
        public IActionResult BridesmaidsAnswer2()
        {
            ViewBag.movieResult = BridesmaidsClass.GetMovie();
            return View();
        }
        public IActionResult BridesmaidsAnswer3()
        {
            ViewBag.movieResult = BridesmaidsClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = BridesmaidsClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "bridesmaids")
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
