using AutoMapper;
using Magic_Villa_Web.Domain.Models.DTO;

namespace Magic_Villa_Web.Domain.Mapping;

public class VillaDTOMapper : Profile
{
    public VillaDTOMapper()
    {
        CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
        CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

        CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
        CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
    }
}
