using System.Net.Http;
using System.Net.Http.Headers;
// using System.Text;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ConvertToConstant.Global


namespace Kitsu
{
    public class Kitsu
    {
        public static readonly string Version = "1.2.0-alpha2";
        private static readonly string UserAgent = $"Kitsu/v{Version} NugetPackage (https://github.com/KurozeroPB/Kitsu)";

        internal static HttpClient Client;
        // internal static HttpRequestMessage RequestMessage;
        
        /// <summary>
        /// Initialize the httpclient to make api requests
        /// </summary>
        public Kitsu()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        }

        /**
         * I guess this could be the request when wanting to autheticate?
         * Probably never gonna use auth anyways unless it's gonna be required for GET requests
         * 
        public Kitsu(string clientId, string clientSecret)
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            Client.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            
            RequestMessage = new HttpRequestMessage(HttpMethod.Post, "https://kitsu.io/api/oauth/token");
            RequestMessage.Headers.Accept.Clear();
            RequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.api+json"));
            RequestMessage.Headers.Add("User-Agent", UserAgent);
            
            RequestMessage.Content = new StringContent($"{{\"CLIENT_ID\": \"{clientId}\", \"CLIENT_SECRET\": \"{clientSecret}\"}}", Encoding.UTF8, "application/vnd.api+json");

            Client.SendAsync(RequestMessage).ContinueWith(responseTask =>
            {
                System.Console.WriteLine("Response: {0}", responseTask.Result);
            });
        }
         */
    }
}
