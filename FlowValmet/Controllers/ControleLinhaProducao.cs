using FlowValmet.Models;
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

        public bool InserirLinha(LinhaProducao linha)
        {
            // Valida os dados antes de inserir
            if (!linha.Validar())
            {
                return false;
            }

            try
            {
                using (var conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string query = @"
                INSERT INTO linhaproducao 
                (linha, cor, sigla) 
                VALUES 
                (@linha, @cor, @sigla);
                
                SELECT LAST_INSERT_ID();"; // Retorna o ID gerado

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@linha", linha.NomeLinha);
                        comando.Parameters.AddWithValue("@cor", linha.Cor);
                        comando.Parameters.AddWithValue("@sigla", linha.Sigla);

                        // Executa e obtém o ID gerado
                        linha.Id = Convert.ToInt32(comando.ExecuteScalar());

                        return linha.Id > 0; // Retorna true se foi gerado um ID válido
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
                return false;
            }
        }

        //public bool InserirLinha(string linha, string cor, string sigla)
        //{

        //    try
        //    {
        //        var conexao = Conexao.Conectar();

        //        conexao.Open();

        //        string query = "INSERT INTO linhaproducao(linha, cor, sigla) VALUES (@linha, @cor, @sigla)";

        //        using (var comando = new MySqlCommand(query, conexao))
        //        {
        //            comando.Parameters.AddWithValue("@linha", linha);
        //            comando.Parameters.AddWithValue("@cor", cor);
        //            comando.Parameters.AddWithValue("@sigla", sigla);


        //            comando.ExecuteNonQuery(); // Executa o INSERT
        //        }
        //        conexao.Close();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Erro ao inserir: " + ex.Message);
        //        return false;
        //    }
        //}

        public List<LinhaProducao> RecuperarLinha(string comandoSql)
        {
            List<LinhaProducao> listaLinhas = new List<LinhaProducao>();

            try
            {
                using (var conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    using (var cmd = new MySqlCommand(comandoSql, conexao))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var linha = new LinhaProducao
                            {
                                Id = reader.GetInt32("id"),
                                NomeLinha = reader.GetString("linha"),
                                Sigla = reader.GetString("sigla"),
                                Cor = reader.GetString("cor")
                            };

                            listaLinhas.Add(linha);
                        }
                    }
                }
                return listaLinhas;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro no banco de dados: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
                return null;
            }
        }

        //public List<Tuple<int, string, string, string>> RecuperarLinha(string comando)
        //{
        //    List<Tuple<int, string, string, string>> listaLinhas = new List<Tuple<int, string, string, string>>();
        //    try
        //    {

        //        var conexao = Conexao.Conectar();
        //        if (conexao != null)
        //        {

        //            conexao.Open();
        //            var strComando = new MySqlCommand(comando, conexao);
        //            var reader = strComando.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                listaLinhas.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["linha"]),
        //                                                Convert.ToString(reader["sigla"]), Convert.ToString(reader["cor"])
        //                                                ));
        //            }
        //            conexao.Close();
        //            return listaLinhas;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Falha na conexão");
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exibir Lembrete: " + ex.Message);
        //        return null;

        //    }

        //}
        public List<Tuple<int, string>> RecuperarLinhaSigla(string comando)
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
                        listaLinhasSigla.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["sigla"])));
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
