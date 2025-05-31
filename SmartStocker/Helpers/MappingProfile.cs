using AutoMapper;
using SmartStocker.Models.DTOs;
using SmartStocker.Models.Entities;

namespace SmartStocker.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DTOCreateProduct, Product>();
            CreateMap<Product, DTOCreateProduct>();
        }
    }
}
