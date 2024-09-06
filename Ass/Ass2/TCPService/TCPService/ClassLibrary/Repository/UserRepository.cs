
using ClassLibrary.Repository;
using ClassLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessLibrary.Repository
{
    public class UserRepository : IUserRepository
    {
        private Assignment2Context data;

        public UserRepository(Assignment2Context context)
        {
            data = context;
        }

        public IEnumerable<User> GetUsers() => data.Users.AsNoTracking().ToList();

        public void InsertUser(User user)
        {
            data.Users.Add(user);
            data.SaveChanges();
            data.Entry(user).State = EntityState.Detached;
        }

        public void DeleteUser(User User)
        {
            data.Users.Remove(User);
            data.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            data.Users.Update(user);
            data.SaveChanges();
            data.Entry(user).State = EntityState.Detached;
        }
    }
}
