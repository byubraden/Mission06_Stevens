using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    // post route for adding movies to the database
    [HttpPost]
    public IActionResult AddMovies(movie response)
    {
        _context.movies.Add(response);
        _context.SaveChanges();
        return View("AddMovieConfirmation", response);
    }
    
}