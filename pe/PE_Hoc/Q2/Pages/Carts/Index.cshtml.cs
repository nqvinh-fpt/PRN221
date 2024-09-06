using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;
using System.Text.Json;

namespace Q2.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly LuyenOnThiDBContext context;

        public IndexModel()
        {
            context = new LuyenOnThiDBContext();
        }
        public List<OrderDetail> Carts { get; set; }
        public void OnGet()
        {
            List<OrderDetail> orders = new List<OrderDetail>();
            if (HttpContext.Session.GetString("cart")!=null)
            {
                string data = HttpContext.Session.GetString("cart");
                orders = JsonSerializer.Deserialize<List<OrderDetail>>(data);
            }
            else
            {
                orders = new List<OrderDetail>();
            }

            orders.ForEach(x =>
            {
                x.Product = context.Products.FirstOrDefault(z => z.ProductId == x.ProductId);
            });
            Carts = orders;
        }

        public IActionResult OnGetDeleteCart(int productId)
        {
            List<OrderDetail> orders = new List<OrderDetail>();
            if (HttpContext.Session.GetString("cart") != null)
            {
                string data = HttpContext.Session.GetString("cart");
                orders = JsonSerializer.Deserialize<List<OrderDetail>>(data);
            }
            else
            {
                orders = new List<OrderDetail>();
            }
            OrderDetail order = orders.FirstOrDefault(x => x.ProductId == productId);
            if (order != null)
            {
                orders.Remove(order);
            }
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(orders));
            
            return RedirectToPage("");
            /*return RedirectToPage("/Cart"); gui snang the cart*/
        }
    }
}
