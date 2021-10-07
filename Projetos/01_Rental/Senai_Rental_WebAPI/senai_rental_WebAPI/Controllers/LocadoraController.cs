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
    public class LocadoraController : ControllerBase
    {
        private ILocadorasRepository _locadorasRepository { get; set; }

        public LocadoraController()
        {
            _locadorasRepository = new LocadorasRepository();
        }

        [HttpPut]
        public IActionResult PutIdBody(Locadoras locadoraAtualizado)
        {
            Locadoras locadoraBuscado = _locadorasRepository.BuscarPorId(locadoraAtualizado.idLocadora);

            if (locadoraBuscado != null)
            {
                try
                {
                    _locadorasRepository.AtualizarIdCorpo(locadoraAtualizado);

                    return NoContent();
                }
                catch (Exception codErro)
                {

                    return BadRequest(codErro);
                }
            }
            return NotFound(
                new
                {
                    mensagem = "Locadora não encontrado!",
                    errorStatus = true
                }
             );
           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Locadoras locadora = _locadorasRepository.BuscarPorId(id);

            if (locadora == null)
            {
                return NotFound("Nenhuma locadora encontrada!");
            }

            return Ok(locadora);
        }

        [HttpPost]
        public IActionResult Post(Locadoras novaLocadora)
        {
            _locadorasRepository.Cadastrar(novaLocadora);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _locadorasRepository.Deletar(id);

            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Locadoras> listaLocadoras = _locadorasRepository.ListarTodos();

            return Ok(listaLocadoras);

        }

    }
}
