using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

    }
}
