using AutoMapper;
using RocketMan.Application.Models;
using RocketMan.Web.ViewModels;

namespace RocketMan.Web.Mapper
{
    public class RocketManProfile : Profile
    {
        public RocketManProfile()
        {
            CreateMap<LaunchModel, LaunchViewModel>().ReverseMap();
        }
    }
}