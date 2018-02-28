using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
// ReSharper disable UnusedMember.Global
// ReSharper disable RedundantCaseLabel

namespace Kitsu.User
{
    public static class User
    {
        private static readonly HttpClient Client = Kitsu.Client();

        public static async Task<UserModel> GetUserAsync(string text, FilterType filter)
        {
            string f;
            switch (filter)
            {
                case FilterType.Slug:
                    f = "slug";
                    break;
                case FilterType.Query:
                    f = "query";
                    break;
                case FilterType.Name:
                default:
                    f = "name";
                    break;
            }

            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/users?filter[{f}]={text}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }
        
        public static async Task<UserModel> GetUserAsync(string text, FilterType filter, int offset)
        {
            string f;
            switch (filter)
            {
                case FilterType.Slug:
                    f = "slug";
                    break;
                case FilterType.Query:
                    f = "query";
                    break;
                case FilterType.Name:
                default:
                    f = "name";
                    break;
            }

            var json = await Client.GetStringAsync($"https://kitsu.io/api/edge/users?filter[{f}]={text}&page[offset]={offset}");
            var user = JsonConvert.DeserializeObject<UserModel>(json);
            return user;
        }

        public static async Task<UserByIdModel> GetUserAsync(int id)
        {
            var resp = await Client.GetAsync($"https://kitsu.io/api/edge/users/{id}");
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