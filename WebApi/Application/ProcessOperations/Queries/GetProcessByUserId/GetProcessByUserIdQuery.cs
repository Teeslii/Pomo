using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.ProcessOperations.Queries.GetProcessByUserId
{
    public class GetProcessByUserIdQuery
    {
        public int UserId {get; set;}
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetProcessByUserIdQuery(PomoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetProcessByUserIdViewModel> Handler()
        {
            var process = _dbContext.Processes.Include(x => x.MinuteSet).Include(x => x.User).Where(x => x.UserId == UserId);
             
            

            var mappingProcess = _mapper.Map<List<GetProcessByUserIdViewModel>>(process);   

            return mappingProcess;
           
        }
    }
    public class GetProcessByUserIdViewModel
    {
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string MinuteType { get; set;}
        public int MinuteSet { get; set;}
        public Boolean IsCompleted  { get; set; }
    }
}