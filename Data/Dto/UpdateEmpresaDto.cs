using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Data.Dto;

public class UpdateEmpresaDto
{
    [Required(ErrorMessage = "O nome da empresa é obrigatório")]
    [StringLength(100)]
    public string Nome { get; set; }
}
