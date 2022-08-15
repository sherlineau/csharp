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
  public DateTime? Birthday { get; set; }

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  public List<Dish> CreatedDishes { get; set; } = new List<Dish>();

  public string FullName()
  {
    return $"{FirstName} {LastName}";
  }

  public int Age()
  {
    if ( Birthday != null) {
      DateTime dob = (DateTime)Birthday;
      
    int age =  DateTime.Now.Year - dob.Year;

    if(DateTime.Now.Month < dob.Month || (DateTime.Now.Month == dob.Month && DateTime.Now.Day < dob.Day))
    {
      age--;
    }
    return age;
    } 
    return 0;
  }
}