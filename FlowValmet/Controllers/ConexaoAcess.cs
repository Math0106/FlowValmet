using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Controllers
{
    internal class ConexaoAcess
    {
        public MySqlConnection Conectar()
        {
            try
            {
                var strConexao = "server=localhost;uid=root;pwd=132318;database=BDFLowValmet";
                var conexao = new MySqlConnection(strConexao);
                
                return conexao;
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Erro ao conectar: // talvez sem pwd " + ex.Message);
                return null; // Se falhar, retorna nulo
            }
        }

    }
}
