﻿namespace Api_Arancia.Data.Dtos;

public class ReadEmpresaDto
{
    public string Nome { get; set; }

    public ICollection<ReadProjetosDto> Projetos { get; set;}
}
