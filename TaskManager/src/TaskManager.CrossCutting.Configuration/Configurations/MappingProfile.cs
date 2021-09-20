using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Domain.Entities;
using TaskManager.Service.Dtos;

namespace TaskManager.CrossCutting.Configuration.Configurations
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {

            CreateMap<TaskEntity, TaskDto>()
                .ReverseMap()
                .ForMember(x => x.CreatedAt, o => o.MapFrom(m => DateTimeOffset.UtcNow.ToUnixTimeSeconds()))
                .ForMember(x => x.Id, o => o.MapFrom(m => Guid.NewGuid()));

        }
    }
}

