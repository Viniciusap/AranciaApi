using Arancia_Api.Modelos;

namespace Arancia_Api.Data.Dto;

public class ReadEmpresaDto
{
    public string Nome { get; set; }

    public virtual ICollection<Projeto> Projeto { get; set; }
}
