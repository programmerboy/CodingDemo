using MauiLoginSample.Models;

namespace MauiLoginSample.Services
{
    public interface IDataService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string username, string password);
        Task<bool> AddUser(User user);
    }
}
