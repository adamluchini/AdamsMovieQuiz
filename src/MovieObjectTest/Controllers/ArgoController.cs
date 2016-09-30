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
            ViewBag.movieResult = ArgoClass.GetMovie();
            return View();
        }
    }
}
