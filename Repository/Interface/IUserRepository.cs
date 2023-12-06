using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Repository.Interface
{
    public interface IUserRepository
    {
        User AddUser(User user);
        bool DeleteUser(int id);
        User GetUser(int id);
        User UpdateUser(int id, User u);
        List<User> GetUsers();
        int GetUserCount();

    }
}
