namespace FIAP.WebApiDotnet8Challenge.Application;

public interface IUserService
{
    public bool UserAuthenticator(string userName, string password);
}