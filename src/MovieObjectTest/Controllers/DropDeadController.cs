using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie8 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DropDeadAnswer()
        {
            ViewBag.movieResult = DropDeadClass.GetMovie();
            return View();
        }
        public IActionResult DropDeadAnswer2()
        {
            ViewBag.movieResult = DropDeadClass.GetMovie();
            return View();
        }
        public IActionResult DropDeadAnswer3()
        {
            ViewBag.movieResult = DropDeadClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = DropDeadClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "drop dead gorgeous")
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
