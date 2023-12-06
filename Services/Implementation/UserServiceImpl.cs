using Library_Management_System.Models;
using Library_Management_System.Repository.Implementation;
using Library_Management_System.Repository.Interface;
using Library_Management_System.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Services.Implementation
{
    public class UserServiceImpl : IUserService
    {
        private static readonly IUserRepository userRepository = new UserRepositryImpl();
        
        public User? AddUser(string username, int role)
        {
            int id = userRepository.GetUserCount(); 

            Role userRole = new Role();
            if (role == 0)
            {
                userRole = Role.Admin;

            }
            else
            {
                userRole = Role.Customer;
            }

            User u = new User
            {
                Id = id,
                Username = username,
                Role = userRole
            };

            if (userRepository.AddUser(u) != null)
            {
                
                Console.WriteLine("User added successfully with id: {0}", id);
                return u;
            }
            else
            {
                Console.WriteLine("Unable to add user");
                return null;
            }



        }

        public User GetUser(int id)
        {
            return userRepository.GetUser(id);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public bool IsAdmin(int id)
        {
            User u = userRepository.GetUser(id);
            if(u != null)
            {
                return u.Role == Role.Admin;
            }
            return false;

        }

        public void PrintUsers(List<User> users)
        {
            Console.WriteLine("*****User Information*****\n" +
                "Id \t Username \t Role");
            foreach (User u in users)
            {
                u.PrintUser();
            }


        }

        public void RemoveUser(int id)
        {
           if(userRepository.DeleteUser(id))
           {
                Console.WriteLine("User with Id: {0} deleted successfully", id);
           }else 
           {
                Console.WriteLine("Unable to delete User");

           }
        }

        public void UpdateUser(int id, string username)
        {
            User u = userRepository.GetUser(id);
            if(u != null)
            {
                userRepository.UpdateUser(id, u);
                Console.WriteLine("User Information updated successfully");
            }
            else
            {
                Console.WriteLine("User {0} not found", id);
            }
           
        }

    }
}
