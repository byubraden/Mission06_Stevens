using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Stevens.Models;

namespace Mission06_Stevens.Controllers;

public class HomeController : Controller
{
    private MovieDatabaseContext _context;

    public HomeController(MovieDatabaseContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    // Get route for adding movies page
    [HttpGet]
    public IActionResult AddMovies()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View();
    }

    // post route for adding movies to the database
    [HttpPost]
    public IActionResult AddMovies(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return View("AddMovieConfirmation", response);
    }

    // load movie database
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(x => x.Category)
            .ToList();
        
        return View(movies);
    }
    
    //load edit values for add movies
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movieToEdit = _context.Movies.Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        return View("AddMovies", movieToEdit);
    }
    
    //update the movie
    [HttpPost]
    public IActionResult EditMovie(Movie updatedInfo)
    {
        _context.Movies.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }

    //Get method for loading the delete movie page
    [HttpGet]
    public IActionResult DeleteMovie(int id)
    {
        var movieToDelete = _context.Movies.Single(x => x.MovieId == id);
        
        return View(movieToDelete);
    }

    // Post for removing the movie from the database
    [HttpPost]
    public IActionResult DeleteMovie(Movie movieToDelete)
    {
        _context.Movies.Remove(movieToDelete);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
    
}