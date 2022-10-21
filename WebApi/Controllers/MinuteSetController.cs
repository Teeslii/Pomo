using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MinuteSetOperations.Queries;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinuteSetController : Controller 
    {
        private readonly IPomoDbContext _dbcontext;
        private readonly IMapper _mapper; 
        
        public MinuteSetController(IPomoDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetMinuteSets()
        {
            var query = new GetMinuteSetsQuery(_dbcontext, _mapper);
            
            var result = query.Handle();

            return Ok(result);
            
        }

    }
}