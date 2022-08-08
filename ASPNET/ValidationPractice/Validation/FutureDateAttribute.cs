using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute 
{
  public override string FormatErrorMessage(string name)
  {
    return "Date value should not be a future date";
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var dateValue = value as DateTime? ?? new DateTime();

    if (dateValue.Date > DateTime.Now.Date)
    {
      return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
    
    return ValidationResult.Success;
  }
}