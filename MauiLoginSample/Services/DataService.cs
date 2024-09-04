using MauiLoginSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginSample.Services
{
    public class DataService : IDataService
    {
        public Task<IEnumerable<User>> GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
