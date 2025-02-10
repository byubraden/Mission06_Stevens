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
    
    [HttpGet]
    public IActionResult AddMovies()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddMovies(movie response)
    {
        _context.movies.Add(response);
        _context.SaveChanges();
        return View("AddMovieConfirmation", response);
    }
    
}