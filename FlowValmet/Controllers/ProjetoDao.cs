using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlowValmet.Model2;
using MySql.Data.MySqlClient;

namespace FlowValmet.Controllers
{
    public class ProjetoDao : Projeto
    {
        public static List<Projeto> list = new List<Projeto>();
        ConexaoAcess conexaoBanco = new ConexaoAcess();

       

        #region GetAllProjetos
        public List<Projeto> GetAllProjetos()
        {
            List<Projeto> projetos = new List<Projeto>();

            try
            {
                using (MySqlConnection conexao = conexaoBanco.Conectar())
                {
                    string sql = "SELECT * FROM projeto";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                    {
                        conexao.Open();

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Projeto projeto = new Projeto()
                                {
                                    id_projeto = Convert.ToInt32(reader["id_projeto"]),
                                    Pri = Convert.ToInt32(reader["Pri"]),
                                    BU = reader["BU"].ToString(),
                                    PCs = reader["PCs"].ToString(),
                                    Cliente = Convert.ToInt32(reader["Cliente"]),
                                    Item = reader["Item"].ToString(),
                                    DataPrazo = reader.IsDBNull(reader.GetOrdinal("DataPrazo")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataPrazo")),
                                    DataReprogramada = reader.IsDBNull(reader.GetOrdinal("DataReprogramada")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataReprogramada")),
                                    Res = reader.IsDBNull(reader.GetOrdinal("Res")) ? string.Empty : reader["Res"].ToString(),
                                    Custo = reader.GetDecimal(reader.GetOrdinal("Custo")),
                                    Semana = reader.IsDBNull(reader.GetOrdinal("Semana")) ? 0 : Convert.ToInt32(reader["Semana"])
                                };
                                //MessageBox.Show("Res: " + projeto.Res);
                                //MessageBox.Show("Custo: " + projeto.Custo);
                                //MessageBox.Show("Semana: " + projeto.Semana);
                                projetos.Add(projeto);

                            }
                        }
                    }

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar projetos: " + erro.Message);
            }

            return projetos;
        }
        #endregion
    }
}
