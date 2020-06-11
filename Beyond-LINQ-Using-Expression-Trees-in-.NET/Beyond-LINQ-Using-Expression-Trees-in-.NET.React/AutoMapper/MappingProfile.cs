using AutoMapper;
using Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Models;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListDto>()
                .ForMember(x => x.Id, x => x.MapFrom(src => src.Id))
                .ForMember(x => x.Name, x => x.MapFrom(src => src.Name))
                .ForMember(x => x.Price, x => x.MapFrom(src => src.Price))
                .ForMember(x => x.CategoryName, x => x.MapFrom(src => src.Category.Name));
        }
    }
}
