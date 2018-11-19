using AutoMapper;
using Storage.Model.Entities;
using Storage.Service.Dtos.LoginHistory;

namespace Storage.Service.Mapper
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Asset, Asset>();
        }
    }
}