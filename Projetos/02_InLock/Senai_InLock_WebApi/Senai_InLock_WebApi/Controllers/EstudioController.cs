using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_InLock_WebApi.Domains;
using Senai_InLock_WebApi.Interfaces;
using Senai_InLock_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebApi.Controllers
{
        
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudioRepository.ListarTodos());
        }

        [HttpGet("{idEstudio}")]
        public IActionResult GetById(int idEstudio)
        {
            return Ok(_estudioRepository.BuscarPorId(idEstudio));
        }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{idEstudio}")]
        public IActionResult Put(int idEstudio, Estudio estudioAtualizado)
        {
            _estudioRepository.Atualizar(idEstudio, estudioAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{idEstudio}")]
        public IActionResult Deletar(int idEstudio)
        {
            _estudioRepository.Deletar(idEstudio);

            return StatusCode(204);
        }

        [HttpGet("jogos")]
        public IActionResult ListarComJogos()
        {
            return Ok(_estudioRepository.ListarComJogos());
        }
    }
}
