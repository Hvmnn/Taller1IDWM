using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Taller1IDWM.Src.Validations;

public class BirthdateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || !(value is DateTime))
        {
            return new ValidationResult("Birthdate is required");
        }

        DateTime birthdate = (DateTime)value;

        if (birthdate >= DateTime.Today)
        {
            return new ValidationResult("The Birthdate must be before the current date");
        }

        return ValidationResult.Success;
    }
}