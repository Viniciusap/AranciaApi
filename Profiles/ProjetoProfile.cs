using Arancia_Api.Data.Dto;
using Arancia_Api.Modelos;
using AutoMapper;

namespace Arancia_Api.Profiles;

public class ProjetoProfile : Profile
{
    public ProjetoProfile()
    {
        CreateMap<CreateProjetoDto, Projeto>();
        CreateMap<Projeto, ReadProjetoDto>();
        CreateMap<UpdateProjetoDto, Projeto>();
    }
}
