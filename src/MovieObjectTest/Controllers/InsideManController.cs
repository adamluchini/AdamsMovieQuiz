using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie3 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult InsideManAnswer()
        {
            ViewBag.movieResult = InsideManClass.GetMovie();
            return View();
        }
        public IActionResult InsideManAnswer2()
        {
            ViewBag.movieResult = InsideManClass.GetMovie();
            return View();
        }
        public IActionResult InsideManAnswer3()
        {
            ViewBag.movieResult = InsideManClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = InsideManClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "inside man")
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
