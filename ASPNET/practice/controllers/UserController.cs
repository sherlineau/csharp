using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

public class UserController : Controller
{
  [HttpGet("/details")]
  public IActionResult UserDetail()
  {
    User someUser = new User()
    {
      FirstName = "Alex",
      LastName = "Miller"
    };

    return View(someUser);
  }
}