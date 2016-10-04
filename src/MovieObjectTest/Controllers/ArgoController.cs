using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieObjectTest.Models;

namespace MovieObjectTest.Controllers
{
    public class ArgoController : Controller
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
        public IActionResult Guess(string userguess)
        {
            ViewBag.movieResult = ArgoClass.GetMovie();
            if (userguess == "argo")
            {
                return View("Correct");
            }
            else
            {
                return View();
            }
        }
    }
}
