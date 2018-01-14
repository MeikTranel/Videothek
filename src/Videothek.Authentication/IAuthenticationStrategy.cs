namespace Videothek.Authentication
{
    public interface IAuthenticationStrategy
    {
        AuthenticationToken VerifyCredentials(Credentials credentials);
    }
}