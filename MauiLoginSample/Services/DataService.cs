using MauiLoginSample.Helpers;
using MauiLoginSample.Models;

namespace MauiLoginSample.Services
{
    public class DataService : IDataService
    {
        private static List<User> allUsers;

        private static List<User> AllUsers
        {
            get
            {
                if (allUsers is null)
                    allUsers = new List<User>();

                return allUsers;
            }
            set { allUsers = value; }
        }


        private const string API_URL = "api.google.com";

        private HttpClient _client;
        public HttpClient Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new HttpClient();
                }

                return _client;
            }
        }

        public async Task<bool> AddUser(User user)
        {
            user.CleanForTransport();

            /*string json = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await Client.PostAsync(String.Format("{0}/AddUser", API_URL), content);
            return response.IsSuccessStatusCode;*/

            if (AllUsers.Exists(r => r.UserName.ExactMatch(user.UserName)))
                return false;

            AllUsers.Add(user);

            return true;
        }

        public async Task<User> GetUser(string username, string password)
        {
            /*var model = new {username, password};
            string json = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await Client.PostAsync(String.Format("{0}/GetUser", API_URL), content);
            var user = User.FromJson(await resp.Content.ReadAsStringAsync());
            return user;*/

            var user = AllUsers.FirstOrDefault(r => r.UserName.ExactMatch(username) && r.Password.ExactMatch(password));

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            // Offline
            /*using var stream = await FileSystem.OpenAppPackageFileAsync("testUsers.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            var json = Item.FromJson(contents);*/

            /*var uri = String.Format("{0}/GetUsers", API_URL);
            var resp = await Client.GetStringAsync(uri);
            var users = User.GetUsersFromJson(resp);
            AllUsers = users;*/

            return AllUsers;
        }
    }
}
