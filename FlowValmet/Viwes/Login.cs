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
    public partial class Login : Form
    {
        ControleUsuario Controleusuario = new ControleUsuario();
        public Login()
        {
            InitializeComponent();
            LimparCampos();
        }

        private void GNBtnEntrar_Click(object sender, EventArgs e)
        {
            // Obter os valores dos campos de entrada
            string nomeUsuario = GNTxtNome.Text.Trim();
            string senha = GNTxtSenha.Text;

            // Validar campos vazios
            if (string.IsNullOrEmpty(nomeUsuario) || string.IsNullOrEmpty(senha))
            {
                GNLblStatusLogin.ForeColor = Color.Red;
                GNLblStatusLogin.Text = "Por favor, preencha todos os campos!";
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
                    GNLblStatusLogin.ForeColor = Color.Red;
                    GNLblStatusLogin.Text = "Usuário ou senha incorretos!";
                    GNTxtNome.Text = "";
                    GNTxtSenha.Text = "";
                    GNTxtNome.Focus();
                }
            }
            catch (Exception ex)
            {
                GNLblStatusLogin.ForeColor = Color.Red;
                GNLblStatusLogin.Text = "Erro ao tentar fazer login!";
            }
        }



        private void GNBtnLimpar_Click(object sender, EventArgs e)
        {

        }

        public void LimparCampos()
        {
            GNTxtSenha.Text = "";
            GNTxtNome.Text = "";
            GNLblStatusLogin.Text = "";
        }


    }
}
