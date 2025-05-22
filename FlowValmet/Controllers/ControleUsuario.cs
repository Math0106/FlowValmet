using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ControleUsuario
    {
        ConexaoAcess Conexao = new ConexaoAcess();

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
    }
}
