using AutoMapper;
using EyAuthServer.Core.Dtos;
using EyAuthServer.Core.Models;

namespace EyAuthServer.Service
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();

        }
    }
}
