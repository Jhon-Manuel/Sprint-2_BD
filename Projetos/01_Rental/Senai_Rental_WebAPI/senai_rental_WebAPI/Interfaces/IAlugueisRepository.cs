using senai_rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Interfaces
{
    interface IAlugueisRepository
    {
        List<Alugueis> ListarTodos();

        Alugueis BuscarPorId(int idAlugueis);

        void Cadastrar(Alugueis novoAluguel);

        void AtualizarIdCorpo(Alugueis aluguelAtualizado);

        void Deletar(int idAluguel);
    }
}
