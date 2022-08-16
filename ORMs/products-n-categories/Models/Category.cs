#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Category
{
  [Key]
  public int CategoryId { get; set; }

  // model specific properties below
  [Required(ErrorMessage = " is required")]
  [Display(Name = "Category Name")]
  public string Name { get; set; }
  
  // for many to many relationship with products
  public List<Association> AssociatedProducts { get; set; } = new List<Association>();

  // created at & updated at 
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}