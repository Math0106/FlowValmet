using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.Model
{
     public class Projeto
    {
        public int id_projeto { get; set; }

        public int Pri { get; set; }

        public string BU { get; set; }

        public string PCs { get; set; }


        public int Cliente { get; set; }

        public string Item { get; set; }
        public DateTime?   DataPrazo { get; set; }
        public DateTime? DataReprogramada { get; set; }

        public string Res { get; set; }
        public decimal Custo { get; set; }
        public int Semana { get; set; }
       
           
        
    }
}
