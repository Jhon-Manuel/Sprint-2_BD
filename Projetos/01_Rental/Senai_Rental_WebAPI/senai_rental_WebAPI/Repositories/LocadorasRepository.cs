using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Repositories
{
    public class LocadorasRepository : ILocadorasRepository
    {
        private string stringConexao = "Data Source=DESKTOP-G5G5MAP\\SQLEXPRESS; initial catalog=T_Rental_Jhon; user Id=sa; pwd=123456";

        public void AtualizarIdCorpo(Locadoras locadoraAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE LOCADORA SET nomeFantasia = @nomeFantasia WHERE idLocadora = @idLocadora";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody,con))
                {
                    cmd.Parameters.AddWithValue("@nomeFantasia", locadoraAtualizado.nomeFantasia);
                    cmd.Parameters.AddWithValue("@idLocadora", locadoraAtualizado.idLocadora);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Locadoras BuscarPorId(int idLocadora)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idLocadora, nomeLocadora FROM LOCADORA WHERE idLocadora = @idLocadora";

                con.Open(); 

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idLocadora",idLocadora);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Locadoras locadora = new Locadoras
                        {
                        idLocadora = Convert.ToInt32(rdr[0]),
                        nomeFantasia = rdr[1].ToString()
                        };

                        return locadora;
                    }

                return null;
                } 

            }

        }

        public void Cadastrar(Locadoras novaLocadora)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO LOCADORA (nomeFantasia) VALUES(@novaLocadora)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@novaLocadora", novaLocadora.idLocadora);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int idLocadora)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM LOCADORA WHERE idLocadora = @idLocadora";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idLocadora", idLocadora);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Locadoras> ListarTodos()
        {
            List<Locadoras> listaLocadora = new List<Locadoras>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idLocadora, nomeFantasia FROM LOCADORA";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Locadoras locadora = new Locadoras()
                        {
                            idLocadora = Convert.ToInt32(rdr[0]),
                            nomeFantasia = rdr[1].ToString()
                        };

                        listaLocadora.Add(locadora);
                    }
                }
            }
            return listaLocadora;
        }
    }
}
