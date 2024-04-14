using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FIAP.WebApiDotnet8Challenge.Domain.Request;
using Microsoft.IdentityModel.Tokens;

namespace FIAP.WebApiDotnet8Challenge.Application;

public class TokenService : ITokenService
{
    private readonly IUserService _userService;

    public TokenService(IUserService userService)
    {
        _userService = userService;
    }

    public string? GetToken(TokenPostRequest request)
    {
        var user = _userService.UserAuthenticator(request.UserName!, request.Password!);
        
        if (user == null)
        {
            return null;
        }
        
        var tokenHandler = new JwtSecurityTokenHandler(); 
        
        var tokenKey = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("TOKEN_SECRET_KEY") 
                                                        ?? throw new Exception($"TOKEN_SECRET_KEY environment variable not found."));
        
        var tokenProperties = new SecurityTokenDescriptor() 
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.PermissionLevel.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1), 
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenProperties);
        return $"Bearer {tokenHandler.WriteToken(token)}";
    }
}