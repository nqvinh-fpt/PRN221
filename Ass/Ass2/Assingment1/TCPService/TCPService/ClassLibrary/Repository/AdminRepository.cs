using ClassLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private Assignment2Context data;

    public AdminRepository(Assignment2Context context)
    {
        data = context;
    }

    public IEnumerable<Admin> GetAdmins() => data.Admins.AsNoTracking().ToList();

    public void InsertAdmin(Admin admin)
    {
        data.Admins.Add(admin);
        data.SaveChanges();
        data.Entry(admin).State = EntityState.Detached;
    }

    public void DeleteAdmin(Admin admin)
    {
        data.Admins.Remove(admin);
        data.SaveChanges();
    }

    public void UpdateAdmin(Admin admin)
    {
        data.Admins.Update(admin);
        data.SaveChanges();
        data.Entry(admin).State = EntityState.Detached;
    }
}
}

