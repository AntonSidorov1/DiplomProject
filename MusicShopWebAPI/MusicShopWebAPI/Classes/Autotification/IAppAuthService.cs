namespace MusicShopWebAPI
{
    public interface IAppAuthService
    {
        Token Authenticate(string session, string role);
    }
}
