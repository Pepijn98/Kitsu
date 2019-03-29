using System.Net.Http;
using System.Net.Http.Headers;
// ReSharper disable MemberCanBePrivate.Global

namespace Kitsu
{
    public static class Kitsu
    {
        public const string Version = "1.4.2";
        
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";
        
        internal const string BaseUri = "https://kitsu.io/api/edge";
        internal const string BaseAuthUri = "https://kitsu.io/api/oauth";

        private static HttpClient RequestClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            return client;
        }
        
        internal static readonly HttpClient Client = RequestClient();
    }
}
