using senai_rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Interfaces
{
    interface IClientesRepository
    {
        List<Clientes> ListarTodos();

        Clientes BuscarPorId(int idCliente);

        void Cadastrar(Clientes novoCliente);

        void AtualizarIdCorpo(Clientes clienteAtualizado);

        void Deletar(int idCliente);
    }
}
