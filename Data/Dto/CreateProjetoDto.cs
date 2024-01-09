using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Data.Dto;

public class CreateProjetoDto
{
    [Required]
    public string Nome { get; set; }
    public int EmpresaId { get; set; }
    public int DesenvolvedorId {  get; set; }
}
