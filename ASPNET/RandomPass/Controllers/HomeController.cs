using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace RandomPass.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        // logic for "counting" number of passcodes generated
        int? generate = HttpContext.Session.GetInt32("generate");
        if (generate == null)
        {
            generate = 0;
        } 
        generate += 1;
        HttpContext.Session.SetInt32("generate", (int)generate);

        // generaing the random passcode
        string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string passcode = "";
        Random random = new Random();
        // change 14 to however long you want the passcode to be
        for( int i = 0; i < 14; i++)
        {
            int idx = random.Next(chars.Length);
            passcode += chars[idx];
        }
        // temp data used to "temporarily hold our passcode for one redirect"
        TempData["passcode"] = passcode;
        TempData["generate"] = HttpContext.Session.GetInt32("generate");

        return View();
    }

    // clear session / reset attempts
    [HttpGet("/clear")]
    public IActionResult Clear()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    
}
