using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ValidationPractice.Models;

namespace ValidationPractice.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

}
