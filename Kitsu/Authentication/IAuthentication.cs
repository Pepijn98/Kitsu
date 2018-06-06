namespace Kitsu.Authentication
// ReSharper disable UnusedMemberInSuper.Global
{
    public interface IAuthentication
    {
        string AccessToken { get; }
        ulong? CreatedAt { get; }
        ulong? ExpiresIn { get; }
        string RefreshToken { get; }
        string Scope { get; }
        string TokenType { get; }
    }

    public interface IAuthenticationError
    {
        string Error { get; }
        string ErrorDescription { get; }
    }
}