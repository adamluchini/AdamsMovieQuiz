using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie7 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WizardAnswer()
        {
            ViewBag.movieResult = WizardClass.GetMovie();
            return View();
        }
        public IActionResult WizardAnswer2()
        {
            ViewBag.movieResult = WizardClass.GetMovie();
            return View();
        }
        public IActionResult WizardAnswer3()
        {
            ViewBag.movieResult = WizardClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = WizardClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "wizard of oz")
            {

                return View("Correct");
            }
            else if (userguess.ToLower() == "the wizard of oz")
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
