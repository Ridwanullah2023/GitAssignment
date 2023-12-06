using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }
        public bool IsAvailable { get; set; }

        public void Print()
        {
            Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4}"
                            , Id, Title, Author, Genre, IsAvailable);
        }

    }

    public enum Genre
    {
        Fiction,
        Horror,
        Educational,
        Romance
    }
}
