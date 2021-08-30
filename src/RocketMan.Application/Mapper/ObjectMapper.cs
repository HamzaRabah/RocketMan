using System;
using AutoMapper;
using RocketMan.Application.Models;
using RocketMan.Core.Entities;

namespace RocketMan.Application.Mapper
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<RocketManMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }

    public class RocketManMapper : Profile
    {
        public RocketManMapper()
        {
            CreateMap<Launch, LaunchModel>().ReverseMap();
        }
    }
}