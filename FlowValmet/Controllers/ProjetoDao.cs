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
        #region GetAllProjetosComFases
        public List<Projeto> GetAllProjetosComFases()
        {
            // Dicionário para garantir que cada projeto apareça uma única vez
            var projetos = new Dictionary<int, Projeto>();

            try
            {
                using (var conexao = conexaoBanco.Conectar())
                {
                    string sql = @"
                        SELECT 
                            p.id_projeto, p.Pri, p.BU, p.PCs, p.Cliente, p.Item,
                            p.DataPrazo, p.DataReprogramada, p.Res, p.Custo, p.Semana, p.Status_Projeto,
                            f.id_fase, f.datafase_inicial, f.datafase_final, f.observacao, f.Status_Fase
                        FROM projeto p
                        LEFT JOIN fase_projeto f ON p.id_projeto = f.projeto_id
                        ORDER BY p.id_projeto, f.datafase_inicial";

                    using (var cmd = new MySqlCommand(sql, conexao))
                    {
                        conexao.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int projetoId = Convert.ToInt32(reader["id_projeto"]);

                                // Se ainda não existe no dicionário, cria o projeto
                                if (!projetos.ContainsKey(projetoId))
                                {
                                    var projeto = new Projeto
                                    {
                                        id_projeto = projetoId,
                                        Pri = Convert.ToInt32(reader["Pri"]),
                                        BU = reader["BU"].ToString(),
                                        PCs = reader["PCs"].ToString(),
                                        Cliente = Convert.ToInt32(reader["Cliente"]),
                                        Item = reader["Item"].ToString(),
                                        DataPrazo = reader.IsDBNull(reader.GetOrdinal("DataPrazo"))
                                            ? (DateTime?)null
                                            : reader.GetDateTime("DataPrazo"),
                                        DataReprogramada = reader.IsDBNull(reader.GetOrdinal("DataReprogramada"))
                                            ? (DateTime?)null
                                            : reader.GetDateTime("DataReprogramada"),
                                        Res = reader.IsDBNull(reader.GetOrdinal("Res"))
                                            ? string.Empty
                                            : reader["Res"].ToString(),
                                        Custo = reader.IsDBNull(reader.GetOrdinal("Custo"))
                                            ? 0
                                            : reader.GetDecimal("Custo"),
                                        Semana = reader.IsDBNull(reader.GetOrdinal("Semana"))
                                            ? 0
                                            : Convert.ToInt32(reader["Semana"]),
                                        Status = reader.IsDBNull(reader.GetOrdinal("Status_Projeto"))
                                            ? string.Empty
                                            : reader["Status_Projeto"].ToString(),
                                        Fases = new List<Fase>()
                                    };

                                    projetos.Add(projetoId, projeto);
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("id_fase")))
                                {
                                    var fase = new Fase
                                    {
                                        IdFase = Convert.ToInt32(reader["id_fase"]),
                                        ProjetoId = projetoId,
                                        DataInicial = reader.IsDBNull(reader.GetOrdinal("datafase_inicial"))
                                            ? (DateTime?)null
                                            : reader.GetDateTime("datafase_inicial"),
                                        DataFinal = reader.IsDBNull(reader.GetOrdinal("datafase_final"))
                                            ? (DateTime?)null
                                            : reader.GetDateTime("datafase_final"),
                                        Observacao = reader.IsDBNull(reader.GetOrdinal("observacao"))
                                            ? string.Empty
                                            : reader["observacao"].ToString(),
                                        Status = reader.IsDBNull(reader.GetOrdinal("Status_Fase"))
                                            ? string.Empty
                                            : reader["Status_Fase"].ToString()
                                    };

                                    projetos[projetoId].Fases.Add(fase);
                                }
                            }
                        }
                    }
                }

                return projetos.Values.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar projetos com fases: " + ex.Message);
                return new List<Projeto>();
            }
        }
        #endregion

        #region PegarFases
        public List<Fase> GetFasesByProjeto(int projetoId)
        {
            var fases = new List<Fase>();

            try
            {
                using (var conexao = conexaoBanco.Conectar())
                {
                    string sql = @"
                        SELECT 
                            fp.id_fase,
                            fp.projeto_id,
                            fp.datafase_inicial,
                            fp.datafase_final,
                            fp.observacao,
                            fp.Status_Fase,
                            f.Fase,
                            f.Status_Projeto
                        FROM fase_projeto fp
                        LEFT JOIN Fases f ON fp.fase_id = f.ID
                        WHERE fp.projeto_id = @projId
                        ORDER BY fp.datafase_inicial;";

                    using (var cmd = new MySqlCommand(sql, conexao))
                    {
                        cmd.Parameters.AddWithValue("@projId", projetoId);
                        conexao.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var fase = new Fase
                                {
                                    IdFase = reader.GetInt32("id_fase"),
                                    ProjetoId = reader.GetInt32("projeto_id"),
                                    DataInicial = reader.IsDBNull(reader.GetOrdinal("datafase_inicial"))
                                                    ? (DateTime?)null
                                                    : reader.GetDateTime("datafase_inicial"),
                                    DataFinal = reader.IsDBNull(reader.GetOrdinal("datafase_final"))
                                                    ? (DateTime?)null
                                                    : reader.GetDateTime("datafase_final"),
                                    Observacao = reader.IsDBNull(reader.GetOrdinal("observacao"))
                                                    ? string.Empty
                                                    : reader.GetString("observacao"),
                                    Status = reader.IsDBNull(reader.GetOrdinal("Status_Fase"))
                                                    ? string.Empty
                                                    : reader.GetString("Status_Fase"),
                                    nomeFase = reader.IsDBNull(reader.GetOrdinal("Fase"))
                                                    ? string.Empty
                                                    : reader.GetString("Fase"),
                                };

                                fases.Add(fase);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar fases do projeto {projetoId}: {ex.Message}",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return fases;
        }
        #endregion
        #region GetProjetosPendente
        public List<Projeto> GetProjetosPendente()
        {
            List<Projeto> projetos = new List<Projeto>();

            try
            {
                using (MySqlConnection conexao = conexaoBanco.Conectar())
                {
                    string sql = "SELECT * FROM projeto WHERE Status_Projeto = 'Pendente'";

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
                                    DataPrazo = reader.IsDBNull(reader.GetOrdinal("DataPrazo"))
                                                ? (DateTime?)null
                                                : reader.GetDateTime(reader.GetOrdinal("DataPrazo")),
                                    DataReprogramada = reader.IsDBNull(reader.GetOrdinal("DataReprogramada"))
                                                ? (DateTime?)null
                                                : reader.GetDateTime(reader.GetOrdinal("DataReprogramada")),
                                    Res = reader.IsDBNull(reader.GetOrdinal("Res"))
                                                ? string.Empty
                                                : reader["Res"].ToString(),
                                    Custo = reader.GetDecimal(reader.GetOrdinal("Custo")),
                                    Semana = reader.IsDBNull(reader.GetOrdinal("Semana"))
                                                ? 0
                                                : Convert.ToInt32(reader["Semana"]),
                                    Status = reader["Status_Projeto"].ToString(),
                                };

                                projetos.Add(projeto);
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar projetos pendentes: " + erro.Message);
            }

            return projetos;
        }
        #endregion
        #region GetProjetosEmAndamento
        public List<Projeto> GetProjetosEmAndamento()
        {
            List<Projeto> projetos = new List<Projeto>();

            try
            {
                using (MySqlConnection conexao = conexaoBanco.Conectar())
                {
                    string sql = "SELECT * FROM projeto WHERE Status_Projeto = 'Em Andamento'";

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
                                    DataPrazo = reader.IsDBNull(reader.GetOrdinal("DataPrazo"))
                                                ? (DateTime?)null
                                                : reader.GetDateTime(reader.GetOrdinal("DataPrazo")),
                                    DataReprogramada = reader.IsDBNull(reader.GetOrdinal("DataReprogramada"))
                                                ? (DateTime?)null
                                                : reader.GetDateTime(reader.GetOrdinal("DataReprogramada")),
                                    Res = reader.IsDBNull(reader.GetOrdinal("Res"))
                                                ? string.Empty
                                                : reader["Res"].ToString(),
                                    Custo = reader.GetDecimal(reader.GetOrdinal("Custo")),
                                    Semana = reader.IsDBNull(reader.GetOrdinal("Semana"))
                                                ? 0
                                                : Convert.ToInt32(reader["Semana"]),
                                    Status = reader["Status_Projeto"].ToString(),
                                };

                                projetos.Add(projeto);
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar projetos pendentes: " + erro.Message);
            }

            return projetos;
        }
        #endregion

        #region GetProjetosEmAtraso
        public List<Projeto> GetProjetosEmAtraso()
        {
            List<Projeto> projetos = new List<Projeto>();

            try
            {
                using (MySqlConnection conexao = conexaoBanco.Conectar())
                {
                    string sql = "SELECT * FROM projeto WHERE Status_Projeto = 'Em Atraso'";

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
                                    DataPrazo = reader.IsDBNull(reader.GetOrdinal("DataPrazo"))
                                                ? (DateTime?)null
                                                : reader.GetDateTime(reader.GetOrdinal("DataPrazo")),
                                    DataReprogramada = reader.IsDBNull(reader.GetOrdinal("DataReprogramada"))
                                                ? (DateTime?)null
                                                : reader.GetDateTime(reader.GetOrdinal("DataReprogramada")),
                                    Res = reader.IsDBNull(reader.GetOrdinal("Res"))
                                                ? string.Empty
                                                : reader["Res"].ToString(),
                                    Custo = reader.GetDecimal(reader.GetOrdinal("Custo")),
                                    Semana = reader.IsDBNull(reader.GetOrdinal("Semana"))
                                                ? 0
                                                : Convert.ToInt32(reader["Semana"]),
                                    Status = reader["Status_Projeto"].ToString(),
                                };

                                projetos.Add(projeto);
                            }
                        }
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao buscar projetos pendentes: " + erro.Message);
            }

            return projetos;
        }
        #endregion


    }
}
