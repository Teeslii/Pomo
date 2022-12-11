using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Command.RefreshToken
{
    public class RefreshTokenCommand
    {
        private readonly PomoDbContext _dbContext; 
        private readonly IConfiguration _configuration;
        public string RefreshToken { get; set;}
        public RefreshTokenCommand(PomoDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);

            if(user is null)
                throw new InvalidOperationException("A valid refresh token was not found.");

            TokenHandler handler = new TokenHandler(_configuration);

            Token token = handler.CreateAccessToken(user); // "?"

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(15); // "?"

            _dbContext.SaveChanges();

            return token;
        }

    }
}