using System.ComponentModel.DataAnnotations;

namespace BindingAssignment.CustomValidators;

public class OrderDateValidator : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value != null)
        {
            DateTime? time = Convert.ToDateTime(value);
            DateTime leastTime = new DateTime(2001, 1, 1); // Corrected year

            if (time > leastTime) // Changed comparison operator
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Order Date must be greater than 1-1-2001");
            }
        }

        return null;
    }
}