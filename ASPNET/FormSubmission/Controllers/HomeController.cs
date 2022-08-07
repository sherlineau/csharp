using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace FormSubmission.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}
