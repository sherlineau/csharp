using System.ComponentModel.DataAnnotations;

/*
Validator for checking if date is before current date
*/
public class LegalAgeAttribute : ValidationAttribute
{
  public override string FormatErrorMessage(string name)
  {
    return "Need to be at least 18 years old";
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var dateValue = value as DateTime? ?? new DateTime();
    int age = DateTime.Today.Year - dateValue.Year; 

    if(DateTime.Now.Month < dateValue.Month || (DateTime.Now.Month == dateValue.Month && DateTime.Now.Day < dateValue.Day))
    {
      age--;
    }

    if ( age < 18) 
    {
      return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
    
    return ValidationResult.Success;
  }
}