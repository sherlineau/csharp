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
}