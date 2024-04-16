using FIAP.WebApiDotnet8Challenge.Domain.Request;

namespace FIAP.WebApiDotnet8Challenge.Application;

public interface ITokenService
{
    public string? GetToken(TokenPostRequest request);
}