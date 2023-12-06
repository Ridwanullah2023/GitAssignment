using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Lent
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public DateTime DateBorrowed { get; set; }
        public bool isReturned { get; set; }
        public DateTime? DateReturned { get; set; }

        public void Print()
        {
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5}"
                            , Id, User.Username, Book.Title, DateBorrowed, isReturned, DateReturned);
        }
        public void PrintByUser()
        {
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}"
                            , Id, Book.Title, DateBorrowed, isReturned, DateReturned);
        }
    }

}
