using senai_rental_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Interfaces
{
    interface IVeiculosRepository
    {
        List<Veiculos> ListarTodos();

        Veiculos BuscarPorId(int idVeiculo);

        void Cadastrar(Veiculos novoVeiculo);

        void AtualizarIdCorpo(Veiculos veiculoAtualizado);

        void Deletar(int idVeiculo);
    }
}
