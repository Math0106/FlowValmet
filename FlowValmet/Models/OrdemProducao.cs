using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Models
{
    internal class OrdemProducao
    {
        public string NumeroOp { get; set; }
        public string Descricao { get; set; }
        public string Desenho { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataEntrega { get; set; }
        public string LinhasProducao { get; set; } // Lista de siglas separadas por vírgula

        public OrdemProducao() { }

        public OrdemProducao(string numeroOp, string descricao, string desenho,
                       DateTime dataInicio, DateTime dataEntrega, string linhasProducao)
        {
            NumeroOp = numeroOp;
            Descricao = descricao;
            Desenho = desenho;
            DataInicio = dataInicio;
            DataEntrega = dataEntrega;
            LinhasProducao = linhasProducao;
        }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(NumeroOp))
            {
                MessageBox.Show("Número da OP é obrigatório");
                return false;
            }

            if (DataInicio > DataEntrega)
            {
                MessageBox.Show("Data de início não pode ser posterior à data de entrega");
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{NumeroOp} - {Descricao} (Início: {DataInicio:dd/MM/yyyy})";
        }
    }
}