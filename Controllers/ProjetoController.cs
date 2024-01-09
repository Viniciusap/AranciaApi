using Arancia_Api.Data.Dto;
using Arancia_Api.Data;
using Arancia_Api.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arancia_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProjetoController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public ProjetoController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaProjeto(CreateProjetoDto projetoDto)
    {
        Projeto projeto = _mapper.Map<Projeto>(projetoDto);
        _context.Projeto.Add(projeto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProjeto),
            new { projeto.Id , empresaId = projeto.EmpresaId, desenvolvedorId = projeto.DesenvolvedorId}, projeto);
    }

    [HttpGet]
    public IEnumerable<ReadProjetoDto> RecuperaProjeto()
    {
        return _mapper.Map<List<ReadProjetoDto>>(_context.Projeto.ToList());
        
    }

    [HttpGet("{empresaId}")]
    public IActionResult RecuperaProjetoPorId(int Id)
    {
        var projeto = _context.Projeto.FirstOrDefault(projeto => projeto.Id == Id );
        if (projeto != null)
        {
            ReadProjetoDto projetoDto = _mapper.Map<ReadProjetoDto>(projeto);

            return Ok(projetoDto);
        }
        return NotFound();
    }



    [HttpDelete("{id}")]
    public IActionResult DeletaProjeto(int Id)
    {
        Projeto projeto = _context.Projeto.FirstOrDefault(projeto => projeto.Id == Id);
        if (projeto == null)
        {
            return NotFound();
        }
        _context.Remove(projeto);
        _context.SaveChanges();
        return NoContent();
    }
}
