using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ProcessOperations.Command
{
    public class CreateProcessCommand
    {
        public CreateProcessViewModel Model { get; set;}
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public CreateProcessCommand(PomoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void Handle()
        {
            var process = _mapper.Map<Process>(Model);
   
            process.StartTime = DateTime.Now;
            
            var minuteSet = _dbContext.MinuteSets.SingleOrDefault(command => command.Id == Model.MinuteSetId);
            double.TryParse(minuteSet.Minute.ToString(), out double minute);

            process.StartTime.AddMinutes(minute);

            process.StopTime = process.StartTime;

            _dbContext.Processes.Add(process);
            _dbContext.SaveChanges();
        }
        
    }
    public class CreateProcessViewModel 
    {
        public int MinuteTypeId { get; set;}
        public int MinuteSetId { get; set;}
        public Boolean IsCompleted  { get; set; }
        public int UserId { get; set; }
    }
}