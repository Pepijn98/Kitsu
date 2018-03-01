using System.Net.Http;
using System.Net.Http.Headers;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global

namespace Kitsu
{
    public static class Kitsu
    {
        public static readonly string Version = "1.2.0-alpha4";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";

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
