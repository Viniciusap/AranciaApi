using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Data.Dto;

public class CreateEmpresaDto
{
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    [StringLength(100)]
    public string Nome { get; set; }
}
