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
    public class VeiculosController : ControllerBase
    {
        private IVeiculosRepository __veiculosRepository { get; set; }

        public VeiculosController()
        {
            __veiculosRepository = new VeiculosRepository();
        }

        [HttpPut]
        public IActionResult PutIdBody(Veiculos veiculoeAtualizado)
        {
            Veiculos veiculosBuscado = __veiculosRepository.BuscarPorId(veiculoeAtualizado.idVeiculo);

            if (veiculosBuscado != null)
            {
                try
                {
                    __veiculosRepository.AtualizarIdCorpo(veiculosBuscado);

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
                    mensagem = "Veiculo não encontrado!",
                    errorStatus = true
                }
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Veiculos veiculo = __veiculosRepository.BuscarPorId(id);

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult Post(Veiculos novoVeiculo)
        {
            __veiculosRepository.Cadastrar(novoVeiculo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            __veiculosRepository.Deletar(id);

            return NoContent();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<Veiculos> listaVeiculos = __veiculosRepository.ListarTodos();

            return Ok(listaVeiculos);
        }
    }
}
