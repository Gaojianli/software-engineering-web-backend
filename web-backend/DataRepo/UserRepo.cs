using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;
using Microsoft.AspNetCore.Builder; 
using web_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace web_backend.DataRepo
{
    public class UserRepo
    {
        static private UserRepo _instance;
        private CoreDbContext dbContext;

        private UserRepo(CoreDbContext CoredbContext) => dbContext = CoredbContext;
        static public UserRepo getInstance(CoreDbContext CoredbContext)
        {
            if (_instance == null)
                _instance = new UserRepo(CoredbContext);
            else
                _instance.dbContext = CoredbContext;
            return _instance;
        }
        public User Login(string username,string password)
        {  
            var toReturn = from User in dbContext.User
                           where User.name == username &&
                           User.password == password
                           select User;
            if (toReturn.Count() == 0)
                return null;
            else
                return toReturn.Single();
        }

        public async Task<User> Add(string username,string password)
        {
            var newUser = new User
            {
                name = username,
                password = password
            };
            dbContext.User.Add(newUser);
            await dbContext.SaveChangesAsync();
            return await dbContext.User.FindAsync(newUser.id);
        }
    }
}
