using System.ComponentModel.DataAnnotations;

/*
Validator for checking if date is before current date
*/
public class PastDateAttribute : ValidationAttribute
{
  public override string FormatErrorMessage(string name)
  {
    return " should not be a future date";
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    var dateValue = value as DateTime? ?? new DateTime();

    if (dateValue.Date > DateTime.Today)
    {
      return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
    }
    return ValidationResult.Success;
  }
}