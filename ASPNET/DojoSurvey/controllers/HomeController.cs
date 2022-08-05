using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller 
{
  [HttpGet("")]
  public IActionResult Index()
  {
    return View("index");
  }

  [HttpPost("result")]
  public IActionResult Result(string name, string location, string language, string comment)
  {
    ViewBag.name = name;
    ViewBag.location = location;
    ViewBag.language = language;
    ViewBag.comment = comment;

    return View("result");
  }

  // redirect to index if trying to access result through get
  [HttpGet("result")]
  public RedirectToActionResult Redirect()
  {
    return RedirectToAction("index");
  }
}