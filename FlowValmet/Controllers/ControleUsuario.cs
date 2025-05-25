using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowValmet.Models;

namespace FlowValmet.Controllers
{
    internal class ControleUsuario
    {
        ConexaoAcess Conexao = new ConexaoAcess();
        SessaoUsuario sessaoUsuario = new SessaoUsuario();

        public bool InserirUsuario(string nome, string email, string setor, string perfil, string senha)
        {

            try
            {
                var conexao = Conexao.Conectar();

                conexao.Open();

                string query = "INSERT INTO usuario(nome, email, setor, perfil, senha) VALUES (@nome, @email, @setor, @perfil, @senha)";

                using (var comando = new MySqlCommand(query, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@setor", setor);
                    comando.Parameters.AddWithValue("@perfil", perfil);
                    comando.Parameters.AddWithValue("@senha", senha);

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

        public List<Tuple<int, string, string, string, string>> RecuperarUsuarios(string comando)
        {
            List<Tuple<int, string, string, string, string>> listaUsuario = new List<Tuple<int, string, string, string, string>>();
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
                        listaUsuario.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["nome"]),
                                                        Convert.ToString(reader["email"]), Convert.ToString(reader["setor"]),
                                                        Convert.ToString(reader["perfil"])));
                    }
                    conexao.Close();
                    return listaUsuario;
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

        public bool ExcluirUsuario(int id)
        {
            try
            {
                var conexao = Conexao.Conectar();
                conexao.Open();

                string query = "DELETE FROM usuario WHERE id = @id";
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

        public bool AtualizarUsuario(int id, string nome, string email, string setor, string perfil, string senha)
        {
            try
            {
                var conexao = Conexao.Conectar();
                if (conexao != null)
                {
                    conexao.Open();
                    string comandoSql = @"UPDATE bdflowvalmet.usuario 
                              SET nome = @nome,
                                  email = @email,
                                  setor = @setor,
                                  perfil = @perfil,
                                  senha = @senha
                              WHERE id = @id";

                    var comando = new MySqlCommand(comandoSql, conexao);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@setor", setor);
                    comando.Parameters.AddWithValue("@perfil", perfil);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@id", id);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    conexao.Close();

                    return linhasAfetadas > 0;
                }
                else
                {
                    MessageBox.Show("Falha na conexão.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar usuário: " + ex.Message);
                return false;
            }
        }

        public string GerarHashSHA256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte a string para array de bytes e calcula o hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Converte o array de bytes para string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" formata para hexadecimal
                }

                return builder.ToString();
            }
        }

        public bool VerificarCredenciais(string nome, string senha)
        {
            string senhaHash = GerarHashSHA256(senha);

            using (var conexao = Conexao.Conectar())
            {
                conexao.Open();
                string comandoSql = @"SELECT 1 FROM bdflowvalmet.usuario 
                           WHERE nome = @nome AND senha = @senha";

                using (var comando = new MySqlCommand(comandoSql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@senha", senhaHash);

                    return comando.ExecuteScalar() != null;
                }
            }
        }

        // Método auxiliar para obter informações do usuário (opcional)
       public Usuario ObterUsuarioPorNome(string nome)
        {
            using (var conexao = Conexao.Conectar())
            {
                conexao.Open();
                string comandoSql = @"SELECT id, nome, email, setor, perfil 
                           FROM bdflowvalmet.usuario WHERE nome = @nome";

                using (var comando = new MySqlCommand(comandoSql, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", nome);

                    using (var reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id = reader.GetInt32("id"),
                                Nome = reader.GetString("nome"),
                                Email = reader.GetString("email"),
                                Setor = reader.GetString("setor"),
                                Perfil = reader.GetString("perfil")
                            };
                        }
                    }
                }
            }
            return null;
        }

        //    public SessaoUsuario VerificarCredenciais(string nome, string senha)
        //    {
        //        try
        //        {
        //            // Primeiro, gere o hash da senha (assumindo que as senhas são armazenadas como hash)
        //            string senhaHash = GerarHashSHA256(senha); // Você precisa implementar este método

        //            var conexao = Conexao.Conectar();
        //            if (conexao != null)
        //            {
        //                conexao.Open();
        //                string comandoSql = @"SELECT id FROM bdflowvalmet.usuario 
        //                          WHERE nome = @nome AND senha = @senha";

        //                var comando = new MySqlCommand(comandoSql, conexao);
        //                comando.Parameters.AddWithValue("@nome", nome);
        //                comando.Parameters.AddWithValue("@senha", senhaHash);

        //                using (var reader = comando.ExecuteReader())
        //                {
        //                    return reader.HasRows; // Retorna true se encontrou um usuário com essas credenciais
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Falha na conexão.");
        //                return false;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Erro ao verificar credenciais: " + ex.Message);
        //            return false;
        //        }
        //    }

        //}
    }
}

