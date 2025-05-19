using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowValmet.Models
{
    public class Lembrete
    {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Descricao { get; set; }
            public bool Vinculo { get; set; }
            public string Op { get; set; }


            public Lembrete(int id, string titulo, string descricao, bool vinculo, string op)
            {
                Id = id;
                Titulo = titulo;
                Descricao = descricao;
                Vinculo = vinculo;
                Op = op;
            }

            public bool Validar()
            {
                // Validação básica dos campos obrigatórios
                if (string.IsNullOrWhiteSpace(Titulo))
                    return false;

                // Se tiver vínculo, OP é obrigatória
                if (Vinculo && string.IsNullOrWhiteSpace(Op))
                    return false;

                return true;
            }
        
    }
}
