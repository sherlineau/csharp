#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Event
{
  [Key]
  public int EventId { get; set; }

  // model specific properties below
  [Required(ErrorMessage = "is required")]
  [Display(Name = "Partner One")]
  public string WedderOne { get; set; }

  [Required(ErrorMessage = "is required")]
  [Display(Name = "Partner Two")]
  public string WedderTwo { get; set; }

  [Required(ErrorMessage = "is required")]
  [FutureDateOnly]
  [DataType(DataType.Date)]
  public DateTime? Date { get; set; }

  public string Address { get; set; }

  // for one to many
  public int UserId { get; set; }
  public User? Creator { get; set; }
  // many to many relationship attribute
  public List<UserRSVPEvent> Guests { get; set; } = new List<UserRSVPEvent>();

  //created at and updated at columns
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  public string Couple()
  {
    return $"{WedderOne} & {WedderTwo}";
  }
}