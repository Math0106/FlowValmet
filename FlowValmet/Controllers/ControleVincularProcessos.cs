using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ControleVincularProcessos
    {
        ConexaoAcess Conexao = new ConexaoAcess();
        public List<Tuple<int, string, string>> RecuperarOp_id_numeroOP_descricao(string comando)
        {
            List<Tuple<int, string, string>> listaOp = new List<Tuple<int, string, string>>();
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
                                            Convert.ToString(reader["descricao"])
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

        public List<Tuple<int, string, string>> RecuperarLinhaProducao_id_linha_sigla(string comando)
        {
            List<Tuple<int, string, string>> listaLinhaProducao = new List<Tuple<int, string, string>>();
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
                        listaLinhaProducao.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["linha"]),
                                            Convert.ToString(reader["sigla"])
                                            ));
                    }
                    conexao.Close();
                    return listaLinhaProducao;
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
        public bool InsertrVinculoProcesso(List<Tuple<int, int, DateTime, DateTime>> listaProcessosVinculados)
        {
            MySqlConnection conexao = null;

            try
            {
                conexao = Conexao.Conectar();
                conexao.Open();

                string query = @"INSERT INTO sua_tabela ( op_id, linhaproducao_id, inicio, fim) 
                         VALUES (@op_id, @linhaproducao_id, @inicio, @fim)";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    // Preparar parâmetros uma vez
                    comando.Parameters.Add("@op_id", MySqlDbType.Int32);
                    comando.Parameters.Add("@linhaproducao_id", MySqlDbType.Int32);
                    comando.Parameters.Add("@inicio", MySqlDbType.DateTime);
                    comando.Parameters.Add("@fim", MySqlDbType.DateTime);

                    // Iniciar transação para melhor performance em múltiplas inserções
                    using (var transaction = conexao.BeginTransaction())
                    {
                        foreach (var processo in listaProcessosVinculados)
                        {
                            comando.Parameters["@op_id"].Value = processo.Item2;
                            comando.Parameters["@linhaproducao_id"].Value = processo.Item3;
                            comando.Parameters["@inicio"].Value = processo.Item4;
                            comando.Parameters["@fim"].Value = processo.Item4;

                            comando.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao inserir: " + ex.Message);
                return false;
            }
            finally
            {
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }

    }
}
