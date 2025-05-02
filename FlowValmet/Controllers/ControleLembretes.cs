using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace FlowValmet.Controllers
{
    internal class ControleLembretes
    {
        ConexaoAcess Conexao = new ConexaoAcess();
        
        public List<Tuple<int,string,string,bool,string>> RecuperarLembrete(string comando)
        {
            List<Tuple<int,string, string, bool, string>> listaLembretes = new List<Tuple<int,string, string, bool, string>>();
            try
            {
                
                var conexao = Conexao.Conectar();
                if (conexao != null)
                {
                    
                    conexao.Open();
                    var strComando = new MySqlCommand(comando,conexao);
                    var reader = strComando.ExecuteReader();
                    while (reader.Read()) 
                    {
                        listaLembretes.Add(Tuple.Create(Convert.ToInt32(reader["id"]), Convert.ToString(reader["titulo"]), Convert.ToString(reader["descricao"]), Convert.ToBoolean(reader["vinculo"]), Convert.ToString(reader["op"])));
                    }
                    conexao.Close();
                    return listaLembretes;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return null;
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Exibir Lembrete: " + ex.Message);
                return null;

            }
            
        }

        public bool InserirLembrete(string titulo, string descricao, bool vinculo, string op)
        {
            
                try
                {
                    var conexao = Conexao.Conectar();

                    conexao.Open();

                    string query = "INSERT INTO lembretes (titulo, descricao, vinculo, Op) VALUES (@titulo, @descricao, @vinculo, @Op)";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@titulo", titulo);
                        comando.Parameters.AddWithValue("@descricao", descricao);
                        comando.Parameters.AddWithValue("@vinculo", vinculo);
                        comando.Parameters.AddWithValue("@Op", op);

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

        public bool ExcluirLembrete(int id)
        {
            try
            {
                var conexao = Conexao.Conectar();
                conexao.Open();

                    string query = "DELETE FROM lembretes WHERE id = @id";
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
