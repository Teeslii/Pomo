using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.Application.MinuteSetOperations.Command.DeleteMinuteSet
{
    public class DeleteMinuteSetCommand
    {
        public int Minute { get; set;}
        private readonly PomoDbContext _dbContext;
        public DeleteMinuteSetCommand(PomoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var minuteSet = _dbContext.MinuteSets.SingleOrDefault(x => x.Minute == Minute);

            if(minuteSet is null)
            {
                throw new AppException("This minute was not found.");
            }

            _dbContext.MinuteSets.Remove(minuteSet);
            _dbContext.SaveChanges();
        }
    }
}