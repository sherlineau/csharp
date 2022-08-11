#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User {
  [Key] 
  public int UserId { get; set; }

  [Required(ErrorMessage = "is required")] 
  public string FirstName { get; set; }

  [Required(ErrorMessage = "is required")] 
  public string LastName { get; set; }

  [Required(ErrorMessage = "is required")]
  [EmailAddress] 
  public string Email { get; set; }

  [Required(ErrorMessage = "is required")]
  [DataType(DataType.Password)] 
  [MinLength(8,ErrorMessage = "Password must be 8 characters or longer")]
  public string Password { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  // properties NOT added to database
  [NotMapped]
  [Compare("Password",ErrorMessage ="Passwords must match")]
  [DataType(DataType.Password)]
  public string Confirm { get; set; }

  // function to get full name
  public string FullName()
  {
    return $"{FirstName} {LastName}";
  }
}