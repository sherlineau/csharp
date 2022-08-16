#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Association
{
  [Key]
  public int AssociationId { get; set; }

  // model specific properties below
  // foreign keys for many to many relationship between category and products
  public int ProductId { get; set; }
  [Required] public int CategoryId { get; set; }
  public Product? Product { get; set; }
  public Category? Category { get; set; }
  
  // created at & updated at 
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;
}