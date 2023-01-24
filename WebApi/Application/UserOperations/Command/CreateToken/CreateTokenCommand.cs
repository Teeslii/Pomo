using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.TokenOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Application.UserOperations.Command.CreateToken
{
    public class CreateTokenCommand
    {
        private readonly PomoDbContext _dbContext; 
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public CreateTokenViewModel ViewModel { get; set;}
        public CreateTokenCommand(PomoDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        //repository pattern
        public Token Handle()
        {
            var user = _dbContext.Users.FirstOrDefault( x => x.UserName == ViewModel.UserName &&  x.Password == ViewModel.Password);

            if(user is null)
                   throw new InvalidOperationException("Username and password are incorrect.");

            var handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);
            
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(15);

            _dbContext.SaveChanges();

            return token;
        }

    }

    public class CreateTokenViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}