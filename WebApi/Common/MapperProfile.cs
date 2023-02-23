using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.ProcessOperations.Command;
using WebApi.Application.ProcessOperations.Queries.GetProcessByUserId;
using WebApi.Application.UserOperations.Command.CreateUser;
using WebApi.Application.UserOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateProcessViewModel, Process>();
            CreateMap<CreateUserViewModel, User>();
            CreateMap<User, GetUserQueryViewModel>().ForMember(dest => dest.processes, opt => opt.MapFrom(src => src.processes.ToList()));
            CreateMap<Process, GetUserQueryViewModel.ProcessVeiwModel>();

            CreateMap<Process, GetProcessByUserIdViewModel>();

        }
    }
  }