// routes i want to create
//  /
//  /numbers
//  /users
//  /user

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  [HttpGet("/")]
  public IActionResult Index()
  {
    string[] message = new string[] 
    {
      "Hello from the home controller message model",
      "heres another message",
      "and another"
      };
    return View(message);
  }

  [HttpGet("/numbers")]
  public IActionResult Numbers()
  {
    int[] numbers = new int[]
    {
      1,2,3,4,5,6,7,8,9,10
    };
    return View(numbers);
  }

}