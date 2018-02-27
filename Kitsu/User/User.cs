using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global

namespace Kitsu.User
{
    public class User
    {
        private static readonly HttpClient Client = Kitsu.Client();

        public static async Task<UserModel> GetUserAsync(string text, FilterType filter)
        {
            string f;
            switch (filter)
            {
                    case FilterType.Name:
                        f = "name";
                        break;
                    case FilterType.Query:
                        f = "query";
                        break;
                    case FilterType.Slug:
                        f = "slug";
                        break;
                    default:
                        f = "name";
                        break;
            }

            var json = await Client.GetStringAsync($"/users?[{f}]={text}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }

        public static async Task<UserByIdModel> GetUserAsync(int id)
        {
            var resp = await Client.GetAsync($"/users/{id}");
            var json = await resp.Content.ReadAsStringAsync();
            
            var user = JsonConvert.DeserializeObject<UserByIdModel>(json);
            return user;
        }
    }

    public enum FilterType
    {
        Slug,
        Name,
        Query
    }
}