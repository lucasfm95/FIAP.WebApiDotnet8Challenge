using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application;

public interface IUserRepository
{
    public User? GetUserByUserName(string userName);
}