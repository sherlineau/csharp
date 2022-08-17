using System.ComponentModel.DataAnnotations;

public class CommentAttribute : ValidationAttribute
{
  public override string FormatErrorMessage(string name)
  {
    return "Comment needs to be at least 20 characters";
  }

  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value == null)
    {
      return ValidationResult.Success;
    }
    if (value != null)
    {
      string comment = (string)value;
      if (comment.Length < 20)
      {
        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
      }
    }
    return ValidationResult.Success;
  }
}