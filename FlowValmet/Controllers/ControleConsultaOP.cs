using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ControleConsultaOP
    {
        ConexaoAcess Conexao = new ConexaoAcess();


        public List<Tuple<string, string, string, string, DateTime, DateTime, string>> RecuperarOpCompleta()
        {
            List<Tuple<string, string, string, string, DateTime, DateTime, string>> listaOpCompleta =
                new List<Tuple<string, string, string, string, DateTime, DateTime, string>>();

            try
            {
                string comando = @"
            SELECT
                o.id AS op_id,
                o.numeroop,
                o.descricao,
                o.desenho,
                o.datainicio AS op_inicio,
                o.dataentrega AS op_entrega,
                GROUP_CONCAT(
                    CONCAT(
                        COALESCE(l.linha, ''),
                        '|', p.status, 
                        '|', p.inicio,
                        '|', p.fim
                    )
                    SEPARATOR ';'
                ) AS processos
            FROM
                op o
            LEFT JOIN
                processos p ON o.id = p.op_id
            LEFT JOIN
                linhaproducao l ON p.linhaproducao_id = l.id
            GROUP BY
                o.id, o.numeroop, o.descricao, o.desenho, o.datainicio, o.dataentrega
            ORDER BY
                o.id;
        ";

                var conexao = Conexao.Conectar();
                if (conexao != null)
                {
                    conexao.Open();
                    var cmd = new MySqlCommand(comando, conexao);
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        listaOpCompleta.Add(
                            Tuple.Create(
                                reader["op_id"].ToString(),
                                reader["numeroop"].ToString(),
                                reader["descricao"].ToString(),
                                reader["desenho"].ToString(),
                                Convert.ToDateTime(reader["op_inicio"]),
                                Convert.ToDateTime(reader["op_entrega"]),
                                reader["processos"].ToString()
                            ));
                    }
                    conexao.Close();
                    return listaOpCompleta;
                }
                else
                {
                    MessageBox.Show("Falha na conexão");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar dados: {ex.Message}");
                return null;
            }
        }
        //public List<Tuple<string, string, string, string, DateTime, DateTime, string>> RecuperarOpCompleta()
        //{
        //    List<Tuple<string, string, string, string, DateTime, DateTime,string>> 
        //    listaOPDetalhada = new List<Tuple<string, string, string, string, DateTime, DateTime, string>>();
        //    try
        //    {
        //        string comando = @"
        //        SELECT 
        //            o.id AS op_id,
        //            o.numeroop,
        //            o.descricao,
        //            o.desenho,
        //            o.datainicio AS op_inicio,
        //            o.dataentrega AS op_entrega,
        //        GROUP_CONCAT(
        //            CONCAT(
        //        COALESCE(l.linha, p.linhaproducao_id), 
        //            '*', p.status, '*', p.inicio, 
        //            '*', p.fim) 
        //            SEPARATOR '|'
        //                    ) AS processos
        //                FROM 
        //                    op o
        //                LEFT JOIN 
        //                processos p ON o.id = p.op_id
        //                LEFT JOIN 
        //                linhaproducao l ON p.linhaproducao_id = l.id
        //                GROUP BY
        //                o.id, o.numeroop, o.descricao, o.desenho, o.datainicio, o.dataentrega
        //                ORDER BY 
        //                o.id;
        //                 ";

        //        var conexao = Conexao.Conectar();
        //        if (conexao != null)
        //        {

        //            conexao.Open();
        //            var strComando = new MySqlCommand(comando, conexao);
        //            var reader = strComando.ExecuteReader();
        //            while (reader.Read())
        //            {
        //                listaOPDetalhada.Add(
        //                                Tuple.Create(
        //                                reader["op_id"].ToString(),
        //                                reader["numeroop"].ToString(),
        //                                reader["descricao"].ToString(),
        //                                reader["desenho"].ToString(),
        //                                Convert.ToDateTime(reader["op_inicio"]),
        //                                Convert.ToDateTime(reader["op_entrega"]),
        //                                reader["processos"].ToString()
        //                                ));
        //            }
        //            conexao.Close();
        //            return listaOPDetalhada;
        //        }
        //        else
        //        {
        //            MessageBox.Show("Falha na conexão");
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exibir PCP: " + ex.Message);
        //        return null;

        //    }

        //}
    }
}
