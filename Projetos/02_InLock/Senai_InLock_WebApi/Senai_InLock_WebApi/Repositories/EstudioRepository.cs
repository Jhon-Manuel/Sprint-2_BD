using Microsoft.EntityFrameworkCore;
using Senai_InLock_WebApi.Contexts;
using Senai_InLock_WebApi.Domains;
using Senai_InLock_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Senai_InLock_WebApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int idEstudio, Estudio estudioAtualizado)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(idEstudio);

            if (estudioBuscado.NomeEstudio != null)
            {
                estudioBuscado.NomeEstudio = estudioAtualizado.NomeEstudio;
            }

            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(int idEstudio)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == idEstudio);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            ctx.Estudios.Add(novoEstudio);

            ctx.SaveChanges();
        }

        public void Deletar(int idEstudio)
        {
            Estudio estudioBuscado = BuscarPorId(idEstudio);

            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }

        public List<Estudio> ListarTodos()
        {
            return ctx.Estudios.ToList();
        }
    }
}
