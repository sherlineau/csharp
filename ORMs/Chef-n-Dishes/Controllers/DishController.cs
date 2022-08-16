using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DishController : Controller
{
  private MyContext _db;

  public DishController(MyContext context)
  {
    _db = context;
  }

  [HttpGet("/dishes")]
  public IActionResult Dashboard()
  {
    // gets a one-to-many joined table from database -> table is joined on chef id and grabs the corresponding Chef object with Include
    List<Dish> AllDishes = _db.Dishes.Include(d => d.DishChef).ToList();
    return View("Dashboard", AllDishes);
  }

  // for displaying form to add new dishs to database
  [HttpGet("/dishes/new")]
  public IActionResult DisplayForm()
  {
    // compiles a list of chefs from database to be used for dropdown select
    List<Chef> allchefs = _db.Chefs.ToList();
    ViewBag.allchefs = allchefs;
    return View("DisplayForm");
  }

  // post method for form
  [HttpPost("/dishes/create")]
  public IActionResult Create(Dish newDish)
  {
    if (newDish.ChefId == null) 
    {
      ModelState.AddModelError("ChefId", "error message");
    }
    if (ModelState.IsValid == false)
    {
      return DisplayForm();
    }
    // add dish to database set
    _db.Dishes.Add(newDish);
    // save changes to mysql
    _db.SaveChanges();
    // redirect to dashboard method
    return RedirectToAction("Dashboard");
  }
}