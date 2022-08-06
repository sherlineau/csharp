using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ValidationPractice.Models;

namespace ValidationPractice.Controllers;

public class UserController : Controller
{
  [HttpGet("/login")]
  public IActionResult NewUser()
  {
    return View("NewUser");
  }

  [HttpGet("/success")]
  public IActionResult Success()
  {
    return View("Success");
  }

  [HttpPost("create")]
  public IActionResult Create(User user)
  {
    if (ModelState.IsValid)
    {
      HttpContext.Session.SetString("username", user.Username);
      return RedirectToAction("Success");
    }
    return NewUser();
  }

  [HttpGet("/logout")]
  public IActionResult Logout()
  {
    HttpContext.Session.Remove("username");
    return RedirectToAction("Index","Home");
  }
}