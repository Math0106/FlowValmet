using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowValmet.Models
{
    internal class OpCompletaDto
    {

            public int OpId { get; set; }
            public string NumeroOp { get; set; }
            public string Descricao { get; set; }
            public string Desenho { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime DataEntrega { get; set; }
            public List<ProcessoDto> Processos { get; set; } = new List<ProcessoDto>();
        
    }
}
