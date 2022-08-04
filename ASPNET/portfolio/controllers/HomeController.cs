using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  [HttpGet("/")]
  public string Index()
  {
    return "This is my index";
  }

  [HttpGet("/projects")]
  public string Projects()
  {
    return "This is my projects";
  }

  [HttpGet("/contact")]
  public string Contact()
  {
    return "This is my contact";
  }
}