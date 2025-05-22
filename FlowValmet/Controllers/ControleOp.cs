using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ControleOp
    {
        ConexaoAcess Conexao = new ConexaoAcess();
            
        public List<Tuple<int, string, string, string, DateTime, DateTime>> RecuperarOp(string comando)
        {
            List<Tuple<int, string, string, string, DateTime, DateTime>> listaOp = new List<Tuple<int, string, string, string, DateTime, DateTime>>();
            try
            {

                var conexao = Conexao.Conectar();
                if (conexao != null)
                {

                    conexao.Open();
                    var strComando = new MySqlCommand(comando, conexao);
                    var reader = strComando.ExecuteReader();
                    while (reader.Read())
                    {
                        listaOp.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["numeroop"]),
                                            Convert.ToString(reader["descricao"]), Convert.ToString(reader["desenho"]), 
                                            Convert.ToDateTime(reader["datainicio"]), Convert.ToDateTime(reader["dataentrega"])
                                            ));
                    }
                    conexao.Close();
                    return listaOp;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exibir Lembrete: " + ex.Message);
                return null;

            }

        }

        public bool InserirOP(string numeroOp, string descricao, string desenho, DateTime dataInicio, DateTime dataentrega)
        {

            try
            {
                var conexao = Conexao.Conectar();

                conexao.Open();

                string query = "INSERT INTO op (numeroop, descricao, desenho, datainicio, dataentrega) VALUES (@numeroop, @descricao, @desenho, @datainicio, @dataentrega)";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@numeroop", numeroOp);
                    comando.Parameters.AddWithValue("@descricao", descricao);
                    comando.Parameters.AddWithValue("@desenho", desenho);
                    comando.Parameters.AddWithValue("@datainicio", dataInicio.Date);
                    comando.Parameters.AddWithValue("@dataentrega", dataentrega.Date);

                    comando.ExecuteNonQuery(); // Executa o INSERT
                }
                conexao.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir: " + ex.Message);
                return false;
            }


        }

        public bool ExcluirOp(int id)
        {
            try
            {
                var conexao = Conexao.Conectar();
                conexao.Open();

                string query = "DELETE FROM op WHERE id = @id";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    int resultado = comando.ExecuteNonQuery();

                    return resultado > 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir: " + ex.Message);
                return false;
            }
        }
        public int ExcluirProcessosVinculados(int id)
        {
            try
            {
                var conexao = Conexao.Conectar();
                conexao.Open();

                string query = "DELETE FROM processos WHERE op_id = @id";
                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    int resultado = comando.ExecuteNonQuery();

                    return resultado;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir vinculos: " + ex.Message);
                return 0;
            }
        }

        public bool AtualizarOp(int id, string numeroOp, string descricao, string desenho, DateTime dataInicio, DateTime dataEntrega)
        {
            try
            {
                var conexao = Conexao.Conectar();
                if (conexao != null)
                {
                    conexao.Open();
                    string comandoSql = @"UPDATE op 
                                  SET numeroop = @numeroop,
                                      descricao = @descricao,
                                      desenho = @desenho,
                                      datainicio = @datainicio,
                                      dataentrega = @dataentrega
                                  WHERE id = @id";

                    var comando = new MySqlCommand(comandoSql, conexao);
                    comando.Parameters.AddWithValue("@numeroop", numeroOp);
                    comando.Parameters.AddWithValue("@descricao", descricao);
                    comando.Parameters.AddWithValue("@desenho", desenho);
                    comando.Parameters.AddWithValue("@datainicio", dataInicio.Date);
                    comando.Parameters.AddWithValue("@dataentrega", dataEntrega.Date);
                    comando.Parameters.AddWithValue("@id", id);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    conexao.Close();

                    if (linhasAfetadas > 0)
                    {
                       
                        return true;
                    }
                    else
                    {
                        
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Falha na conexão.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar OP: " + ex.Message);
                return false;
            }
        }






    }
}
