using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  [HttpGet("/")]
  public IActionResult Index()
  {
    return View("Index");
  }
  
  [HttpGet("/razor")]
  public IActionResult RazorFun()
  {
    return View("RazorFun");
  }

  [HttpGet("names")]
  public IActionResult Names()
  {
    string[] names = new string[]
    {
      "Sally",
      "Alex",
      "Joey",
      "Moose"
    };
    return View(names);
  }
}