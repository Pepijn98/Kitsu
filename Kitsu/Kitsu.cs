using System.Net.Http;
using System.Net.Http.Headers;

namespace Kitsu
{
    public static class Kitsu
    {
        private const string UserAgent = "Kitsu-nuget_package/v1.0.3 - (https://github.com/KurozeroPB/Kitsu)";

        internal static HttpClient Client()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            return client;
        }
    }
}