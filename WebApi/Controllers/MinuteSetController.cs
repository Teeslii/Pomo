using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.MinuteSetOperations.Command;
using WebApi.Application.MinuteSetOperations.Command.CreateMinuteSet;
using WebApi.Application.MinuteSetOperations.Queries;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MinuteSetController : Controller 
    {
        private readonly PomoDbContext _dbcontext;
        private readonly IMapper _mapper; 
        
        public MinuteSetController(PomoDbContext dbContext, IMapper mapper)
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

        [HttpPost]
        public IActionResult CreateMinuteSets([FromBody] CreateMinuteSetsViewModel model)
        {
            CreateMinuteSetsCommand command = new CreateMinuteSetsCommand(_dbcontext, _mapper);
            command.viewModel = model;

            CreateMinuteSetCommandValidator validator = new CreateMinuteSetCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();

            return Ok();
        }

    }
}