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

        #region CadastrarProjeto
        public void CadastrarProjeto(Projeto obj)
        {
            try
            {
                string sql = @"INSERT INTO projeto 
                            (Pri, BU, PCs, Cliente, Item, DataPrazo, DataReprogramada, Res, Custo, Semana) 
                            VALUES 
                            (@Pri, @BU, @PCs, @Cliente, @Item, @DataPrazo, @DataReprogramada, @Res, @Custo, @Semana);
                            SELECT LAST_INSERT_ID();";

                using (MySqlConnection conexao = conexaoBanco.Conectar())
                {
                    conexao.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@Pri", obj.Pri);
                        cmd.Parameters.AddWithValue("@BU", obj.BU ?? string.Empty);
                        cmd.Parameters.AddWithValue("@PCs", obj.PCs ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Cliente", obj.Cliente);
                        cmd.Parameters.AddWithValue("@Item", obj.Item ?? string.Empty);
                        cmd.Parameters.AddWithValue("@DataPrazo", obj.DataPrazo.HasValue ? (object)obj.DataPrazo.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@DataReprogramada", obj.DataReprogramada.HasValue ? (object)obj.DataReprogramada.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@Res", obj.Res ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Custo", obj.Custo);
                        cmd.Parameters.AddWithValue("@Semana", obj.Semana);

                        obj.id_projeto = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar projeto: " + erro.Message);
            }
        }
        #endregion

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
                                    Res = reader["Res"].ToString(),
                                    Custo = reader.GetDecimal("Custo"),
                                    Semana = Convert.ToInt32(reader["Semana"])
                                };

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
