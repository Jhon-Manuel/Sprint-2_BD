using senai_rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Interfaces
{
    interface IModelosRepository
    {
        List<Modelos> ListarTodos();

        Modelos BuscarPorId (int idModelo);

        void Cadastrar(Modelos novoModelo);

        void AtualizarIdCorpo(Modelos modeloAtualizado);

        void Deletar(int idModelo);
    }
}
