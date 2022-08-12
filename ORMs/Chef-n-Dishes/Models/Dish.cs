#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Dish
{
  [Key]
  public int DishId { get; set; }

  [Required(ErrorMessage = " is required")]
  public string Name { get; set; }

  [Required(ErrorMessage = "is required")]
  [Range(0, int.MaxValue, ErrorMessage = "Positive numbers only")]
  public int? Calories { get; set; }

  [Required]
  public int Tastiness { get; set; }

  [Required]
  public string Description { get; set; }

  [Required]
  [Display(Name = "Chef")]
  public int ChefId { get; set; }

  public Chef? DishChef { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}