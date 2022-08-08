using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyValid.Models;

namespace DojoSurveyValid.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }


  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }


  [HttpGet("/")]
  public IActionResult Index()
  {
    return View("Index");
  }

  [HttpGet("/success")]
  public IActionResult Success()
  {
    return View("Success");
  }

  [HttpPost("create")]
  [ValidateAntiForgeryToken]
  public IActionResult Create(Survey survey)
  {
    if (ModelState.IsValid)
    {
      HttpContext.Session.SetString("Name", survey.Name);
      return View("Success",survey);
    }
    return Index();
  }


}
