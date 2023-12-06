using Library_Management_System.Models;
using Library_Management_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Repository.Implementation
{
    public class UserRepositryImpl : IUserRepository
    {

        public static List<User> users = new List<User>();

        public UserRepositryImpl()
        {
            users.Add(new User
            {
                Id = 1,
                Username = "Kajol",
                Role = Role.Admin
            }); 
        }
        public User? AddUser(User user)
        {
           if(user != null)
           {
                users.Add(user);
                return user;
           }
            return null;

        }

        public bool DeleteUser(int id)
        {
            User u = GetUser(id);
            if(u != null)
            {
                return users.Remove(u);
                
            }

            return false;
           
        }

        public User? GetUser(int id)
        {
            if (users.Exists(u => u.Id == id))
            {
                var query = from u in users
                            where u.Id == id
                            select u;

                return query.FirstOrDefault();

            }
            return null;
            
        }

        public int GetUserCount()
        {
            return users.Count() != 0 ? users[users.Count - 1 ].Id + 1  : 1;
        }

        public List<User> GetUsers()
        {
            var query = from u in users
                        select u; 
            
            return query.ToList();
        }

        public User? UpdateUser(int id, User u)
        {
            if(users.Exists(u => u.Id == id))
            {
                users[id-1].Username = u.Username;
                return u;
              /*  foreach (var user in users)
                {
                    if (u.Id == id)
                    {
                        user.Username = u.Username;
                        return user;
                    }
                }*/
            }            
            return null;
        }
    }
}
