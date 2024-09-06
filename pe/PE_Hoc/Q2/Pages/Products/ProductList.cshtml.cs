using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Q2.Hubs;
using Q2.Models;
using System.Text.Json;

namespace Q2.Pages.Products
{
    public class ProductListModel : PageModel
    {
        private readonly LuyenOnThiDBContext context;
        private readonly IHubContext<ProductsHub> hubContext;
        public ProductListModel(IHubContext<ProductsHub> hubContext)
        {
            context = new LuyenOnThiDBContext();
            this.hubContext = hubContext;
        }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public void OnGet(int idCategory = 0)
        {
            if (idCategory == 0)
            {
                Products = context.Products.ToList();
            }
            else
            {
                CategorySelected = idCategory;
                Products = context.Products.Where(x => x.CategoryId == idCategory).ToList();
            }
            Categories = context.Categories.ToList();
        }

        public int CategorySelected { get; set; }

        public IActionResult OnGetAddToCart(int productId, int idCategory)
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
                order.Quantity++;
            }
            else
            {
                order = new OrderDetail();
                order.ProductId = productId;
                order.Quantity = 1;
                orders.Add(order);
            }
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(orders));
            CategorySelected = idCategory;
            return RedirectToPage("", new { idCategory = idCategory });
            /*return RedirectToPage("/Cart"); gui snang the cart*/
        }

        public IActionResult OnGetDeleteProduct(int productId, int idCategory)
        {
            
            Product product =context.Products.Include(x=>x.OrderDetails).FirstOrDefault(x=> x.ProductId == productId);
            if (product != null)
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
                    HttpContext.Session.SetString("cart", JsonSerializer.Serialize(orders));
                }
                context.OrderDetails.RemoveRange(product.OrderDetails);
                context.Products.Remove(product);
                context.SaveChanges();
                hubContext.Clients.All.SendAsync("products", productId);
            }

            return RedirectToPage("", new { idCategory = idCategory });
            /*return RedirectToPage("/Cart"); gui snang the cart*/
        }
    }
}
