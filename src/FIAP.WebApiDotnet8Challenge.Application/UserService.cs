using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public List<User> GetAll()
    {
        return _userRepository.FindAll();
    }

    public bool UserAuthenticator(string userName, string password)
    {
        var user = _userRepository.GetUserByUserName(userName);

        if (user != null && user.Password == password)
        {
            return true;
        }
        
        return false;
    }

    public User? GetUserByUserName(string userName)
    {
        return _userRepository.GetUserByUserName(userName);
    }

    public User AddUser(User user)
    {
        return _userRepository.AddUser(user);
    }

    public bool UpdateUser(User user)
    {
        return _userRepository.UpdateUser(user);
    }

    public bool DeleteUser(string userName)
    {
        return _userRepository.DeleteUser(userName);
    }
}