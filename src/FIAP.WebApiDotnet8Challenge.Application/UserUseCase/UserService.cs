using FIAP.WebApiDotnet8Challenge.Domain;
using FIAP.WebApiDotnet8Challenge.Domain.Request;

namespace FIAP.WebApiDotnet8Challenge.Application.UserUseCase;

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

    public User? UserAuthenticator(string userName, string password)
    {
        var user = _userRepository.GetUserByUserName(userName);

        if (user != null && user.Password == password)
        {
            return user;
        }
        
        return null;
    }

    public User? GetUserByUserName(string userName)
    {
        return _userRepository.GetUserByUserName(userName);
    }

    public User AddUser(UserPostRequest request)
    {
        var user = new User
        {
            Name = request.Name!,
            UserName = request.UserName!.ToLower(),
            Password = request.Password!,
            PermissionLevel = request.PermissionLevel
        };
        
        return _userRepository.AddUser(user);
    }

    public bool UpdateUser(string userName, UserPutRequest request)
    {
        var user = _userRepository.GetUserByUserName(userName);
        
        if (user == null)
        {
            return false;
        }
        
        user.Password = request.Password!;
        
        return _userRepository.UpdateUser(user);
    }

    public bool DeleteUser(string userName)
    {
        return _userRepository.DeleteUser(userName);
    }
}