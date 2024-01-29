using InterfaceDAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFDAL
{
    public partial class EFDAL<T> : FullCartContext, IDAL<T> where T : class
    {
        private IConfiguration _connectionstring;
        public EFDAL(IConfiguration configuration) : base(configuration)
        {
            this._connectionstring = configuration;
        }

        public virtual T Add(T obj)
        {
            return Set<T>().Add(obj).Entity;
        }

        public virtual void Delete(T obj)
        {
            Set<T>().Remove(obj);
        }

        public T Get(int key)
        {
           return Set<T>().Find(key);
        }

        public List<T> GetAll()
        {
            return Set<T>().ToList();
        }

        public virtual void Save()
        {
            SaveChanges();
        }

        public virtual void Update(T obj)
        {
            Set<T>().Update(obj);
        }

    }
    }
