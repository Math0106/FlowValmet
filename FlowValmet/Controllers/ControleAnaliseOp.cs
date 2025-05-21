using MySql.Data.MySqlClient;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FlowValmet.Controllers
{
    internal class ControleAnaliseOp
    {
        ConexaoAcess Conexao = new ConexaoAcess();

        public List<Tuple<string, string, string, DateTime, DateTime, string>> RecuperarOp()
        {
            List<Tuple<string, string, string, DateTime,DateTime,string>> listaAnaliseOp = new List<Tuple<string, string, string, DateTime, DateTime, string>>();
            try
            {
                string comando = @"
                SELECT 
                    op.numeroop,
                    op.descricao,
                    op.desenho,
                    op.datainicio,
                    op.dataentrega,
                    IFNULL(
                        GROUP_CONCAT(
                        lp.sigla
                        ORDER BY pr.inicio 
                        SEPARATOR ','
                    ), 'sem vinculo'
                    ) AS linhaproducao
                   FROM 
                   op
                   LEFT JOIN 
                        processos pr ON op.id = pr.op_id
                   LEFT JOIN
                    linhaproducao lp ON pr.linhaproducao_id = lp.id
                   GROUP BY 
                        op.id, op.numeroop, op.descricao, op.desenho, op.datainicio, op.dataentrega;
                 ";

                var conexao = Conexao.Conectar();
                if (conexao != null)
                {

                    conexao.Open();
                    var strComando = new MySqlCommand(comando, conexao);
                    var reader = strComando.ExecuteReader();
                    while (reader.Read())
                    {
                        listaAnaliseOp.Add(
                                        Tuple.Create(
                                        reader["numeroop"].ToString(),
                                        reader["descricao"].ToString(),
                                        reader["desenho"].ToString(),
                                        Convert.ToDateTime(reader["datainicio"]),
                                        Convert.ToDateTime(reader["dataentrega"]),
                                        reader["linhaproducao"].ToString()
                                        ));
                    }
                    conexao.Close();
                    return listaAnaliseOp;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exibir PCP: " + ex.Message);
                return null;

            }

       

        }

        public bool AtualizarStatus(string status,string numeroOp,string siglaLinhaProducao)
        {
            try
            {
                string query = @"
                UPDATE bdflowvalmet.processos p
                JOIN bdflowvalmet.op o ON p.op_id = o.id
                JOIN bdflowvalmet.linhaproducao lp ON p.linhaproducao_id = lp.id
                SET p.status = @status
                WHERE o.numeroOp = @numeroop  
                AND lp.sigla = @sigla;
                 ";

                var conexao = Conexao.Conectar();
                if (conexao != null)
                {

                    conexao.Open();

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@status", status);
                        comando.Parameters.AddWithValue("@numeroop", numeroOp);
                        comando.Parameters.AddWithValue("@sigla", siglaLinhaProducao.ToUpper());

                        comando.ExecuteNonQuery(); // Executa o INSERT
                    }
                    conexao.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exibir PCP: " + ex.Message);
                return false;

            }
        }

        public List<Tuple<string, string, string>> RecuperarStatusPCP(string numeroOp, string sigla)
        {
            List<Tuple<string, string, string>> recuperestatus = new List<Tuple<string, string, string>>();

            try
            {
                var conexao = Conexao.Conectar();
                if (conexao != null)
                {
                    conexao.Open();
                    string query = @"SELECT p.status, o.numeroop, lp.sigla
                           FROM processos p
                           JOIN op o ON p.op_id = o.id
                           JOIN linhaproducao lp ON p.linhaproducao_id = lp.id
                           WHERE o.numeroop = @numeroop AND lp.sigla = @sigla LIMIT 1";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@numeroop", numeroOp);
                        comando.Parameters.AddWithValue("@sigla", sigla);

                        var reader = comando.ExecuteReader();

                        while (reader.Read())
                        {
                            recuperestatus.Add(
                                Tuple.Create(
                                    reader["numeroop"].ToString(),
                                    reader["status"].ToString(),
                                    reader["sigla"].ToString()
                                )
                            );
                        }
                    }
                    return recuperestatus;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao recuperar status PCP: " + ex.Message);
                return recuperestatus;
            }
        }
    }
    
}
