using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Models;

namespace web_backend.DataRepo
{
    public class baseRepo
    {
        protected CoreDbContext dbContext;
        static private baseRepo _instance;
        protected baseRepo(){}
        static public T getInstance<T>(CoreDbContext CoredbContext) where T : baseRepo, new()
        {
            if (_instance == null)
                _instance = new T();
            _instance.dbContext = CoredbContext;
            return _instance as T;
        }
    }
}
