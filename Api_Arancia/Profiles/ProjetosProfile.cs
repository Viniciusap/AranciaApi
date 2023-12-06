
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class ProjetosProfile : Profile
{
    public ProjetosProfile() 
    {
        CreateMap<CreateProjetosDto, Projetos>();
        CreateMap<UpdateProjetosDto, Projetos>();
        CreateMap<Projetos, UpdateProjetosDto>();
        CreateMap<Projetos, ReadProjetosDto>();
    }
}
