using senai_rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Interfaces
{
    interface IMarcasrepository
    {
        List<Marcas> ListarTodos();

        Marcas BuscarPorId(int idMarca);

        void Cadastrar(Marcas novaMarca);

        void AtualizarIdCorpo(Marcas marcaAtualizado);

        void Deletar(int idMarca);
    }
}
