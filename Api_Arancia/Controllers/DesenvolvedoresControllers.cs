using Api_Arancia.Data.Dtos;
using Api_Arancia.Data;
using Api_Arancia.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

[ApiController]
[Route("[controller]")]

public class DesenvolvedoresController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public DesenvolvedoresController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult AdicionaDesenvolvedores([FromBody] CreateDesenvolvedoresDto DesenvolvedoresDto)
    {
        Desenvolvedores Desenvolvedor = _mapper.Map<Desenvolvedores>(DesenvolvedoresDto);
        _context.Desenvolvedores.Add(Desenvolvedor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaDesenvolvedoresPorId), new { Id = Desenvolvedor.Id }, DesenvolvedoresDto);
    }

    [HttpGet]
    public IEnumerable<ReadDesenvolvedoresDto> RecuperaDesenvolvedores()
    {
        return _mapper.Map<List<ReadDesenvolvedoresDto>>(_context.Desenvolvedores.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaDesenvolvedoresPorId(int id)
    {
        Desenvolvedores Desenvolvedor = _context.Desenvolvedores.FirstOrDefault(Desenvolvedor => Desenvolvedor.Id == id);
        if (Desenvolvedor != null)
        {
            ReadDesenvolvedoresDto DesenvolvedoresDto = _mapper.Map<ReadDesenvolvedoresDto>(Desenvolvedor);
            return Ok(DesenvolvedoresDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDesenvolvedor(int id, [FromBody] UpdateDesenvolvedoresDto DesenvolvedoresDto)
    {
        Desenvolvedores Desenvolvedores = _context.Desenvolvedores.FirstOrDefault(Desenvolvedor => Desenvolvedor.Id == id);
        if (Desenvolvedores == null)
        {
            return NotFound();
        }
        _mapper.Map(DesenvolvedoresDto, Desenvolvedores);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaDesenvolvedores(int id)
    {
        Desenvolvedores Desenvolvedor = _context.Desenvolvedores.FirstOrDefault(Desenvolvedor => Desenvolvedor.Id == id);
        if (Desenvolvedor == null)
        {
            return NotFound();
        }
        _context.Remove(Desenvolvedor);
        _context.SaveChanges();
        return NoContent();
    }

}
