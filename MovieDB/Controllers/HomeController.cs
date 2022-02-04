using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieDB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDB.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext movieContext { get; set; }

        public HomeController(MoviesContext someName)
        {
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieEntry()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieEntry(MovieResponse ar)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(ar);
                movieContext.SaveChanges();
                return View("Index");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View();
            }
            
        }

        public IActionResult ListMovies ()
        {
            var movies = movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Year)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View("MovieEntry", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieResponse ar)
        {
            movieContext.Update(ar);
            movieContext.SaveChanges();
            return RedirectToAction("ListMovies");
        }

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var movie = movieContext.Responses.Single(x => x.ApplicationId == applicationid);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieResponse mr)
        {
            movieContext.Responses.Remove(mr);
            movieContext.SaveChanges();
            return RedirectToAction("ListMovies");
        }

    }
}
