#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Product
{
  [Key]
  public int ProductId { get; set; }

  // model specific properties below
  [Required(ErrorMessage = " is required")]
  public string Name { get; set; }

  [Required(ErrorMessage = " is required")]
  public string Description { get; set; }

  [Required(ErrorMessage = " is required")]
  public decimal Price { get; set; }

  // for many to many relationship with category
  public List<Association> AssociatedCategories { get; set; } = new List<Association>();

  // created at & updated at 
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}