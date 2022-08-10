#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Dish
{
  [Key]
  public int DishId { get; set; }

  [Required(ErrorMessage = "is required")]
  [Display(Name = "Name of Dish")]
  public string Name { get; set; }

  [Required(ErrorMessage = "is required")]
  [Display(Name = "Chef's Name")]
  public string Chef { get; set; }

  [Required(ErrorMessage = "is required")]
  public int Tastiness { get; set; }

  [Required(ErrorMessage = "is required")]
  [Range(0, int.MaxValue, ErrorMessage = "Positive numbers only")]
  [Display(Name = "# of Calories")]
  public int? Calories { get; set; }

  [Required(ErrorMessage = "is required")]
  public string Description { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}