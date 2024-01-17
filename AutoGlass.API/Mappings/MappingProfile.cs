using AutoGlass.API.DTOs;
using AutoMapper;

namespace AutoGlass.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Ativo == true ? "Ativo" : "Inativo")).
                ReverseMap();
        }
    }
}
