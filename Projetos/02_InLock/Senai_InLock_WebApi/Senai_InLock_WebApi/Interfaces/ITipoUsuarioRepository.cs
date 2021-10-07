using Senai_InLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listartodos();

        TipoUsuario BuscarPorId(int idTipoUsuario);

        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Atualizar(TipoUsuario tipoUsuarioAtualizado);

        void Deletar(int idTipoUsuario);
    }
}
