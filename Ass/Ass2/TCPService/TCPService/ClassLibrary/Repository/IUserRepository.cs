

using ClassLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IUserRepository
    {
        void DeleteUser(User User);
        IEnumerable<User> GetUsers();
        void InsertUser(User user);
        void UpdateUser(User user);
    }
}