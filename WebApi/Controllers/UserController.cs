using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Application.UserOperations.Command.CreateUser;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserController(PomoDbContext dbContext, IMapper mapper)
        {
           _dbContext = dbContext;
           _mapper = mapper;
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

      
    }
}