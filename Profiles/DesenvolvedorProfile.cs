using Arancia_Api.Data.Dto;
using Arancia_Api.Modelos;
using AutoMapper;

namespace Arancia_Api.Profiles;

public class DesenvolvedorProfile : Profile
{
    public DesenvolvedorProfile()
    {
        CreateMap<CreateDesenvolvedorDto, Desenvolvedor>();
        CreateMap<Desenvolvedor, ReadDesenvolvedorDto>();
        CreateMap<UpdateDesenvolvedorDto, Desenvolvedor>();
    }
}

