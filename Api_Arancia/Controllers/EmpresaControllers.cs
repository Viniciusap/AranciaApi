using Api_Arancia.Data;
using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;
[ApiController]
[Route("[controller]")]

public class EmpresaController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;
    
    public EmpresaController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaEmpresa([FromBody] Empresa empresaDto)
    {
        Empresa empresa = _mapper.Map<Empresa>(empresaDto);
        _context.Empresa.Add(empresa);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaEmpresaPorId), new {id = empresa.Id}, empresa);
       
    }

    [HttpGet]
    public IEnumerable<ReadEmpresaDto> RecuperaEmpresas([FromQuery] int skip =0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadEmpresaDto>>(_context.Empresa.Skip(skip).Take(take));
    }
      

    [HttpGet("{id}")]
    public IActionResult RecuperaEmpresaPorId(int id)
    {
        var empresa = _context.Empresa.FirstOrDefault(empresa => empresa.Id == id);
        if (empresa == null) return NotFound();
        var empresaDto = _mapper.Map<ReadEmpresaDto>(empresa);
        return Ok(empresaDto);
    }
}
