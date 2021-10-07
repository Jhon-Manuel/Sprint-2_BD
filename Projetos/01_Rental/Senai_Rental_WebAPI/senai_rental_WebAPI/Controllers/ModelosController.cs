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
    public class ModelosController : ControllerBase
    {
        private IModelosRepository _modelosRepository { get; set; }

        public ModelosController()
        {
            _modelosRepository = new ModelosRepository_();
        }

        [HttpPut]
        public IActionResult PutIdBody(Modelos modeloAtualizado)
        {
            Modelos modeloBuscado = _modelosRepository.BuscarPorId(modeloAtualizado.idModelo);

            if (modeloBuscado != null)
            {
                try
                {
                    _modelosRepository.AtualizarIdCorpo(modeloBuscado);

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
                    mensagem = "Modelo não encontrado!",
                    errorStatus = true
                }
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Modelos modelo = _modelosRepository.BuscarPorId(id);

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult Post(Modelos novoModelo)
        {
            _modelosRepository.Cadastrar(novoModelo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _modelosRepository.Deletar(id);

            return NoContent();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Modelos> listaModelo = _modelosRepository.ListarTodos();

            return Ok(listaModelo);
        }
    }
}
