using FlowValmet.Controllers;
using FlowValmet.Models;
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
    public partial class LoginUsuarioGUS: Form
    {

        ControleUsuario Controleusuario = new ControleUsuario();
         public LoginUsuarioGUS()
          {
           InitializeComponent();
           LimparCampos();
            TxtSenha.Text = "Matheus";
            TxtUsuario.Text = "Matheus";
          }




         public void LimparCampos()
         {
          TxtUsuario.Text = "";
          TxtSenha.Text = "";
          Lblstatus.Text = "";
          }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            // Obter os valores dos campos de entrada
            string nomeUsuario = TxtUsuario.Text.Trim();
            string senha = TxtSenha.Text;

            // Validar campos vazios
            if (string.IsNullOrEmpty(nomeUsuario) || string.IsNullOrEmpty(senha))
            {
                Lblstatus.ForeColor = Color.Red;
                Lblstatus.BackColor = Color.WhiteSmoke;
                Lblstatus.Text = "Por favor, preencha todos os campos!";
                //MessageBox.Show("Por favor, preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar credenciais no banco de dados
            try
            {
                bool credenciaisValidas = Controleusuario.VerificarCredenciais(nomeUsuario, senha);

                if (credenciaisValidas)
                {
                    // Obter informações adicionais do usuário (opcional)
                    var usuario = Controleusuario.ObterUsuarioPorNome(nomeUsuario);

                    // Armazenar informações do usuário logado (se necessário)
                    SessaoUsuario.Nome = usuario.Nome;
                    SessaoUsuario.Perfil = usuario.Perfil;
                    SessaoUsuario.Setor = usuario.Setor;
                    SessaoUsuario.Email = usuario.Email;


                    // 2. Obter referência da tela principal
                    var telaPrincipal = this.ParentForm as TelaPrincipal;

                    // 3. Fechar o painel de login
                    this.Parent.Controls.Remove(this);
                    this.Close();

                    // 4. Resetar/habilitar controles da tela principal
                    if (telaPrincipal != null)
                    {
                        telaPrincipal.ResetarTelaPrincpal();

                    }
                    LimparCampos();
                    
                    

                }
                else
                {
                    Lblstatus.ForeColor = Color.Red;
                    Lblstatus.Text = "Usuário ou senha incorretos!";
                    TxtUsuario.Text = "";
                    TxtSenha.Text = "";
                    TxtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                Lblstatus.ForeColor = Color.Red;
                Lblstatus.Text = "Erro ao tentar fazer login!";
            }
        }

   
    }
    
}
