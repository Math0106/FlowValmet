using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowValmet.Models
{
    public class ProcessoDto
    {
        public string LinhaProducao { get; set; }
        public string Status { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
    }
}
