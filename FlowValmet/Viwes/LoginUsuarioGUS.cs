using FlowValmet.Controllers;
using FlowValmet.Models;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowValmet.Viwes
{
    public partial class LoginUsuarioGUS : Form
    {

        ControleUsuario Controleusuario = new ControleUsuario();
        public LoginUsuarioGUS()
        {
            InitializeComponent();
            LimparCampos();
            TxtSenha.Text = "Matheus";
            TxtUsuario.Text = "Matheus";
            TrocaIdioma(SessaoIdioma.Idioma);
        }

        public void TrocaIdioma(string idioma)
        {
            switch (idioma)
            {
                case "en":
                    {
                        TxtUsuario.PlaceholderText = "User";
                        TxtSenha.PlaceholderText = "Password";
                        BtnLogin.Text = "Login";
                        break;
                    }
                case "es":
                    {
                        TxtUsuario.PlaceholderText = "Usuario";
                        TxtSenha.PlaceholderText = "Contraseña";
                        BtnLogin.Text = "Acceso";

                        break;
                    }
                case "pt":
                    {
                        TxtUsuario.PlaceholderText = "Usuário";
                        TxtSenha.PlaceholderText = "Senha";
                        BtnLogin.Text = "Entrar";
                        break;
                    }
                default:
                    {
                        TxtUsuario.PlaceholderText = "Usuário";
                        TxtSenha.PlaceholderText = "Senha";
                        BtnLogin.Text = "Entrar";
                        break;
                    }
            }

        }




        public void LimparCampos()
        {
            TxtUsuario.Text = "";
            TxtSenha.Text = "";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            // Obter os valores dos campos de entrada
            string nomeUsuario = TxtUsuario.Text.Trim();
            string senha = TxtSenha.Text;

            // Validar campos vazios
            if (string.IsNullOrEmpty(nomeUsuario) || string.IsNullOrEmpty(senha))
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Por favor, rellene todos los campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Por favor, preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Por favor, preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                }
                
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
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Incorrect username or password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("Nombre de usuario o contraseña incorrectos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Usuário ou senha incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Usuário ou senha incorretos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                    }
                    TxtUsuario.Text = "";
                    TxtSenha.Text = "";
                    TxtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error trying to log in!" + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al intentar iniciar sesión!" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao tentar fazer login!" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao tentar fazer login!" + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                }


            }
        }

        private void Lblstatus_Click(object sender, EventArgs e)
        {

        }
    }
}
