using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EventController : Controller
{
  // store uid for checking login state
  private int? uid { get { return HttpContext.Session.GetInt32("UUID"); } }
  private bool loggedIn { get { return uid != null; } }

  // MyContext class for db querying
  private MyContext _db;

  public EventController(MyContext context)
  {
    _db = context;
  }

  // display dashboard to logged in users
  [HttpGet("/dashboard")]
  public IActionResult Dashboard()
  {
    // if not logged in, return index method to display login/registration
    if (!loggedIn)
    {
      return RedirectToAction("Index", "User");
    }

    // display all events
    List<Event> AllEvents = _db.Events.Include(e => e.Creator).Include(e => e.Guests).ToList();

    foreach (Event e in AllEvents)
    {
      if (e.Date < DateTime.Now)
      {
        Event? pastEvent = _db.Events.FirstOrDefault(e => e.EventId == e.EventId);
        if (pastEvent != null)
        {
          _db.Events.Remove(pastEvent);
          _db.SaveChanges();
          AllEvents.Remove(e);
        }
      }
    }

    return View("Dashboard", AllEvents);
  }

  //for displaying form to create new events
  [HttpGet("/events/new")]
  public IActionResult New()
  {
    if (!loggedIn)
    {
      return RedirectToAction("Index", "User");
    }
    return View("New");
  }

  [HttpPost("/events/create")]
  public IActionResult Create(Event newEvent)
  {
    // if user is not logged in -> redirect to login
    if (!loggedIn || uid == null)
    {
      return RedirectToAction("Index", "User");
    }

    // if model/form validations fail
    if (ModelState.IsValid == false)
    {
      return New();
    }

    //"connects" created event to logged in user
    newEvent.UserId = (int)uid;
    _db.Events.Add(newEvent);
    _db.SaveChanges();

    return RedirectToAction("Dashboard");
  }

  // get one for details page
  [HttpGet("/events/{eventId}")]
  public IActionResult Details(int eventId)
  {
    if (!loggedIn)
    {
      return RedirectToAction("Index", "User");
    }

    Event? eve = _db.Events.Include(e => e.Creator).Include(e => e.Guests).ThenInclude(g => g.Guest).FirstOrDefault(e => e.EventId == eventId);

    if (eve == null)
    {
      return RedirectToAction("Dashboard");
    }
    return View("Details", eve);
  }

  // delete
  [HttpPost("/events/{eventId}/delete")]
  public IActionResult Delete(int eventId)
  {
    if (!loggedIn)
    {
      return RedirectToAction("Index", "User");
    }

    Event? eventToBeDeleted = _db.Events.FirstOrDefault(e => e.EventId == eventId);

    //only delete if creator id matches uid
    if (eventToBeDeleted != null)
    {
      if (eventToBeDeleted.UserId == uid)
      {
        _db.Events.Remove(eventToBeDeleted);
        _db.SaveChanges();
      }
    }
    return RedirectToAction("Dashboard");
  }

  // rsvp
  [HttpPost("/events/{eventId}/rsvp")]
  public IActionResult RSVP(int eventId)
  {
    if (!loggedIn || uid == null)
    {
      return RedirectToAction("Index", "User");
    }

    UserRSVPEvent? existingRsvp = _db.UserRSVPEvents.FirstOrDefault(r => r.EventId == eventId && r.UserId == uid);

    if(existingRsvp == null)
    {
      UserRSVPEvent newRsvp = new UserRSVPEvent()
      {
        EventId = eventId,
        UserId = (int)uid
      };
      _db.UserRSVPEvents.Add(newRsvp);
    }
    else 
    {
      _db.Remove(existingRsvp);
    }

    _db.SaveChanges();
    return RedirectToAction("Dashboard");
  }
}