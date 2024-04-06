using System.ComponentModel.DataAnnotations;
using BindingAssignment.CustomValidators;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BindingAssignment.Models
{
    public class Order
    {
        [BindNever]
        public int? OrderNumber { get; set; }
        
        
        [Required(ErrorMessage = "{0} must be supplied")]
        [DataType(DataType.DateTime)]
        [OrderDateValidator]
        public DateTime? OrderDate { get; set; }
        
        
        [Required(ErrorMessage = "{0} must be supplied")]
        [Display(Name = "Invoice Price")]
        public double? InvoicePrice { get; set; }
        
        
        [Required(ErrorMessage = "{0} must be supplied")]
        [Display(Name = "List of products")]
        public List<Product>? Products { get; set; } = new List<Product>();
        public override string ToString()
        {
            return
                $"Order Number is {OrderNumber}\nOrder Date is {OrderDate}\nInvoice Price is {InvoicePrice}\n" +
                $"and your products are {string.Join("\n",Products)}";
        }
    }
}
