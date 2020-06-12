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
    public class UserRepo:baseRepo
    {
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
            try
            {
                dbContext.User.Add(newUser);
                await dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return await dbContext.User.FindAsync(newUser.id);
        }
    }
}
