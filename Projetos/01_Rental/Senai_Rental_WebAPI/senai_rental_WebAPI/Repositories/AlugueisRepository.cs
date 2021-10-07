using senai_rental_WebAPI.Domains;
using senai_rental_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Repositories
{
    public class AlugueisRepository : IAlugueisRepository
    {
        
            private string stringConexao = "Data Source=DESKTOP-G5G5MAP\\SQLEXPRESS; initial catalog=T_Rental_Jhon; user Id=sa; pwd=123456";

            public void AtualizarIdCorpo(Alugueis aluguelAtualizado)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody =
                                     "UPDATE ALUGUEL SET idVeiculo = @idVeiculo WHERE idAluguel = @idAluguel" +
                                     "UPDATE ALUGUEL SET idCliente = @idCliente WHERE idAluguel = @idAluguel" +
                                     "UPDATE ALUGUEL SET dataRetirada = @dataRetirada WHERE idAluguel = @idAluguel" +
                                     "UPDATE ALUGUEL SET dataDevolucao = @dataDevolucao WHERE idAluguel = @idAluguel";
                con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                        cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                        cmd.Parameters.AddWithValue("@dataRetirada", aluguelAtualizado.dataRetirada);
                        cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public Alugueis BuscarPorId(int idAluguel)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectById = "SELECT idAluguel, idVeiculo, idCliente, dataRetirada, dataDevolucao FROM ALUGUEL WHERE idAluguel = @idAluguel";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                    {
                        cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            Alugueis aluguel = new Alugueis()
                            {
                                idAluguel = Convert.ToInt32(rdr[0]),
                                idVeiculo = Convert.ToInt32(rdr[1]),
                                idCliente = Convert.ToInt32(rdr[2]),
                                dataDevolucao = Convert.ToDateTime(rdr[3]),
                                dataRetirada = Convert.ToDateTime(rdr[4])
                            };

                            return aluguel;
                        }

                        return null;
                    }

                }

            }

            public void Cadastrar(Alugueis novoAluguel)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryInsert = "INSERT INTO ALUGUEL (idVeiculo, idCliente, dataRetirada, dataDevolucao) VALUES(@idVeiculo,@idCliente,'@dataDevolucao,'@dataRetirada')";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                        cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                        cmd.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataRetirada);
                        cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);

                        cmd.ExecuteNonQuery();
                    }

                }
            }

            public void Deletar(int idAluguel)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryDelete = "DELETE FROM ALUGUEL WHERE idAluguel = @idAluguel";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        cmd.Parameters.AddWithValue("@idAluguel", idAluguel);
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<Alugueis> ListarTodos()
            {
                List<Alugueis> listaAluguel = new List<Alugueis>();

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll = "SELECT * FROM ALUGUEL";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                        Alugueis aluguel = new Alugueis()
                        {
                            idAluguel = Convert.ToInt32(rdr[0]),
                            idVeiculo = Convert.ToInt32(rdr[1]),
                            idCliente = Convert.ToInt32(rdr[2]),
                            dataRetirada = Convert.ToDateTime(rdr[3]),
                            dataDevolucao = Convert.ToDateTime(rdr[4])
                            };

                            listaAluguel.Add(aluguel);
                        }
                    }
                }
                return listaAluguel;
            }
        }
    
}
