using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class Movie5 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LittleMermaidAnswer()
        {
            ViewBag.movieResult = LittleMermaidClass.GetMovie();
            return View();
        }
        public IActionResult LittleMermaidAnswer2()
        {
            ViewBag.movieResult = LittleMermaidClass.GetMovie();
            return View();
        }
        public IActionResult LittleMermaidAnswer3()
        {
            ViewBag.movieResult = LittleMermaidClass.GetMovie();
            return View();
        }
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = LittleMermaidClass.GetMovie();
            if (userguess == null)
            {
                return View("Reveal");
            }
            else if (userguess.ToLower() == "little mermaid")
            {

                return View("Correct");
            }
            else if (userguess.ToLower() == "the little mermaid")
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
