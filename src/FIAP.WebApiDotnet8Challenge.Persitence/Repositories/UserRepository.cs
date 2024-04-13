using FIAP.WebApiDotnet8Challenge.Application;
using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Repositories.Repositories;

public class UserRepository : IUserRepository
{
    private readonly List<User> _users = new()
    {
        new()
        {
            Name = "Lucas",
            UserName = "lucas",
            Password = "123456"
        }
    };

    public List<User> FindAll()
    {
        return _users;
    }

    public User? GetUserByUserName(string userName)
    {
        return _users.FirstOrDefault(user => user.UserName == userName);
    }

    public User AddUser(User user)
    {
        _users.Add(user);
        return user;
    }

    public bool UpdateUser(User user)
    {
        var userIndex = _users.FindIndex(u => u.UserName == user.UserName);
        if (userIndex == -1)
        {
            return false;
        }

        _users[userIndex] = user;
        return true;
    }

    public bool DeleteUser(string userName)
    {
        var userIndex = _users.FindIndex(u => u.UserName == userName);
        if (userIndex == -1)
        {
            return false;
        }

        _users.RemoveAt(userIndex);
        return true;
    }
}