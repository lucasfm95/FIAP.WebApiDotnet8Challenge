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
        if (!_userService.UserAuthenticator(request.UserName!, request.Password!))
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
                // new Claim(ClaimTypes.Name, usuario.Username),
                // new Claim(ClaimTypes.Role, (usuario.PermissaoSistema - 1).ToString()),
                new Claim("ClaimPersonalizada_1", "Nossa claim 1"),
                new Claim("ClaimPersonalizada_2", "Nossa claim 2")
            }),
            Expires = DateTime.UtcNow.AddHours(1), 
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenProperties);
        return tokenHandler.WriteToken(token);
    }
}