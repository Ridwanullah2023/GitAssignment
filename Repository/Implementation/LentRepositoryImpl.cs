using Library_Management_System.Models;
using Library_Management_System.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Library_Management_System.Repository.Implementation
{
    public class LentRepositoryImpl : ILentRepository
    {
        private static List<Lent> lents = new List<Lent>();
        
        public Lent Borrow(Lent l)
        {
            if (l != null)
            {
                lents.Add(l);
                return l;
            }
            return null;
        }

        public List<Lent> GetAll()
        {
            var query = from l in lents select l;

            return query.ToList();
        }

        public List<Lent> GetAllByUser(int userId)
        {
            return lents.Where(l => l.User.Id == userId).ToList();
        }

        public List<Lent> GetAllPendingReturn()
        {
            return lents.Where(l => l.isReturned == false).ToList();

        }

        public Lent GetLent(int id)
        {
            return lents.Where(l => l.Id == id).FirstOrDefault();
        }

        public int GetLentCount()
        {
            return lents.Count() != 0 ? lents[lents.Count - 1].Id + 1 : 1;
        }

        public bool Return(int id, Lent l)
        {
            if(lents.Exists(l => l.Id == id) && l != null)
            {
                lents[id - 1].isReturned = true;
                lents[id - 1].DateReturned = DateTime.Now;
                return true;
            }
            return false;
        }
    }
}
