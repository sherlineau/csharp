#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class UserRSVPEvent
{
  [Key]
  public int UserRSVPEventId { get; set; }

  // model specific properties below
  // foreign keys for center table in many-to-many relationship
  public int UserId { get; set; }
  public User? Guest { get; set; }
  public int EventId { get; set; }
  public Event? Event { get; set; }
  
//created at and updated at columns
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}