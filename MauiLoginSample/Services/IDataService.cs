using MauiLoginSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginSample.Services
{
    public interface IDataService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUser(string username, string password);
    }
}
