using DALayer.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALayer.genericrepo
{
    public class GenericRepoService<T> : IGenericrepo<T> where T : class
    {
        private bookstoreContext bookstotecon;

        private DbSet<T> table;

        public GenericRepoService(bookstoreContext bookstotecont)
        {
            bookstotecon = bookstotecont;
            table = bookstotecon.Set<T>();
        }
            

        public void delete(object id)
        {
            T rec = table.Find(id);
            if(rec!=null)
            {
                table.Remove(rec);

            }
            else
            {
                throw new Exception("record not found");
            }
                
        }

        public IEnumerable<T> GetAll()
        {
           return table.ToList();
        }

        public T GetbyId(long id)
        {
            T rec = table.Find(id);

            if (rec != null)
            {
                return table.Find(id);
            }
            else
            {
                throw new Exception("record not found");
            }
        }
           

        public void insert(T obj)
        {
            table.Add(obj);
            bookstotecon.SaveChanges();
        }

        public void update(T obj)
        {
            table.Attach(obj);
            bookstotecon.Entry(obj).State = EntityState.Modified;
            bookstotecon.SaveChanges();

        }
    }
}
