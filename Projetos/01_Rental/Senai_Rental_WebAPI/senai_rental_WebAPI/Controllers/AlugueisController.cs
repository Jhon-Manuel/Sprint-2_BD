using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using senai_rental_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class AlugueisController : ControllerBase
    {
        private IAlugueisRepository _alugueisRepository { get; set; }

        public AlugueisController()
        {
            _alugueisRepository = new AlugueisRepository();
        }

        [HttpPut]
        public IActionResult PutIdBody(Alugueis aluguelAtualizado)
        {
            Alugueis aluguelBuscado = _alugueisRepository.BuscarPorId(aluguelAtualizado.idCliente);

            if (aluguelBuscado != null)
            {
                try
                {
                    _alugueisRepository.AtualizarIdCorpo(aluguelBuscado);

                    return NoContent();
                }
                catch (Exception ErrorCode)
                {

                    BadRequest(ErrorCode);
                }
            }

            return NotFound(
                new
                {
                    mensagem = "Aluguel não encontrado!",
                    errorStatus = true
                }
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Alugueis aluguel = _alugueisRepository.BuscarPorId(id);

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult Post(Alugueis novoAluguel)
        {
            _alugueisRepository.Cadastrar(novoAluguel);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _alugueisRepository.Deletar(id);

            return NoContent();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Alugueis> listaAluguel = _alugueisRepository.ListarTodos();

            return Ok(listaAluguel);
        }
    }
}
