using _4_NQVinh_DataFisrt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _4_NQVinh_DataFisrt
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MyStoreContext myStoreContext = new MyStoreContext();
            var products = from p in myStoreContext.Products 
                          select new {p.ProductId, p.ProductName,p.UnitPrice,p.UnitInStock,p.CategoryId};
            Console.WriteLine($"ProductId      ProductName       UnitPrice         UnitInStock       CategoryId");
            foreach (var item in products) {
                Console.WriteLine($"{item.ProductId}{item.ProductName}{item.UnitPrice}{item.UnitInStock}{item.CategoryId}");
            }
            Console.WriteLine("--------------------------------------------------------------------------------");
            IQueryable<Category>categories = myStoreContext.Categories.Include(c=>c.Products);
            Console.WriteLine($"CategoryId      CategoryName");
            foreach (Category category in categories) {
                Console.WriteLine($"{category.CategoryId}{category.CategoryName}");
            }
            Console.ReadLine();
        }
    }
}