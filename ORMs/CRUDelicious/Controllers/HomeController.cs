using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  private MyContext _context;

  public HomeController(MyContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    List<Dish> AllDishes = _context.Dishes.ToList();
    return View();
  }

}
