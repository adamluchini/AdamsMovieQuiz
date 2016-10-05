using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie6 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WeddingSingerAnswer()
        {
            ViewBag.movieResult = WeddingSingerClass.GetMovie();
            return View();
        }
        public IActionResult WeddingSingerAnswer2()
        {
            ViewBag.movieResult = WeddingSingerClass.GetMovie();
            return View();
        }
        public IActionResult WeddingSingerAnswer3()
        {
            ViewBag.movieResult = WeddingSingerClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = WeddingSingerClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "wedding singer")
            {

                return View("Correct");
            }
            else if (userguess.ToLower() == "the wedding singer")
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
