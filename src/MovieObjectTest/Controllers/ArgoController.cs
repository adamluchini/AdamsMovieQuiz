using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ArgoAnswer()
        {
            ViewBag.movieResult = ArgoClass.GetMovie();
            return View();
        }
        public IActionResult ArgoAnswer2()
        {
            ViewBag.movieResult = ArgoClass.GetMovie();
            return View();
        }
        public IActionResult ArgoAnswer3()
        {
            ViewBag.movieResult = ArgoClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = ArgoClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "argo")
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
