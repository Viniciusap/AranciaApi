using System.ComponentModel.DataAnnotations;

namespace Arancia_Api.Modelos;

public class Projeto
{
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public int EmpresaId {  get; set; }
    public virtual Empresa Empresa { get; set; }

    public int DesenvolvedorId {  get; set; }
    public virtual Desenvolvedor Desenvolvedor { get; set; }
}
