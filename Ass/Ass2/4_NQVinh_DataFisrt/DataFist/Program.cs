using _4_NQVinh_DataFisrt.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace _4_NQVinh_DataFisrt
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MyStoreContext myStoreContext = new MyStoreContext();
            var products = from p in myStoreContext.Products
                           select new { p.ProductId, p.ProductName, p.UnitPrice, p.UnitInStock, p.CategoryId };
            decimal numProduct = 0;
            Console.WriteLine($"| ProductId | ProductName         | UnitPrice | UnitInStock | CategoryId |");
            foreach (var item in products)
            {
                Console.WriteLine($"| {item.ProductId,-10} | {item.ProductName,-20} | {item.UnitPrice,-9} | {item.UnitInStock,-12} | {item.CategoryId,-10} |");
                decimal unitInStock = item.UnitInStock;
                numProduct += unitInStock;
            }

            Console.WriteLine("--------------------------------------------------------------------------------");
            IQueryable<Category> categories = myStoreContext.Categories.Include(c => c.Products);

            Console.WriteLine($"| CategoryId | CategoryName       |");
            foreach (Category category in categories)
            {
                Console.WriteLine($"| {category.CategoryId,-11} | {category.CategoryName,-18} |");
            }

            Console.WriteLine($"| CategoryId | ProductTotal |");
            foreach (Category category in categories)
            {
                Console.WriteLine($"| {category.CategoryId,-11} | {category.Products.Count,-12} |");
            }

            Console.WriteLine("Number product: "+ numProduct.ToString());
            Console.ReadLine();
            

        }
    }
}