using FIAP.WebApiDotnet8Challenge.Domain;
using FIAP.WebApiDotnet8Challenge.Domain.Request;

namespace FIAP.WebApiDotnet8Challenge.Application;

public interface IUserService
{
    public List<User> GetAll();
    public User? UserAuthenticator(string userName, string password);
    public User? GetUserByUserName(string userName);
    public User AddUser(UserPostRequest request);
    public bool UpdateUser(string userName, UserPutRequest request);
    public bool DeleteUser(string userName);
}