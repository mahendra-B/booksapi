using System;
using System.Collections.Generic;
using System.Text;

namespace DALayer.genericrepo
{
    public interface IGenericrepo<T> where T:class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        void insert(T obj);

        void update(T obj);

        void delete(object id);


    }
}
