using Newtonsoft.Json;

namespace Kitsu.Authorize
{
    public class AuthorizeModel : IAuthorize
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }
        
        [JsonProperty("created_at")]
        public ulong? CreatedAt { get; private set; }
        
        [JsonProperty("expires_in")]
        public ulong? ExpiresIn { get; private set; }
        
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }
        
        [JsonProperty("scope")]
        public string Scope { get; private set; }
        
        [JsonProperty("token_type")]
        public string TokenType { get; private set; }
    }
    
    public class AuthorizeErrorModel : IAuthorizeError
    {
        [JsonProperty("error")]
        public string Error { get; private set; }
        
        [JsonProperty("error_description")]
        public string ErrorDescription { get; private set; }
    }
}