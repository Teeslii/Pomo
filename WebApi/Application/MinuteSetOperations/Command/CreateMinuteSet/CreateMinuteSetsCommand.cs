using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Common;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MinuteSetOperations.Command
{
   
    public class CreateMinuteSetsCommand
    {
         private readonly PomoDbContext _dbContext;
         private readonly IMapper _mapper;
         public CreateMinuteSetsViewModel viewModel { get; set; }
         public CreateMinuteSetsCommand(PomoDbContext dbContext, IMapper mapper)
         {
            _dbContext = dbContext;
            _mapper = mapper;
         }

         public void Handle()
         {
            var minuteSets = _dbContext.MinuteSets.SingleOrDefault(command => command.Minute == viewModel.Minute);

            if(minuteSets is not null)
            {
                throw new AppException("This minute has already been added.");
            }

            minuteSets = new MinuteSet();
            minuteSets.Minute = viewModel.Minute;

            _dbContext.MinuteSets.Add(minuteSets);
            _dbContext.SaveChanges();

         }
    }

    public class CreateMinuteSetsViewModel
    {
        public int Minute { get; set; }
    }
}