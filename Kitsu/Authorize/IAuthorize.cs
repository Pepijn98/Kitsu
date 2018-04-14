namespace Kitsu.Authorize
// ReSharper disable UnusedMemberInSuper.Global
{
    public interface IAuthorize
    {
        string AccessToken { get; }
        ulong? CreatedAt { get; }
        ulong? ExpiresIn { get; }
        string RefreshToken { get; }
        string Scope { get; }
        string TokenType { get; }
    }

    public interface IAuthorizeError
    {
        string Error { get; }
        string ErrorDescription { get; }
    }
}