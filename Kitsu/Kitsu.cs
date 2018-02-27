using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Kitsu
{
    public static class Kitsu
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public const string Version = "1.1.0";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";

        internal static HttpClient Client()
        {
            var client = new HttpClient {BaseAddress = new Uri("https://kitsu.io/api/edge")};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            client.DefaultRequestHeaders.Add("Content-Type", "application/vnd.api+json");
            client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            return client;
        }
    }
}