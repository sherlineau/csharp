#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class User
{
  [Required(ErrorMessage = "is required")]
  [MinLength(4, ErrorMessage = "must be at least 4 characters")]
  [Display(Name = "First Name")]
  public string FirstName { get; set; }

  [Required(ErrorMessage = "is required")]
  [MinLength(4, ErrorMessage = "must be at least 4 characters")]
  [Display(Name = "Last Name")]
  public string LastName { get; set; }

  [Required(ErrorMessage = "is required")]
  [Range(0, int.MaxValue, ErrorMessage = "Positive numbers only")]
  public int Age { get; set; }

  [Required(ErrorMessage = " is required")]
  [EmailAddress]
  public string Email { get; set; }

  [Required(ErrorMessage = "is required")]
  [MinLength(8, ErrorMessage = "must be at least 8 characters")]
  [DataType(DataType.Password)]
  public string Password { get; set; }
}