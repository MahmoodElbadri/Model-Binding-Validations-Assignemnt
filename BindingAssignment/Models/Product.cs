using System.ComponentModel.DataAnnotations;

namespace BindingAssignment.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} must be supplied")]
        [Display(Name = "Product Number")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "{0} must be greater than 0")]
        public int? ProductCode { get; set; }
        [Display(Name = "Price for each")]
        [Required(ErrorMessage = "{0} must be supplied")]
        public double? Price { get; set; }
        [Required(ErrorMessage = "{0} must be supplied")]
        [Range(1,1000, ErrorMessage = "{0} must be between 1- 1000")]
        public int? Quantity { get; set; }
    }
}
