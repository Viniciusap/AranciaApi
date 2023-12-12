using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Data.Dtos;

public class ReadProjetosDto
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public int DesenvolvedoresId { get; set; }
}
