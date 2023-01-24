using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.UserOperations.Queries
{
    public class GetUserQuery
    {
        public int UserId { get; set; }
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserQuery(PomoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
         
        public GetUserQueryViewModel Handle()
        {
            var user = _dbContext.Users.Include(x => x.processes).SingleOrDefault(query => query.Id == UserId);
            if(user is null)
                 throw new InvalidOperationException("The user you are looking for was not found.");

            GetUserQueryViewModel userViewModel = _mapper.Map<GetUserQueryViewModel>(user);

            return userViewModel;
        }

        
    }

    public class GetUserQueryViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<ProcessVeiwModel> processes { get; set; }

        public class ProcessVeiwModel
        {
            public int Id { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string MinuteType { get; set;}
            public int MinuteSet { get; set;}
            public Boolean IsCompleted  { get; set; }
        }
    } 
}