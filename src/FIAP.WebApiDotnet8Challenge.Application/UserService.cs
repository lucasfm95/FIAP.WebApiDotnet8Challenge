namespace FIAP.WebApiDotnet8Challenge.Application;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
}