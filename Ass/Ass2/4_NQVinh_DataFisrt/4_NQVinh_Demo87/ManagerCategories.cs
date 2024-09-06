using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_NQVinh_Demo87
{
    public sealed class ManagerCategories
    {
        private static ManagerCategories instance = null!;
        private static readonly object instanceLock = new object();
        private ManagerCategories() { }
        public static ManagerCategories Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ManagerCategories();
                    }
                }
                return instance;
            }
        }

        public List<Category> GetCategories()
        {
            List<Category> categories;
            try
            {
                using CategoryContext context = new CategoryContext();
                categories = context.Categories.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public void InsertCategory(Category category)
        {
            try
            {
                using CategoryContext context = new CategoryContext();
                context.Categories.Add(category);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                using CategoryContext context = new CategoryContext();
                context.Entry<Category>(category).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void DeleteCategory(Category category)
        {
            try
            {
                using CategoryContext context = new CategoryContext();

                var cate =context.Categories.SingleOrDefault(c=>c.CategoryID==category.CategoryID);
                if (cate != null)
                {
                    context.Categories.Remove(cate);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
