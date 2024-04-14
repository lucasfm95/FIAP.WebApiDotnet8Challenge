using System.ComponentModel.DataAnnotations;

namespace FIAP.WebApiDotnet8Challenge.Domain.Request;

public class UserPostRequest
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
    [Required]
    public ePermissionLevel PermissionLevel { get; set; }   
}