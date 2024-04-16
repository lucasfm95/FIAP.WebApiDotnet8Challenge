namespace FIAP.WebApiDotnet8Challenge.Domain;

public class User
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
    public required string Name { get; set; }
    public ePermissionLevel PermissionLevel { get; set; }
}