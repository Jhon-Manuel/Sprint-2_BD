using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Repositories
{
    public class ModelosRepository_ : IModelosRepository
    {
        private string stringConexao = "Data Source=DESKTOP-G5G5MAP\\SQLEXPRESS; initial catalog=T_Rental_Jhon; user Id=sa; pwd=123456";

        public void AtualizarIdCorpo(Modelos modeloAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE MODELO SET nomeModelo = @nomeModelo WHERE idModelo = @idModelo" +
                                         "UPDATE MODELO SET idModelo = @idModelo WHERE idModelo = @idModelo" +
                                         "UPDATE MODELO SET idMarca = @idMarca WHERE idMarca = @idMarca";

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@nomeModelo", modeloAtualizado.modelo);
                    cmd.Parameters.AddWithValue("@idModelo", modeloAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idMarca", modeloAtualizado.idMarca);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Modelos BuscarPorId(int idModelo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT modelo, idModelo, idMarca FROM MODELO WHERE idModelo = @idModelo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", idModelo);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Modelos modelo = new Modelos()
                        {
                            modelo = rdr[0].ToString(),
                            idModelo = Convert.ToInt32(rdr[1]),
                            idMarca = Convert.ToInt32(rdr[2])
                        };

                        return modelo;
                    }

                    return null;
                }

            }

        }

        public void Cadastrar(Modelos novoModelo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO MODELO (modelo, idMarca) VALUES('@modelo','@idMarca')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@modelo", novoModelo.modelo);
                    cmd.Parameters.AddWithValue("@idMarca", novoModelo.idMarca);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int idModelo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM MODELO WHERE idModelo = @idModelo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", idModelo);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Modelos> ListarTodos()
        {
            List<Modelos> listaModelo = new List<Modelos>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT modelo, idModelo, idMarca FROM MODELO";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Modelos modelo = new Modelos()
                        {
                            modelo = rdr[0].ToString(),
                            idModelo = Convert.ToInt32(rdr[1]),
                            idMarca = Convert.ToInt32(rdr[2])
                        };

                        listaModelo.Add(modelo);
                    }
                }
            }
            return listaModelo;
        }
}
