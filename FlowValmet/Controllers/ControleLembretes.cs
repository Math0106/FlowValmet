using FlowValmet.Models;
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
        public List<Lembrete> RecuperarLembrete(string comandoSql)
        {
            List<Lembrete> listaLembretes = new List<Lembrete>();

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
                            var lembrete = new Lembrete(
                                id: reader.GetInt32("id"),
                                titulo: reader.GetString("titulo"),
                                descricao: reader.IsDBNull(reader.GetOrdinal("descricao")) ?
                                          string.Empty : reader.GetString("descricao"),
                                vinculo: reader.GetBoolean("vinculo"),
                                op: reader.IsDBNull(reader.GetOrdinal("op")) ?
                                    null : reader.GetString("op")
                            );

                            listaLembretes.Add(lembrete);
                        }
                    }
                }
                return listaLembretes;
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

        public bool InserirLembrete(Lembrete lembrete)
        {

            // Validação usando o método do modelo
            if (!lembrete.Validar())
            {
                MessageBox.Show("Dados do lembrete inválidos. Verifique os campos, todos são obrigatórios.");
                return false;
            }

            try
            {
                using (var conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string query = @"INSERT INTO lembretes 
                            (titulo, descricao, vinculo, op) 
                            VALUES 
                            (@titulo, @descricao, @vinculo, @op);
                            
                            SELECT LAST_INSERT_ID();"; // Retorna o ID gerado

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@titulo", lembrete.Titulo);
                        comando.Parameters.AddWithValue("@descricao", lembrete.Descricao);
                        comando.Parameters.AddWithValue("@vinculo", lembrete.Vinculo);
                        comando.Parameters.AddWithValue("@op",
                        lembrete.Vinculo && !string.IsNullOrWhiteSpace(lembrete.Op)
                            ? lembrete.Op : (object)DBNull.Value);

                        // Executa e obtém o ID gerado
                        lembrete.Id = Convert.ToInt32(comando.ExecuteScalar());

                        return lembrete.Id > 0; // Retorna true se foi gerado um ID válido
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

        public bool ExcluirLembrete(int id)
        {
            // Validação básica do ID
            if (id <= 0)
            {
                MessageBox.Show("ID do lembrete inválido");
                return false;
            }

            try
            {
                using (var conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string query = "DELETE FROM lembretes WHERE id = @id";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", id);
                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            MessageBox.Show("Nenhum lembrete encontrado com o ID informado");
                            return false;
                        }

                        return true;
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

        public bool AtualizarLembrete(Lembrete lembrete)
        {
            if (!lembrete.Validar())
            {
                MessageBox.Show("Dados do lembrete inválidos. Verifique:");
                MessageBox.Show(lembrete.Id <= 0 ? "• ID inválido\n" : "");
                MessageBox.Show(string.IsNullOrWhiteSpace(lembrete.Titulo) ? "• Título obrigatório\n" : "");
                MessageBox.Show(lembrete.Vinculo && string.IsNullOrWhiteSpace(lembrete.Op) ? "• OP obrigatória para lembretes vinculados" : "");
                return false;
            }

            try
            {
                using (var conexao = Conexao.Conectar())
                {
                    conexao.Open();

                    string query = @"
                UPDATE lembretes 
                SET 
                    titulo = @titulo, 
                    descricao = @descricao, 
                    vinculo = @vinculo, 
                    op = @op 
                WHERE 
                    id = @id";

                    using (var comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", lembrete.Id);
                        comando.Parameters.AddWithValue("@titulo", lembrete.Titulo);
                        comando.Parameters.AddWithValue("@descricao", lembrete.Descricao);
                        comando.Parameters.AddWithValue("@vinculo", lembrete.Vinculo);
                        comando.Parameters.AddWithValue("@op", lembrete.Vinculo ? lembrete.Op : (object)DBNull.Value);

                        int linhasAfetadas = comando.ExecuteNonQuery();

                        if (linhasAfetadas == 0)
                        {
                            MessageBox.Show("Nenhum lembrete foi atualizado. Verifique se o ID existe.");
                            return false;
                        }

                        return true;
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
            //try
            //{
            //    using (var conexao = Conexao.Conectar()) 
            //    {
            //        conexao.Open();

            //        string query = @"
            //        UPDATE lembretes 
            //        SET 
            //        titulo = @titulo, 
            //        descricao = @descricao, 
            //        vinculo = @vinculo, 
            //        Op = @Op 
            //        WHERE 
            //        id = @id"; 

            //        using (var comando = new MySqlCommand(query, conexao))
            //        {
            //            comando.Parameters.AddWithValue("@id", id);
            //            comando.Parameters.AddWithValue("@titulo", titulo);
            //            comando.Parameters.AddWithValue("@descricao", descricao);
            //            comando.Parameters.AddWithValue("@vinculo", vinculo);
            //            comando.Parameters.AddWithValue("@Op", op);

            //            int linhasAfetadas = comando.ExecuteNonQuery(); 


            //            return linhasAfetadas > 0;
            //        }
            //    } 
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Erro ao atualizar: " + ex.Message);
            //    return false;
            //}
        }




    }
}
