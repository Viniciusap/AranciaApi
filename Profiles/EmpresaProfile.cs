using Arancia_Api.Data.Dto;
using Arancia_Api.Modelos;
using AutoMapper;

namespace Arancia_Api.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<CreateEmpresaDto, Empresa>();
        CreateMap<Empresa, ReadEmpresaDto>()
            .ForMember(empresaDto => empresaDto.Projeto,
            opt => opt.MapFrom(empresa => empresa.Projeto));
        CreateMap<UpdateEmpresaDto, Empresa>();
        
    }
}
