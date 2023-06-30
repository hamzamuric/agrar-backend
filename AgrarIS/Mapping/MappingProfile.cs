using AgrarIS.Dtos;
using AgrarIS.Models;
using AutoMapper;
namespace AgrarIS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Parcela, ParcelaDto>().ReverseMap();
            CreateMap<Vocnjak, VocnjakDto>().ReverseMap();
            CreateMap<PoljoprivrednoDobro, PoljoprivrednoDobroDto>().ReverseMap();

        }
    }
}
