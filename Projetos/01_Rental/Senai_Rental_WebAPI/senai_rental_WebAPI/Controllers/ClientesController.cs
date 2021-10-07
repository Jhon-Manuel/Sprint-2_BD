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
    public class ClientesController : ControllerBase
    {
        private IClientesRepository __clientesRepository { get; set; }

        public ClientesController()
        {
            __clientesRepository = new ClientesRepository();
        }

        [HttpPut]
        public IActionResult PutIdBody (Clientes clienteAtualizado)
        {
            Clientes clienteBuscado = __clientesRepository.BuscarPorId(clienteAtualizado.idCliente);

            if (clienteBuscado != null)
            {
                try
                {
                    __clientesRepository.AtualizarIdCorpo(clienteBuscado);

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
                    mensagem = "Cliente não encontrado!",
                    errorStatus = true
                }
            );
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Clientes cliente = __clientesRepository.BuscarPorId(id);

            return StatusCode(201);
        }

        [HttpPost]
        public IActionResult Post(Clientes novoCliente)
        {
            __clientesRepository.Cadastrar(novoCliente);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            __clientesRepository.Deletar(id);

            return NoContent();
        }
        

        [HttpGet]
        public IActionResult Get()
        {
            List<Clientes> listaClientes = __clientesRepository.ListarTodas();

            return Ok(listaClientes);
        }


    }

}
