using Senai_InLock_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_InLock_WebApi.Interfaces
{
    interface IJogoRepository
    {
        List<Jogo> Listartodos();

        Jogo BuscarPorId();

        void Cadastrar(Jogo novoJogo);

        void Atualizar(int idJogo, Jogo jogoAtualizado);

        void Deletar(int idJogo);
    }
}
