using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Repositories
{
    public class ClientesRepository : IClientesRepository
    {
        string stringConexao = "Data Source=DESKTOP-G5G5MAP\\SQLEXPRESS; initial catalog=T_Rental_Jhon; user Id=sa; pwd=123456";

        public void AtualizarIdCorpo(Clientes clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateBody = "UPDATE CLIENTE SET nomeCliente = @nomeCliente WHERE idCliente = @idCliente" +
                                         "UPDATE CLIENTE SET sobrenomeCliente = @sobrenomeCliente WHERE idCliente = @idCliente" +
                                         "UPDATE CLIENTE SET CPF = @CPF WHERE idCliente = @idCliente" +
                                         "UPDATE CLIENTE SET idLocadora = @idLocadora WHERE idCliente = @idCliente ";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CPF", clienteAtualizado.CPF);
                    cmd.Parameters.AddWithValue("@idLocadora", clienteAtualizado.idLocadora);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Clientes BuscarPorId(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobrenomeCliente, CPF, idLocadora FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente",idCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        Clientes cliente = new Clientes()
                        {
                            idCliente = Convert.ToInt32(rdr[0]),
                            nomeCliente = rdr[1].ToString(),
                            sobrenomeCliente = rdr[2].ToString(),
                            CPF = Convert.ToInt32(rdr[3]),
                            idLocadora = Convert.ToInt32(rdr[4])
                        };

                        return cliente;
                    }

                    return null;
                }

            }

        }

        public void Cadastrar(Clientes novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO LOCADORA (nomeCliente,sobrenomeCliente,CPF,idLocadora) VALUES('@nomeCliente','@sobrenomeCliente','@CPF','@idLocadora')";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@CPF", novoCliente.CPF);
                    cmd.Parameters.AddWithValue("@idLocadora", novoCliente.idLocadora);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Clientes> ListarTodos()
        {
            List<Clientes> listaCliente = new List<Clientes>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT nomeCliente, sobrenomeCliente, CPF, idCliente, idLocadora FROM CLIENTE";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Clientes cliente = new Clientes()
                        {
                            nomeCliente = rdr[0].ToString(),
                            sobrenomeCliente = rdr[1].ToString(),
                            CPF = Convert.ToInt32(rdr[2]),
                            idCliente = Convert.ToInt32(rdr[3]),
                            idLocadora = Convert.ToInt32(rdr[4])
                        };
                        listaCliente.Add(cliente);
                    }
                }
            }
            return listaCliente;
        }
    }
}
