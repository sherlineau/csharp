using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class DishController : Controller
{
  private MyContext _context;

  public DishController(MyContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  public IActionResult Dashboard()
  {
    List<Dish> AllDishes = _context.Dishes.OrderByDescending(d => d.CreatedAt).ToList();

    return View("Dashboard", AllDishes);
  }

  // for displaying "create" form
  [HttpGet("/dishes/new")]
  public IActionResult New()
  {
    return View("New");
  }

  // for "submitting" data from form to db
  [HttpPost("/dishes/create")]
  public IActionResult Create(Dish newDish)
  {
    if (ModelState.IsValid == false)
    {
      return New();
    }

    // add new dish to list of dishes 
    _context.Dishes.Add(newDish);
    // save changes to sql database
    // also generates dishID that we can use to route to specific detail page
    _context.SaveChanges();
    return RedirectToAction("Dashboard");
  }

  // for viewing single dish details
  // get route needs to match asp-route-[dishId] 
  // dishId can be anything but needs to match ^
  [HttpGet("/dishes/{dishId}")]
  public IActionResult ViewDish(int dishId)
  {
    Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);
    if (dish == null)
    {
      return RedirectToAction("Dashboard");
    }
    return View("ViewDish", dish);
  }

  // for deleting rows from database 
  [HttpPost("/dishes/{deletedDishId}")]
  public IActionResult DeleteDish(int deletedDishId)
  {
    Dish? dishToBeDeleted = _context.Dishes.FirstOrDefault(dish => dish.DishId == deletedDishId);

    if (dishToBeDeleted != null)
    {
      _context.Dishes.Remove(dishToBeDeleted);
      _context.SaveChanges();
    }
    return RedirectToAction("Dashboard");
  }

  // for updating 
  [HttpGet("/dishes/{dishId}/edit")]
  public IActionResult EditDish(int dishId)
  {
    Dish? dish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

    if( dish == null)
    {
      return RedirectToAction("Dashboard");
    }
    return View("Edit", dish);
  }

  [HttpPost("/dishes/{dishId}/update")]
  public IActionResult UpdateDish(int dishId, Dish updateDish)
  {
    if (ModelState.IsValid == false)
    {
      return EditDish(dishId);
    }

    Dish? dbDish = _context.Dishes.FirstOrDefault(dish => dish.DishId == dishId);

    if (dbDish == null)
    {
      return RedirectToAction("Dashboard");
    }

    dbDish.Name = updateDish.Name;
    dbDish.Chef = updateDish.Chef;
    dbDish.Calories = updateDish.Calories;
    dbDish.Tastiness = updateDish.Tastiness;
    dbDish.Description = updateDish.Description;
    dbDish.UpdatedAt = DateTime.Now;

    _context.Dishes.Update(dbDish);
    _context.SaveChanges();

    return RedirectToAction("ViewDish", new{ dishId = dbDish.DishId});
  }
}