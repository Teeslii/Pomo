using WebApi.Entities;
using WebApi.TokenOperations.Models;

namespace WebApi.TokenOperations
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(User user);
        string CreateRefreshToken();
    }
}