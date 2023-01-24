using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DBOperations;

namespace WebApi.Application.UserOperations.Command.DeleteUser
{
    public class DeleteUserCommand
    {
        public int UserId { get; set; }

        private readonly PomoDbContext _dbContext;

        public DeleteUserCommand(PomoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == UserId);

            if(user is null)
               throw new InvalidOperationException("The user was not found.");

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}