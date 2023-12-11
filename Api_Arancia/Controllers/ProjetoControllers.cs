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
    public IActionResult AdicionaProjeto([FromBody] CreateProjetosDto ProjetosDto)
    {
        Projetos Projeto = _mapper.Map<Projetos>(ProjetosDto);
        _context.Projetos.Add(Projeto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProjetosPorId), new { Id = Projeto.Id }, ProjetosDto);
    }

    [HttpGet]
    public IEnumerable<ReadProjetosDto> RecuperaProjetos()
    {
        return _mapper.Map<List<ReadProjetosDto>>(_context.Projetos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProjetosPorId(int id)
    {
        Projetos Projeto = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
        if (Projeto != null)
        {
            ReadProjetosDto ProjetosDto = _mapper.Map<ReadProjetosDto>(Projeto);
            return Ok(ProjetosDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaProjeto(int id, [FromBody] UpdateProjetosDto ProjetosDto)
    {
        Projetos Projetos = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
        if (Projetos == null)
        {
            return NotFound();
        }
        _mapper.Map(ProjetosDto, Projetos);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaProjetos(int id)
    {
        Projetos Projeto = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
        if (Projeto == null)
        {
            return NotFound();
        }
        _context.Remove(Projeto);
        _context.SaveChanges();
        return NoContent();
    }

}

