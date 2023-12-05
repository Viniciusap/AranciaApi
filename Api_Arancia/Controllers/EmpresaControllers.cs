using Api_Arancia.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;
[ApiController]
[Route("[controller]")]

public class EmpresaController : ControllerBase
{
    private static readonly List<Empresa> empresas = new List<Empresa>();
    private static int id = 0;

    [HttpPost]
    public void AdicionaEmpresa([FromBody] Empresa empresa)
    {
        empresas.Add(empresa);
        Console.WriteLine(empresa.Nome);
    }
    

}
