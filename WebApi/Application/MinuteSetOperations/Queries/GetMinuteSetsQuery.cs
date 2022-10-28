using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.MinuteSetOperations.Queries
{
    public class GetMinuteSetsQuery
    {
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMinuteSetsQuery(PomoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<MinuteSetsViewModel> Handle()
        {
             var minuteSets = _dbContext.MinuteSets.OrderBy(x => x.Id);

             List<MinuteSetsViewModel> minuteSetsViewModel = _mapper.Map<List<MinuteSetsViewModel>>(minuteSets);

             return minuteSetsViewModel;
            
        }
    }

    public class MinuteSetsViewModel
    {
        public int Id { get; set; }
        public int Minute { get; set; }
    }
}