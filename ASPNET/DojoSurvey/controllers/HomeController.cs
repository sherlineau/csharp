using Microsoft.AspNetCore.Mvc;


public class HomeController : Controller 
{
  [HttpGet("")]
  public IActionResult Index()
  {
    return View("index");
  }

// for form post request
  [HttpPost("result")]
  public IActionResult Result(string name, string location, string language, string comment)
  {
    // ViewBag.name = name;
    // ViewBag.location = location;
    // ViewBag.language = language;
    // ViewBag.comment = comment;
    Survey newSurvey = new Survey(name,location,language,comment);
    return View(newSurvey);
  }

  // redirect to index if trying to access result through get
  [HttpGet("result")]
  public RedirectToActionResult Redirect()
  {
    return RedirectToAction("index");
  }
}