using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
  [HttpGet("")]
  public IActionResult Index()
  {
    bool status = false;
    // session id -> if session id = null -> generate and set default values for pet
    int? id = HttpContext.Session.GetInt32("id");
    if (id == null)
    {
      HttpContext.Session.SetInt32("id", 1);
      HttpContext.Session.SetInt32("happiness", 20);
      HttpContext.Session.SetInt32("fullness", 20);
      HttpContext.Session.SetInt32("energy", 50);
      HttpContext.Session.SetInt32("meals", 3);
      HttpContext.Session.SetString("msg", "");
    }

    TempData["Happiness"] = HttpContext.Session.GetInt32("happiness");
    TempData["Fullness"] = HttpContext.Session.GetInt32("fullness");
    TempData["Energy"] = HttpContext.Session.GetInt32("energy");
    TempData["Meals"] = HttpContext.Session.GetInt32("meals");
    TempData["Message"] = HttpContext.Session.GetString("msg");

    int happy = (int)HttpContext.Session.GetInt32("happiness");
    int full = (int)HttpContext.Session.GetInt32("fullness");
    int energy = (int)HttpContext.Session.GetInt32("energy");
    if (happy <= 0 || full <= 0)
    {
      HttpContext.Session.SetString("msg", "Game Over your Dojodachi Died!");
      TempData["Message"] = HttpContext.Session.GetString("msg");
      status = true;
    }
    else if (happy >= 100 && full >= 100 && energy >= 100)
    {
      HttpContext.Session.SetString("msg", "You WINN!! All of your Dojodachi's needs have been satisfied");
      TempData["Message"] = HttpContext.Session.GetString("msg");
      status = true;
    }

    return View("Index", status);
  }

  // feed / cost 1 meal -> gain 5-10 fullness
  [HttpPost("feed")]
  public IActionResult Feed()
  {
    int meals = (int)HttpContext.Session.GetInt32("meals");

    // if no meals available -> cant feed
    if (meals <= 0)
    {
      HttpContext.Session.SetString("msg", "Your dojodachi can't eat without a meal!");
    }
    else
    //25% pet does not like -> meal still decreases -> no gain in fullness
    {
      Random random = new Random();
      int chance = random.Next(0, 101);
      meals -= 1;
      if (chance < 25)
      {
        HttpContext.Session.SetInt32("meals", meals);
        HttpContext.Session.SetString("msg", "Dojodachi did not like the food");
      }
      else
      {
        int gains = random.Next(5, 11);
        int full = (int)HttpContext.Session.GetInt32("fullness");
        full += gains;
        HttpContext.Session.SetInt32("meals", meals);
        HttpContext.Session.SetInt32("fullness", full);
        HttpContext.Session.SetString("msg", $"YUM! Gained {gains} fullness! -1 meal");
      }
    }
    return RedirectToAction("Index");
  }

  // work / cost 5 energy -> gain 1-3 meals
  [HttpPost("work")]
  public IActionResult Work()
  {
    int energy = (int)HttpContext.Session.GetInt32("energy");
    if (energy < 5)
    {
      HttpContext.Session.SetString("msg", "Can't work without any energy!");
    }
    else
    {
      Random random = new Random();
      int gains = random.Next(1, 4);
      int meals = (int)HttpContext.Session.GetInt32("meals");
      energy -= 5;
      meals += gains;
      HttpContext.Session.SetInt32("energy", energy);
      HttpContext.Session.SetInt32("meals", meals);
      HttpContext.Session.SetString("msg", $"Worked(-5 energy)! Gained {gains} meals");
    }
    return RedirectToAction("Index");

  }

  // play / cost 5 energy -> gain 5-10 happiness
  [HttpPost("play")]
  public IActionResult Play()
  {
    int energy = (int)HttpContext.Session.GetInt32("energy");
    if (energy < 5)
    {
      energy -= 5;
      HttpContext.Session.SetString("msg", "Can't work without any energy!");
    }
    else
    {
      // 25% pet does not like -> energy still decreases -> no gain in hapiness
      energy -= 5;
      Random random = new Random();
      int chance = random.Next(0, 101);

      if (chance < 25)
      {

        HttpContext.Session.SetString("msg", "Dojodachi did not like playing");
      }
      else
      {
        int gains = random.Next(5, 11);
        int happy = (int)HttpContext.Session.GetInt32("happiness");
        happy += gains;
        HttpContext.Session.SetInt32("energy", energy);
        HttpContext.Session.SetInt32("happiness", happy);
        HttpContext.Session.SetString("msg", $"Dojodachi enjoyed playing(-5 energy)! Gained {gains} happiness!");
      }
    }
    return RedirectToAction("Index");
  }



  // sleep / cost 5 hapiness and 5 fullness -> increase energy by 15
  [HttpPost("sleep")]
  public IActionResult Sleep()
  {
    int energy = (int)HttpContext.Session.GetInt32("energy");
    int happy = (int)HttpContext.Session.GetInt32("happiness");
    int full = (int)HttpContext.Session.GetInt32("fullness");

    if (full < 5 || happy < 5)
    {
      HttpContext.Session.SetString("msg", "Not enough fullness or happiness to sleep");
    }
    else
    {
      energy += 15;
      happy -= 5;
      full -= 5;
      HttpContext.Session.SetInt32("energy", energy);
      HttpContext.Session.SetInt32("happiness", happy);
      HttpContext.Session.SetInt32("fullness", full);
      HttpContext.Session.SetString("msg", $"Dojodachi slept! Gained 15 energy, lost 5 happiness and fullness");
    }

    return RedirectToAction("Index");
  }

  [HttpPost("reset")]
  public IActionResult Reset()
  {
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
  }
}
