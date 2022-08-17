using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ChefController : Controller
{
  private MyContext _context;

  public ChefController(MyContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  [HttpGet("/chefs")]
  public IActionResult Dashboard()
  {
    List<Chef> AllChefs = _context.Chefs.ToList();
    foreach(Chef a in AllChefs){
      a.CreatedDishes = _context.Dishes
          .Include(d => d.DishChef)
          .Where(d => d.ChefId == a.ChefId)
          .ToList();
    }
    return View("Dashboard", AllChefs);
  }

  [HttpGet("/chefs/new")]
  public IActionResult DisplayForm()
  {
    return View("DisplayForm");
  }

  [HttpPost("/chefs/create")]
  public IActionResult Create(Chef newChef)
  {
    if(newChef == null)
    {
      // add model state error
    }
    if (ModelState.IsValid == false)
    {
      return DisplayForm();
    }
    _context.Chefs.Add(newChef);
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
  }
}