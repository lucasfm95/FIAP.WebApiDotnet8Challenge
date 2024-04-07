using System.ComponentModel.DataAnnotations;

namespace FIAP.WebApiDotnet8Challenge.Domain.Request;

public class TokenPostRequest
{
    [Required]
    public string? UserName { get; set; }
    [Required]
    public string? Password { get; set; }
}