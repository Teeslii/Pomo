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
            
            double.TryParse(process.MinuteSet.ToString(), out double minute);
            
            process.EndTime = process.StartTime;
            
            process.EndTime = process.EndTime.AddMinutes(minute);

            _dbContext.Processes.Add(process);
            _dbContext.SaveChanges();
        }
        
    }
    public class CreateProcessViewModel 
    {
        public MinuteType MinuteType { get; set;}
        public int MinuteSet { get; set;}
        public int UserId { get; set; }
    }
}