using FlowValmet.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class VincularProcessos : Form
    {
        ControleVincularProcessos Vincular = new ControleVincularProcessos();
        public VincularProcessos()
        {
            InitializeComponent();
            //GNDgvVinculado.DataSource = Vincular.RecuperarOp_id_numeroOP_descricao("SELECT id,numeroop,descricao FROM bdflowvalmet.op");
            GNCbxOps.DataSource = Vincular.RecuperarOp_id_numeroOP_descricao("SELECT id,numeroop,descricao FROM bdflowvalmet.op");
            GnCbxProcessos.DataSource = Vincular.RecuperarLinhaProducao_id_linha_sigla("SELECT id,linha,sigla FROM bdflowvalmet.linhaproducao");
        }
    }
}
