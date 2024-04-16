using System.ComponentModel.DataAnnotations;

namespace FIAP.WebApiDotnet8Challenge.Domain.Request;

public class UserPutRequest
{
    [Required]
    public string? Password { get; set; }
}