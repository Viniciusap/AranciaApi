using Arancia_Api.Data;
using Arancia_Api.Data.Dto;
using Arancia_Api.Modelos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arancia_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DesenvolvedorController : ControllerBase
{
    private EmpresaContext _context;
    private IMapper _mapper;

    public DesenvolvedorController(EmpresaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public IActionResult AdicionaDesenvolvedores([FromBody] CreateDesenvolvedorDto desenvolvedorDto)
    {
        Desenvolvedor desenvolvedor = _mapper.Map<Desenvolvedor>(desenvolvedorDto);
        _context.Desenvolvedor.Add(desenvolvedor);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaDesenvolvedorPorId), new { desenvolvedor.Id }, desenvolvedorDto);
    }

    [HttpGet]
    public IEnumerable<ReadDesenvolvedorDto> RecuperaDesenvolvedor()
    {
        return _mapper.Map<List<ReadDesenvolvedorDto>>(_context.Desenvolvedor.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaDesenvolvedorPorId(int id)
    {
        Desenvolvedor desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor != null)
        {
            ReadDesenvolvedorDto desenvolvedorDto = _mapper.Map<ReadDesenvolvedorDto>(desenvolvedor);
            return Ok(desenvolvedorDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaDesenvolvedor(int id, [FromBody] UpdateDesenvolvedorDto desenvolvedorDto)
    {
        Desenvolvedor desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor == null)
        {
            return NotFound();
        }
        _mapper.Map(desenvolvedorDto, desenvolvedor);
        _context.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id}")]
    public IActionResult DeletaDesenvolvedor(int id)
    {
        Desenvolvedor desenvolvedor = _context.Desenvolvedor.FirstOrDefault(desenvolvedor => desenvolvedor.Id == id);
        if (desenvolvedor == null)
        {
            return NotFound();
        }
        _context.Remove(desenvolvedor);
        _context.SaveChanges();
        return NoContent();
    }

}

