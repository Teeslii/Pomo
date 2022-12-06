using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.UserOperations.Command.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserViewModel viewModel { get; set;}
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper; 
        public CreateUserCommand(PomoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.UserName == viewModel.UserName);

            if(user is not null)
               throw new InvalidOperationException("The user you are trying to add already exists.");

            user = _mapper.Map<User>(viewModel);

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();
        }
    }
    public class CreateUserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}