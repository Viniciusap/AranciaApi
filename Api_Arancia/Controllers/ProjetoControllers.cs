using Api_Arancia.Data.Dtos;
using Api_Arancia.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api_Arancia.Controllers;

public class ProjetoControllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProjetosController : ControllerBase
    {
        private EmpresaContext _context;
        private IMapper _mapper;

        public ProjetoController(EmpresaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaProjeto([FromBody] CreateProjetoDto ProjetoDto)
        {
            Projeto Projeto = _mapper.Map<Projeto>(ProjetoDto);
            _context.Projetos.Add(Projeto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaProjetosPorId), new { Id = Projeto.Id }, ProjetoDto);
        }

        [HttpGet]
        public IEnumerable<ReadProjetoDto> RecuperaProjetos()
        {
            return _mapper.Map<List<ReadProjetoDto>>(_context.Projetos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaProjetosPorId(int id)
        {
            Projeto Projeto = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
            if (Projeto != null)
            {
                ReadProjetoDto ProjetoDto = _mapper.Map<ReadProjetoDto>(Projeto);
                return Ok(ProjetoDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaProjeto(int id, [FromBody] UpdateProjetoDto projetoDto)
        {
            Projeto projeto = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
            if (Projeto == null)
            {
                return NotFound();
            }
            _mapper.Map(ProjetoDto, Projeto);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaProjeto(int id)
        {
            Projeto Projeto = _context.Projetos.FirstOrDefault(Projeto => Projeto.Id == id);
            if (Projeto == null)
            {
                return NotFound();
            }
            _context.Remove(Projeto);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
