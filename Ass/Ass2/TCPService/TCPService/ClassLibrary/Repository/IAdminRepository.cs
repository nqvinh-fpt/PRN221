using ClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IAdminRepository
    {
        void DeleteAdmin(Admin admin);
        IEnumerable<Admin> GetAdmins();
        void InsertAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
    }
}
