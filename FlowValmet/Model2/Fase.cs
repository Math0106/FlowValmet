using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FlowValmet.Model2
{
    public class Fase
    {
        public int IdFase { get; set; }
        public int ProjetoId { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string nomeFase { get; set; }      
        public string Observacao { get; set; }
        public string Status { get; set; }

        // Propriedade auxiliar para verificar se a fase está atrasada
        public bool EstaAtrasada
        {
            get
            {
                return (DateTime.Now > DataFinal) && (Status != "Concluído");
            }
        }
    }
}
