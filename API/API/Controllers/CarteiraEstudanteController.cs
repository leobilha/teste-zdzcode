using API.Data;
using API.Data.Dtos;
using API.Models;
using API.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraEstudanteController : ControllerBase
    {
        private CarteiraContext _context;
        private IMapper _mapper;

        public CarteiraEstudanteController(CarteiraContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST /CarteiraEstudante
        [HttpPost]
        public IActionResult GerarCarteira([FromBody] CreateEstudanteDto estudanteDto)
        {
            try
            {
                Estudante estudante = _mapper.Map<Estudante>(estudanteDto);

                string imgCarteira = RegrasNegocio.GerarCarteiraEstudante(estudante);

                _context.CarteirasEstudante.Add(new Carteira {Nome = estudante.Nome, Matricula = estudante.Matricula, ImagemCarteira = imgCarteira });
                _context.SaveChanges();

                return CreatedAtAction(nameof(ConsultarCarteira), new { matricula = estudanteDto.Matricula }, null);
            }
            catch (Exception ex)
            {
                return NotFound(new MensagemRetorno { Status = "Erro", Message = ex.Message });
            }
        }

        // GET /CarteiraEstudante/123456
        [HttpGet("{matricula}")]
        public IActionResult ConsultarCarteira(string matricula)
        {
            var carteira = _context.CarteirasEstudante.FirstOrDefault(c => c.Matricula == matricula);

            if (carteira != null)
                return Ok(carteira);
                    

            return NotFound(new MensagemRetorno { Status = "Erro", Message = "Não foi encontrado carteira de estudante pelo numero de matricula " + matricula });
        }
    }
}
