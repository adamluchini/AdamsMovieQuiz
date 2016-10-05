using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie10 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JawsAnswer()
        {
            ViewBag.movieResult = JawsClass.GetMovie();
            return View();
        }
        public IActionResult JawsAnswer2()
        {
            ViewBag.movieResult = JawsClass.GetMovie();
            return View();
        }
        public IActionResult JawsAnswer3()
        {
            ViewBag.movieResult = JawsClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = JawsClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "jaws")
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
