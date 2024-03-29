using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApi.Entities;
using WebApi.TokenOperations.Models;
using Microsoft.Extensions.Configuration;

namespace WebApi.TokenOperations
{
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            Token tokenModel = new Token();

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            tokenModel.Expiration = DateTime.Now.AddMinutes(30);

            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires: tokenModel.Expiration,
                notBefore: DateTime.Now,
                signingCredentials: credentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken = CreateRefreshToken();

            return tokenModel;
        }
        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }


}