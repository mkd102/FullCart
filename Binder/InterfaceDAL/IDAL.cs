using System;
using System.Collections.Generic;

namespace InterfaceDAL
{
    public interface IDAL<T> where T : class
    {
        T Add(T obj);
        void Save();

        void Delete(T obj);

        void Update(T obj);

        T Get(int key);

        List<T> GetAll();

       // void setUOW(IOW oW);
    }
}
