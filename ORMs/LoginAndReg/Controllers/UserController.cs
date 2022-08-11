using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

public class UserController : Controller
{
  private int? uid
  {
    get { return HttpContext.Session.GetInt32("UUID"); }
  }

  private bool loggedIn
  {
    get { return uid != null; }
  }

  private MyContext _context;

  public UserController(MyContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  public IActionResult Index()
  {
    // // redirect to another page if user is logged in
    if (loggedIn)
    {
      return RedirectToAction("Success");
    }
    return View("Index");
  }

  // get user registration view 
  [HttpGet("/users/new")]
  public IActionResult New()
  {
    return View("New");
  }

  // create [post] user from form to database
  [HttpPost("/users/register")]
  public IActionResult Register(User newUser)
  {
    if (ModelState.IsValid)
    {
      if (_context.Users.Any(u => u.Email == newUser.Email))
      {
        ModelState.AddModelError("Email", "Email is already in use");
        return New();
      }
    }

    if (ModelState.IsValid == false)
    {
      return New();
    }

    PasswordHasher<User> hasher = new PasswordHasher<User>();
    newUser.Password = hasher.HashPassword(newUser, newUser.Password);

    _context.Users.Add(newUser);
    _context.SaveChanges();

    HttpContext.Session.SetInt32("UUID", newUser.UserId);
    HttpContext.Session.SetString("Name", newUser.FullName());
    return RedirectToAction("Success");
  }

  [HttpPost("Login")]
  public IActionResult Login(LoginUser loginUser)
  {
    if (ModelState.IsValid == false)
    {
      return Index();
    }

    // query for email in database
    User? userInDb = _context.Users.FirstOrDefault(u => u.Email == loginUser.LoginEmail);

    // if email is not found 
    if (userInDb == null)
    {
      // add error to modelstate and return to view
      ModelState.AddModelError("LoginEmail", "not found");
      return Index();
    }

    PasswordHasher<LoginUser> loginHasher = new PasswordHasher<LoginUser>();
    PasswordVerificationResult pwCompareResult = loginHasher.VerifyHashedPassword(loginUser, userInDb.Password, loginUser.LoginPassword);

    if (pwCompareResult == 0)
    {
      ModelState.AddModelError("LoginPassword", "is not correct");
      return Index();
    }

    // no return = no errors when attempting to log in
    // set session data
    HttpContext.Session.SetInt32("UUID", userInDb.UserId);
    HttpContext.Session.SetString("Name", userInDb.FullName());
    return RedirectToAction("Success");
  }

  [HttpPost("/logout")]
  public IActionResult Logout()
  {
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
  }

  [HttpGet("/success")]
  public IActionResult Success()
  {
    if (!loggedIn)
    {
      return Index();
    }
    return View("Success");
  }

}
