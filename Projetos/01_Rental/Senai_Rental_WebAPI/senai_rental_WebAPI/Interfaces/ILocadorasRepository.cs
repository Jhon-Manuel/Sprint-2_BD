using senai_rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Interfaces
{
    interface ILocadorasRepository
    {
        List<Locadoras> ListarTodos();

        Locadoras BuscarPorId(int idLocadora);

        void Cadastrar(Locadoras novaLocadora);

        void AtualizarIdCorpo(Locadoras locadoraAtualizado);

        void Deletar(int idLocadora);
    }
}
