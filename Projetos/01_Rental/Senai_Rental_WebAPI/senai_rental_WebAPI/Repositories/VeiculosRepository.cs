using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace senai_rental_WebAPI.Repositories
{
    public class VeiculosRepository : IVeiculosRepository
    {
            private string stringConexao = "Data Source=DESKTOP-G5G5MAP\\SQLEXPRESS; initial catalog=T_Rental_Jhon; user Id=sa; pwd=123456";

            public void AtualizarIdCorpo(Veiculos veiculoAtualizado)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                string queryUpdateBody =
                                     "UPDATE VEICULO SET idLocadora = @idVeiculo WHERE idVeiculo = @idVeiculo" +
                                     "UPDATE VEICULO SET idModelo = @idModelo WHERE idVeiculo = @idVeiculo" +
                                     "UPDATE VEICULO SET placa = @idMarca WHERE idVeiculo = @idVeiculo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", veiculoAtualizado.idVeiculo);
                        cmd.Parameters.AddWithValue("@idLocadora", veiculoAtualizado.idLocadora);
                        cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
                        cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }

        

        public Veiculos BuscarPorId(int idVeiculo)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectById = "SELECT idVeiculo, idLocadora, idModelo, placa FROM VEICULO WHERE idVeiculo = @idVeiculo";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            Veiculos veiculo = new Veiculos
                            {
                                idVeiculo = Convert.ToInt32(rdr[0]),
                                idLocadora = Convert.ToInt32(rdr[1]),
                                idModelo = Convert.ToInt32(rdr[2]),
                                placa = rdr[3].ToString()
                            };

                            return veiculo;
                        }

                        return null;
                    }

                }

            }

            public void Cadastrar(Veiculos novoVeiculo)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryInsert = "INSERT INTO VEICULO (idLocadora,idModelo,placa) VALUES(@idLocadora,@idModelo,'@placa')";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@idLocadora", novoVeiculo.idLocadora);
                        cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                        cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);

                        cmd.ExecuteNonQuery();
                    }

                }
            }

        

        public void Deletar(int idVeiculo)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryDelete = "DELETE FROM VEICULO WHERE idVeiculo = @idVeiculo";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<Veiculos> ListarTodos()
            {
                List<Veiculos> listaVeiculo = new List<Veiculos>();

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll =  "UPDATE VEICULO SET idVeiculo = @idVeiculo WHERE idCliente = @idVeiculo" +
                                             "UPDATE VEICULO SET idLocadora = @idLocadora WHERE idCliente = @idVeiculo" +
                                             "UPDATE VEICULO SET idModelo = @idModelo WHERE idCliente = @idVeiculo" +
                                             "UPDATE VEICULO SET placa = @placa WHERE idCliente = @idVeiculo ";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Veiculos veiculo = new Veiculos()
                            {
                                idVeiculo = Convert.ToInt32(rdr[0]),
                                idLocadora = Convert.ToInt32(rdr[1]),
                                idModelo = Convert.ToInt32(rdr[2]),
                                placa = rdr[3].ToString()
                            };

                            listaVeiculo.Add(veiculo);
                        }
                    }
                }
                return listaVeiculo;
            }

       
    }
    
}
