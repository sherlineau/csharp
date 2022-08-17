#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[NotMapped]
public class LoginUser
{
  [Required]
  [EmailAddress]
  [Display(Name = "Email")]
  public string LoginEmail { get; set; }

  [Required]
  [MinLength(8, ErrorMessage = " must be at least 8 characters")]
  [DataType(DataType.Password)]
  [Display(Name = "Password")]
  public string LoginPassword { get; set; }
}