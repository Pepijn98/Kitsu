using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
// ReSharper disable UnusedMember.Global
// TODO: Add manga and character search -> including Models and Interfaces

namespace KitsuNET
{
    internal static class HttpReq
    {
        private const string UserAgent = "KitsuNET - (https://github.com/KurozeroPB/KitsuNET)";
        
        public static async Task<string> AnimeByNameAsync(string name)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);

            var stringTask = client.GetStringAsync($"https://kitsu.io/api/edge/anime?filter[text]={name}&page[offset]=0");
            var json = await stringTask;

            return json;
        }
    }
}