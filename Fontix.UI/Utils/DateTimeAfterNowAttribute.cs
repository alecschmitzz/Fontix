using System.ComponentModel.DataAnnotations;

namespace Fontix.UI.Utils;

public class DateTimeAfterNowAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        DateTime dateTime = (DateTime)value;
        if (dateTime <= DateTime.Now)
        {
            return new ValidationResult(ErrorMessage);
        }
        return ValidationResult.Success;
    }
}
