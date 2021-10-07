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
    public class MarcasController : ControllerBase
    {
        private IMarcasrepository _marcasRepository { get; set; }

        public MarcasController()
        {
            _marcasRepository = new MarcasRepository();
        }

        [HttpPut]
        public IActionResult PutIdBody(Marcas marcaAtualizado)
        {
            Marcas clienteBuscado = _marcasRepository.BuscarPorId(marcaAtualizado.idMarca);

            if (clienteBuscado != null)
            {
                try
                {
                    _marcasRepository.AtualizarIdCorpo(marcaAtualizado);

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
                    mensagem = "Marca não encontrado!",
                    errorStatus = true
                }
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Marcas marca = _marcasRepository.BuscarPorId(id);

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult Post(Marcas novaMarca)
        {
            _marcasRepository.Cadastrar(novaMarca);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _marcasRepository.Deletar(id);

            return NoContent();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Marcas> listaMarca = _marcasRepository.ListarTodos();

            return Ok(listaMarca);
        }
    }
}
