using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Application.MinuteSetOperations.Command;
using WebApi.Application.MinuteSetOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MinuteSet, MinuteSetsViewModel>();
            CreateMap<CreateMinuteSetsViewModel, MinuteSet>();
        }
    }
}