using Library_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services.Interface
{
    public interface IUserService
    {
        User AddUser(string username, int role);
        void RemoveUser(int id);
        void UpdateUser(int id, string username);
        List<User> GetUsers();
        User GetUser(int id);
        bool IsAdmin(int id);
        void PrintUsers(List<User> users);
    }
}
