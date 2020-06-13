using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Models;

namespace web_backend.DataRepo
{
    public class baseRepo<T> where T : baseRepo<T>, new()
    {
        protected CoreDbContext dbContext;
        static private T _instance;
        protected baseRepo() { }
        static public T getInstance(CoreDbContext CoredbContext)
        {
            if (_instance == null)
                _instance = new T();
            _instance.dbContext = CoredbContext;
            return _instance as T;
        }
    }
}
