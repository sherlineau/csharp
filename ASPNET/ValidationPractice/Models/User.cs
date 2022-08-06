#pragma warning disable CS8618
namespace ValidationPractice.Models;
using System.ComponentModel.DataAnnotations;



public class User
{
    [Required(ErrorMessage = "is required")]
    [MinLength(3, ErrorMessage = "must be at least 3 characters")]
    [MaxLength(20)]
    [Display(Name = "User Name")]
    public string Username { get; set; }

  [Required(ErrorMessage = "is required")]
  [EmailAddress] 
  public string Email { get; set; }


    [Required(ErrorMessage = "is required")]
    [MinLength(8)]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}