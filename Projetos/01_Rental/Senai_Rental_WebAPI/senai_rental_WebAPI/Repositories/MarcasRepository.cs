using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Repositories
{
    public class MarcasRepository : IMarcasrepository
    {
        private string stringConexao = "Data Source=DESKTOP-G5G5MAP\\SQLEXPRESS; initial catalog=T_Rental_Jhon; user Id=sa; pwd=123456";

        public void AtualizarIdCorpo(Marcas marcaAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE MARCA SET marca = @marca WHERE idMarca = @idMarca";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody,con))
                {
                    cmd.Parameters.AddWithValue("@marca", marcaAtualizado.marca);
                    cmd.Parameters.AddWithValue("@idMarca", marcaAtualizado.idMarca);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Marcas BuscarPorId(int idMarca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryGetById = "SELECT idMarca, marca FROM MARCA WHERE idMarca = @idMarca";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryGetById, con))
                {
                    cmd.Parameters.AddWithValue("@idMarca", idMarca);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Marcas marca = new Marcas()
                        {
                            idMarca = Convert.ToInt32(rdr[0]),
                            marca = rdr[1].ToString()
                        };
                    return marca;
                    }
                }
            }
            return null;
        }

        public void Cadastrar(Marcas novaMarca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO MARCA(marca) VALUES(@novaMarca)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@novaMarca", novaMarca.idMarca);
                    cmd.ExecuteNonQuery();
                }
            }
           
        }

        public void Deletar(int idMarca)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM MARCA WHERE idMarca = @idMarca";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete,con))
                {
                    cmd.Parameters.AddWithValue("@idMarca", idMarca);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Marcas> ListarTodos()
        {
            List<Marcas> listaMarca = new List<Marcas>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idMarca, marca FROM MARCA";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Marcas marca = new Marcas()
                        {
                            idMarca = Convert.ToInt32(rdr[0]),
                            marca = rdr[1].ToString()
                        };

                        listaMarca.Add(marca);
                    }
                }
            }
            return listaMarca;
        }
    }
}
