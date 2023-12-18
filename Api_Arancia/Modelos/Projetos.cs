using System.ComponentModel.DataAnnotations;

namespace Api_Arancia.Modelos;

public class Projetos
{

    public int? EmpresaId {  get; set; }
    public virtual Empresa Empresa {  get; set; }


    public int? DesenvolvedoresId { get; set; }

    public virtual Desenvolvedores Desenvolvedores { get; set; }
 
}
