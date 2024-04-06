using System.ComponentModel.DataAnnotations;
using System.Reflection;
using BindingAssignment.Models;

namespace BindingAssignment.CustomValidators;

public class InvoicePriceValidatorAttribute : ValidationAttribute
{
    public string DefaultErrorMessage { get; set; } =
        "Invoice Price should be equal to the total cost of all products (i.e. {0}) in the order.";

    public InvoicePriceValidatorAttribute()
    {
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
        if (value != null)
        {
            List<Product>
                products = (List<Product>)otherProperty?.GetValue(validationContext
                    .ObjectInstance)!; //! means value that will be returned is not null
            double totalPrice = 0;
            foreach (Product product in products)
            {
                totalPrice += Convert.ToDouble(product.Price * product.Quantity);
            }

            double actualPrice = Convert.ToDouble(value);
            if (actualPrice == totalPrice)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(string.Format(DefaultErrorMessage, totalPrice));
        }

        return null;
    }
}
