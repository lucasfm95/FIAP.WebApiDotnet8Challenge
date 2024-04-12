using FIAP.WebApiDotnet8Challenge.Application;
using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Repositories.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new List<User>
    {
        new()
        {
            Name = "Lucas",
            UserName = "lucas",
            Password = "123456"
        }
    };
    
    public User? GetUserByUserName(string userName)
    {
        return _users.FirstOrDefault(user => user.UserName == userName);
    }
}