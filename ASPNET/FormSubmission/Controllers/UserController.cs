using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FormSubmission.Controllers;

public class UserController : Controller
{
  [HttpGet("/")]
  public IActionResult Index()
  {
    return View("Index");
  }

  [HttpPost("create")]
  public IActionResult Create(User user)
  {
    if (ModelState.IsValid)
    {
      HttpContext.Session.SetString("username", user.Email);
      return RedirectToAction("Success");
    }
    return Index();
  }

  [HttpGet("success")]
  public IActionResult Success()
  {
    return View("Success");
  }
}