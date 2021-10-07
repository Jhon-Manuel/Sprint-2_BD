using Senai_InLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listartodos();

        Usuario BuscarPorId(int idUsuario);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(Usuario usuarioAtualizado);

        void Deletar(int idUsuario);
    }
}
