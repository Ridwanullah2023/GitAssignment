using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }

        public void PrintUser()
        {
            Console.WriteLine(" {0} \t {1} \t {2}", Id, Username, Role);
        }

    }

    public enum Role
    {
        Admin,
        Customer
    }
}
