using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.MinuteSetOperations.Command;
using WebApi.Application.MinuteSetOperations.Queries;
using WebApi.Application.ProcessOperations.Command;
using WebApi.Application.ProcessOperations.Queries.GetProcessByUserId;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MinuteSet, MinuteSetsViewModel>();
            CreateMap<CreateMinuteSetsViewModel, MinuteSet>();
            CreateMap<CreateProcessViewModel, Process>();
            CreateMap<Process, GetProcessByUserIdViewModel>().ForMember(dest => dest.MinuteSet, opt => opt.MapFrom(src => src.MinuteSet.Minute));
        }
    }
  }