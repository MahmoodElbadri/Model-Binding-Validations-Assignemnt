using BindingAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BindingAssignment.Controllers
{
    public class E_CommerceController : Controller
    {
        [Route("/order")]
        public IActionResult Index([Bind("OrderDate", "InvoicePrice", "Products")] Order order)
        {
            if (!ModelState.IsValid)
            {
                string errorList = string.Join("/n", ModelState.Values.SelectMany(val => val.Errors).Select(err => err.ErrorMessage));
                return BadRequest(errorList);
            }

            Random random = new Random();
            int randomNumber = random.Next(1, 1000);
            double totalPrice = 0;
            //New Order Number: [some random number]
            foreach (Product product in order.Products)
            {
                totalPrice += Convert.ToDouble(product.Price*product.Quantity);
            }

            if (totalPrice == order.InvoicePrice)
            {
                // return Content($"New Order Number: {randomNumber}");
                //return Json($"New Order Number: {randomNumber}");
                return Json(new { orderNumber = randomNumber });
            }
            // return BadRequest("InvoicePrice doesn't match with the total cost of the specified products in the order.");
            Response.StatusCode = 400;
            return Content("InvoicePrice doesn't match with the total cost of the specified products in the order.", "text/plain");
        }
    }
}
