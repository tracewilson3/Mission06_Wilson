using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    
    private FilmEnterContext _context;
    
    public HomeController(FilmEnterContext temp) // constructor
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult GetToKnow()
    {
        return View();
    }
    [HttpGet]
    public IActionResult FilmEnter()
    {
        ViewBag.Categories = _context.Categories
            .OrderBy(x=>x.CategoryName)
            .ToList();
        
        return View("FilmEnter");
    }

    [HttpPost]
    public IActionResult FilmEnter(Film response)
    {
        
        if (!ModelState.IsValid)
        {
            ViewBag.Categories = _context.Categories; // Repopulate dropdown
            _context.Movies.Add(response); // add the record to the database
            _context.SaveChanges(); // commits changes to database
            return View("Confirmation", response);
        }
        else
        {
            return View(response);
        }
        

        
       
    }
    public IActionResult MovieList()
    {
        //linq
        
        var films= _context.Movies
            .Include(x => x.Category)
            .OrderBy(x => x.Title).ToList();
        
        return View(films);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories
            .OrderBy(x=>x.CategoryName)
            .ToList();
        
        return View("FilmEnter", recordToEdit);
    }

    [HttpPost]
    public IActionResult Edit(Film updatedInfo)
    {
        
        
        _context.Update(updatedInfo);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        return View("DeleteView", recordToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Film movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
}
