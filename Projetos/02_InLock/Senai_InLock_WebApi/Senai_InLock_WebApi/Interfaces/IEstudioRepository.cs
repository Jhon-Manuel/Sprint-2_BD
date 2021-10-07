using Senai_InLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebApi.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> ListarTodos();

        Estudio BuscarPorId(int idEstudio);

        void Cadastrar(Estudio novoEstudio);

        void Atualizar(int idEstudio, Estudio estudioAtualizado);

        void Deletar(int idEstudio);

        List<Estudio> ListarComJogos();
    }
}
