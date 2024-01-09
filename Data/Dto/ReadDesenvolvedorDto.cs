using Arancia_Api.Modelos;

namespace Arancia_Api.Data.Dto;

public class ReadDesenvolvedorDto
{
    public int Id { get; set; }
    public string Nome { get; set; }

    public virtual ICollection<Projeto> Projeto { get; set; }
}
