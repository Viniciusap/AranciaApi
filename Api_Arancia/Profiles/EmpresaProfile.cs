﻿using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<CreateEmpresaDto, Empresa>();
        CreateMap<Empresa, ReadEmpresaDto>()
            .ForMember(empresaDto => empresaDto.Projetos,
            opt => opt.MapFrom(empresa => empresa.Projetos));
        CreateMap<UpdateEmpresaDto, Empresa>();
      
        
    }
    
}
