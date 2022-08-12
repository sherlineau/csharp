#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Chef
{
  [Key]
  public int ChefId { get; set; }

  [Required(ErrorMessage = "is required")]
  [Display(Name = "First Name")]
  public string FirstName { get; set; }

  [Required(ErrorMessage = "is required")]
  [Display(Name = "Last Name")]
  public string LastName { get; set; }

  [Required]
  [LegalAge]
  [PastDate]
  [Display(Name = "Date of Birth")]
  [DataType(DataType.Date)]
  
  public DateTime Birthday { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  public List<Dish> CreatedDishes { get; set; } = new List<Dish>();

  public string FullName()
  {
    return $"{FirstName} {LastName}";
  }

  public int Age()
  {
    int age =  DateTime.Now.Year - Birthday.Year;

    if(DateTime.Now.Month < Birthday.Month || (DateTime.Now.Month == Birthday.Month && DateTime.Now.Day < Birthday.Day))
    {
      age--;
    }
    return age;
  }
}