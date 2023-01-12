using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Application.UserOperations.Command.CreateToken;
using WebApi.Application.UserOperations.Command.CreateUser;
using WebApi.Application.UserOperations.Command.DeleteUser;
using WebApi.Application.UserOperations.Command.RefreshToken;
using WebApi.Application.UserOperations.Queries;
using WebApi.DBOperations;
using WebApi.TokenOperations.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserController(PomoDbContext dbContext, IMapper mapper , IConfiguration configuration)
        {
           _dbContext = dbContext;
           _mapper = mapper;
           _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserViewModel newUser)
        {
            var command = new CreateUserCommand(_dbContext, _mapper);
            command.viewModel = newUser;
            
            CreateUserCommandValidator validations = new CreateUserCommandValidator();
            validations.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(int userId)
        {
            var command = new DeleteUserCommand(_dbContext);
            command.UserId = userId;

            var validations = new DeleteUserCommandValidator();
            validations.ValidateAndThrow(command);

             command.Handle();

            return Ok();
        }

        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var query = new GetUserQuery(_dbContext, _mapper);
            query.UserId = userId;

            var result = query.Handle();

            return Ok(result);
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> LoginUser([FromBody] CreateTokenViewModel login)
        {
            CreateTokenCommand command = new CreateTokenCommand(_dbContext, _mapper, _configuration);
            command.ViewModel = login;

            CreateTokanCommandValidator validations = new CreateTokanCommandValidator();
            validations.ValidateAndThrow(command);

            var token = command.Handle();

            return token;
        }

        [HttpGet("refreshToken")]
        public ActionResult<Token> RefreshToken([FromBody] string token)
        {
             RefreshTokenCommand command = new RefreshTokenCommand(_dbContext, _configuration);
             command.RefreshToken = token;

             var resultToken = command.Handle();
            
             return resultToken;
        }
    }
}