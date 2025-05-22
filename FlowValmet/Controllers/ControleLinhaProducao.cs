using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ControleLinhaProducao
    {
        ConexaoAcess Conexao = new ConexaoAcess();
        public bool InserirLinha(string linha, string cor, string sigla)
        {

            try
            {
                var conexao = Conexao.Conectar();

                conexao.Open();

                string query = "INSERT INTO linhaproducao(linha, cor, sigla) VALUES (@linha, @cor, @sigla)";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@linha", linha);
                    comando.Parameters.AddWithValue("@cor", cor);
                    comando.Parameters.AddWithValue("@sigla", sigla);


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

        public List<Tuple<int, string, string, string>> RecuperarLinha(string comando)
        {
            List<Tuple<int, string, string, string>> listaLinhas = new List<Tuple<int, string, string, string>>();
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
                        listaLinhas.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["linha"]),
                                                        Convert.ToString(reader["sigla"]), Convert.ToString(reader["cor"])
                                                        ));
                    }
                    conexao.Close();
                    return listaLinhas;
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
        public List<Tuple<int,string>> RecuperarLinhaSigla(string comando)
        {
            List<Tuple<int, string>> listaLinhasSigla = new List<Tuple<int, string>>();
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
                        listaLinhasSigla.Add(Tuple.Create(Convert.ToInt32(reader["id"]),Convert.ToString(reader["sigla"])));
                    }
                    conexao.Close();
                    return listaLinhasSigla;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao recuperar siglas de produção: " + ex.Message);
                return null;

            }

        }

        public bool ExcluirLinha(int id)
        {
            try
            {
                var conexao = Conexao.Conectar();
                conexao.Open();

                string query = "DELETE FROM linhaproducao WHERE id = @id";
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
    }
}
