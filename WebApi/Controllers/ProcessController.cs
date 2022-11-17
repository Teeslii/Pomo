using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ProcessOperations.Command;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessController : Controller
    {
        private readonly PomoDbContext _dbContext;
        private readonly IMapper _mapper; 
        
        public ProcessController(PomoDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        
        [HttpPost]
        public IActionResult CreateProcess([FromBody] CreateProcessViewModel model)
        {
            CreateProcessCommand command = new CreateProcessCommand(_dbContext, _mapper);
            command.Model = model;

            CreateProcessCommandValidator validator = new CreateProcessCommandValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            
            return Ok();
        }

    }
}