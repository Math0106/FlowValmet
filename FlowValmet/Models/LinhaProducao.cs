using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Models
{
    internal class LinhaProducao
    {
        public int Id { get; set; }
        public string NomeLinha { get; set; }
        public string Cor { get; set; }
        public string Sigla { get; set; }

        public LinhaProducao() { }

        public LinhaProducao(string nomeLinha, string cor, string sigla)
        {
            NomeLinha = nomeLinha;
            Cor = cor;
            Sigla = sigla;
        }

        public bool Validar()
        {
            if (string.IsNullOrWhiteSpace(NomeLinha))
            {
                MessageBox.Show("O nome da linha é obrigatório");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Cor))
            {
                MessageBox.Show("A cor da linha é obrigatória");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Sigla) || Sigla.Length > 3)
            {
                MessageBox.Show("A sigla deve ter entre 1 e 3 caracteres");
                return false;
            }

            return true;
        }
    }
}