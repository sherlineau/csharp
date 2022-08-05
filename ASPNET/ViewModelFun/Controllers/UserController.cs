using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

public class UserController : Controller
{
  [HttpGet("/users")]
  public IActionResult Users()
  {
    User Alex = new User ("Alex", "Miller");
    User Martha = new User ("Martha", "Miller");
    User Linda = new User ("Linda", "Nguyen" );
    User Lily = new User ("Lily", "Au" );
    List<User> users = new List<User>()
    {
      Alex, Martha, Linda, Lily
    };
    ViewBag.User = users;
    return View("Users", users);
  }

  [HttpGet("/user")]
  public IActionResult User()
  {
    User Sherline = new User("Sherline","Au");
    return View(Sherline);
  }
}