using FlowValmet.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ConsultaProcessos
    {
        private readonly ConexaoAcess _conexao;

        public ConsultaProcessos()
        {
            _conexao = new ConexaoAcess();
        }

        public async Task<List<OpCompletaDto>> RecuperarProcessoAsync()
        {
            const string comando = @"
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
                            '|', COALESCE(p.fim, '')
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

            var listaOpCompleta = new List<OpCompletaDto>();

            try
            {
                using (var conexao = _conexao.Conectar())
                {
                    if (conexao == null)
                    {
                        MessageBox.Show("Falha na conexão com o banco de dados");
                        return listaOpCompleta;
                    }

                    await conexao.OpenAsync();

                    using (var cmd = new MySqlCommand(comando, conexao))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var processos = reader["processos"].ToString();
                            var processosLinhas = ParseProcessos(processos);

                            listaOpCompleta.Add(new OpCompletaDto
                            {
                                OpId = Convert.ToInt32(reader["op_id"]),
                                NumeroOp = reader["numeroop"].ToString(),
                                Descricao = reader["descricao"].ToString(),
                                Desenho = reader["desenho"].ToString(),
                                DataInicio = reader["op_inicio"] is DBNull ?
                                    DateTime.MinValue : Convert.ToDateTime(reader["op_inicio"]),
                                DataEntrega = reader["op_entrega"] is DBNull ?
                                    DateTime.MinValue : Convert.ToDateTime(reader["op_entrega"]),
                                Processos = processosLinhas
                            });
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro de banco de dados: {ex.Message}");
                // Logar erro completo
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao recuperar dados: {ex.Message}");
                // Logar erro completo
            }

            return listaOpCompleta;
        }

        private List<ProcessoDto> ParseProcessos(string processosConcatenados)
        {
            if (string.IsNullOrEmpty(processosConcatenados))
                return new List<ProcessoDto>();

            return processosConcatenados.Split(';')
                .Where(p => !string.IsNullOrEmpty(p))
                .Select(p =>
                {
                    var partes = p.Split('|');
                    return new ProcessoDto
                    {
                        LinhaProducao = partes.Length > 0 ? partes[0] : string.Empty,
                        Status = partes.Length > 1 ? partes[1] : string.Empty,
                        Inicio = partes.Length > 2 && DateTime.TryParse(partes[2], out var inicio) ?
                            inicio : DateTime.MinValue,
                        Fim = partes.Length > 3 && DateTime.TryParse(partes[3], out var fim) ?
                            fim : (DateTime?)null
                    };
                })
                .ToList();
        }
    }
}