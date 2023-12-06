using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class DesenvolvedoresProfile : Profile
{
    public DesenvolvedoresProfile()
    {
        CreateMap<CreateDesenvolvedoresDto, Desenvolvedores>();
        CreateMap<UpdateDesenvolvedoresDto, Desenvolvedores>();
        CreateMap<Desenvolvedores, UpdateDesenvolvedoresDto>();
        CreateMap<Desenvolvedores, ReadDesenvolvedoresDto>();
    }
}
