#pragma warning disable CS8618
namespace DojoSurveyValid.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

public class Survey
{
  [Required(ErrorMessage = "is required")]
  [MinLength(2, ErrorMessage = "needs to be at least 2 characters")]
  [Display(Name = "Name ")]
  public string Name { get; set; }

  [Required]
  [Display(Name = "Location ")]
  public string Location { get; set; }

  [Required]
  [Display(Name = "Favorite Language ")]
  public string Language { get; set; }

  [Comment]
  [Display(Name = "Comment ")]
  public string? Comment { get; set; }

}
