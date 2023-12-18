using Api_Arancia.Data.Dtos;
using Api_Arancia.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Api_Arancia.Modelos;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]

public class ProjetosController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public ProjetosController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaProjeto(CreateProjetosDto ProjetosDto)
    {
        Projetos projeto = _mapper.Map<Projetos>(ProjetosDto);
        _context.Projetos.Add(projeto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProjetosPorId),
            new { empresaId = projeto.EmpresaId, desenvolvedoresId = projeto.DesenvolvedoresId }, projeto);
    }

    [HttpGet]
    public IEnumerable<ReadProjetosDto> RecuperaProjetos()
    {
        return _mapper.Map<List<ReadProjetosDto>>(_context.Projetos.ToList());
    }

    [HttpGet("{empresaId}/{desenvolvedoresId}")]
    public IActionResult RecuperaProjetosPorId(int empresaId, int desenvolvedoresId)
    {
        var projeto = _context.Projetos.FirstOrDefault
            (projeto => projeto.EmpresaId == empresaId && projeto.DesenvolvedoresId == desenvolvedoresId);
        if (projeto != null)
        {
            ReadProjetosDto ProjetosDto = _mapper.Map<ReadProjetosDto>(projeto);
            return Ok(ProjetosDto);
        }
        return NotFound();
    }

    [HttpPut("{empresaId}/{desenvolvedoresId}")]
    public IActionResult AtualizaProjeto(int empresaId, int desenvolvedoresId, [FromBody] UpdateProjetosDto ProjetosDto)
    {
        var projetos = _context.Projetos
            .FirstOrDefault(projeto => projeto.EmpresaId == empresaId && projeto.DesenvolvedoresId == desenvolvedoresId);
        if (projetos == null) return NotFound();
        _mapper.Map(ProjetosDto, projetos);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{empresaId}/{desenvolvedoresId}")]
    public IActionResult DeletaProjetos(int empresaId, int desenvolvedoresId)
    {
        var projeto = _context.Projetos.FirstOrDefault(projeto => projeto.EmpresaId == empresaId && projeto.DesenvolvedoresId == desenvolvedoresId);
        if (projeto == null) return NotFound();
        _context.Remove(projeto);
        _context.SaveChanges();
        return NoContent();
    }

}

