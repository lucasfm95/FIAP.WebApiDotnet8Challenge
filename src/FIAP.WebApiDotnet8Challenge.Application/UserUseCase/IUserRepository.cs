using FIAP.WebApiDotnet8Challenge.Domain;

namespace FIAP.WebApiDotnet8Challenge.Application.UserUseCase;

public interface IUserRepository
{
    public List<User> FindAll();
    public User? GetUserByUserName(string userName);
    public User AddUser(User user);
    public bool UpdateUser(User user);
    public bool DeleteUser(string userName);
}