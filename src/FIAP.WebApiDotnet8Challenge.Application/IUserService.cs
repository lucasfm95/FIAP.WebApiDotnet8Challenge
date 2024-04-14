using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application;

public interface IUserService
{
    public List<User> GetAll();
    public User? UserAuthenticator(string userName, string password);
    public User? GetUserByUserName(string userName);
    public User AddUser(User user);
    public bool UpdateUser(User user);
    public bool DeleteUser(string userName);
}