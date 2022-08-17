#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
  // primary key for database
  [Key]
  public int UserId { get; set; }

  // model specific properties below
  [Required(ErrorMessage = "is required")]
  [Display(Name = "First Name")]
  public string FirstName { get; set; }

  [Required(ErrorMessage = "is required")]
  [Display(Name = "Last Name")]
  public string LastName { get; set; }

  [Required(ErrorMessage = "is required")]
  [EmailAddress]
  public string Email { get; set; }

  [Required(ErrorMessage = "is required")]
  [DataType(DataType.Password)]
  [MinLength(8, ErrorMessage = " must be at least 8 characters")]
  public string Password { get; set; }

  [NotMapped]
  [Compare("Password", ErrorMessage = "Passwords must match")]
  [DataType(DataType.Password)]
  public string Confirm { get; set; }

  //relationshp properties
  // one to many -> many events created by one user
  public List<Event> CreatedEvents { get; set; } = new List<Event>();
  // many to many -> for rsvping to other events
  public List<UserRSVPEvent> RSVPedEvents { get; set; } = new List<UserRSVPEvent>();

  //created at and updated at columns
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  public string FullName()
  {
    return $"{FirstName} {LastName}";
  }
}