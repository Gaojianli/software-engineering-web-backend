using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Models;

namespace web_backend.DataRepo
{
    public class BaseRepo<T> where T : BaseRepo<T>, new()
    {
        protected CoreDbContext dbContext;
        static private T _instance;
        protected BaseRepo() { }
        static public T getInstance(CoreDbContext CoredbContext)
        {
            if (_instance == null)
                _instance = new T();
            if (_instance.dbContext != null)
                _instance.dbContext.Dispose();
            _instance.dbContext = CoredbContext;
            return _instance;
        }
    }
}
