using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  [HttpGet("/")]
  public IActionResult Index()
  {
    return View("Index");
  }

  [HttpGet("/projects")]
  public IActionResult Projects()
  {
    return View("Projects");
  }

  [HttpGet("/contact")]
  public IActionResult Contact()
  {
    return View("Contact");
  }

}