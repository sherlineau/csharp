using Microsoft.AspNetCore.Mvc;

// only has access to files in views/Home folder
// views/Shared folder can be accessed by all controllers
// checks for files in views/Home folder first -> shared folder second
public class HomeController : Controller
{
  // my routes ("/")
  [HttpGet("/")]
  public ViewResult Index()
  {
    // return View() works if the cshtml file is name exactly as the function 
    return View("Index");
  }

  [HttpGet("/videos")]
  public IActionResult Videos()
  {
    {
      List<string> youtubeVideoIds = new List<string>
        {
          "yT3_vLQ3jbM", "fbqHK8i-HdA", "CUe2ymg1RHs", "-rEIOkGCbo8", "KYgZPphIKQY", "GPdGeLAprdg", "eg9_ymCEAF8", "nHkUMkUFuBc", "QTwcvNdMFMI", "j6YK-qgt_TI", "Wvjsgb2nB4o", "GcKkiRl9_qE", "6avJHaC3C2U", "_mZBa3sqTrI"
        };

      ViewBag.YoutubeVideoIds = youtubeVideoIds;
      ViewBag.Title = $"Here are {ViewBag.YoutubeVideoIds.Count} of my favorite videos";

      return View("Videos");
    }
  }
}