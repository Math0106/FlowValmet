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
    public partial class CadastroUsuarioGUS: Form
    {

        ControleUsuario Usuario = new ControleUsuario();
        DesingDataGridView DesingDataGridView = new DesingDataGridView();
        public CadastroUsuarioGUS()
        {
            InitializeComponent();
            LimparCampos();
            TrocarIdioma();

        }

        public void TrocarIdioma()
        {
            switch (SessaoIdioma.Idioma)
            {
                case "en":
                    {
                        TxtEmail.PlaceholderText = "Email";
                        TxtUsuario.PlaceholderText = "User";
                        TxtSenha.PlaceholderText = "Password";
                        TxtSetor.PlaceholderText = "Sector";
                        GNLblAdim.Text = "Administrator";
                        GNLblUsuario.Text = "User";
                        BtnRegistrar.Text = "Register";
                        BtnAtualizar.Text = "Update";
                        BtnLimpar.Text = "Clear";

                        GNDgvUsuario.Columns["id"].HeaderText = "Id"; // string
                        GNDgvUsuario.Columns["usuario_nome"].HeaderText = "User"; // string
                        GNDgvUsuario.Columns["email"].HeaderText = "Email"; // string
                        GNDgvUsuario.Columns["setor"].HeaderText = "Sector"; // DateTime
                        GNDgvUsuario.Columns["perfil"].HeaderText = "Profile"; // DateTime
                        break;
                    }
                case "es":
                    {
                        TxtEmail.PlaceholderText = "Correo electrónico";
                        TxtUsuario.PlaceholderText = "Usuario";
                        TxtSenha.PlaceholderText = "Contraseña";
                        TxtSetor.PlaceholderText = "Sector";
                        GNLblAdim.Text = "Administrador";
                        GNLblUsuario.Text = "Usuario";
                        BtnRegistrar.Text = "Registro";
                        BtnAtualizar.Text = "Actualizar";
                        BtnLimpar.Text = "Limpiar";

                        GNDgvUsuario.Columns["id"].HeaderText = "Id"; // string
                        GNDgvUsuario.Columns["usuario_nome"].HeaderText = "Usuario"; // string
                        GNDgvUsuario.Columns["email"].HeaderText = "Correo electrónico"; // string
                        GNDgvUsuario.Columns["setor"].HeaderText = "Sector"; // DateTime
                        GNDgvUsuario.Columns["perfil"].HeaderText = "Perfil"; // DateTime
                        break;
                    }
                case "pt":
                    {
                        TxtEmail.PlaceholderText = "Email";
                        TxtUsuario.PlaceholderText = "Usuário";
                        TxtSenha.PlaceholderText = "Senha";
                        TxtSetor.PlaceholderText = "Setor";
                        GNLblAdim.Text = "Administrador";
                        GNLblUsuario.Text = "Usuário";
                        BtnRegistrar.Text = "Cadastrar";
                        BtnAtualizar.Text = "Atualizar";
                        BtnLimpar.Text = "Limpar";

                        GNDgvUsuario.Columns["id"].HeaderText = "Id"; // string
                        GNDgvUsuario.Columns["usuario_nome"].HeaderText = "Usuário"; // string
                        GNDgvUsuario.Columns["email"].HeaderText = "Email"; // string
                        GNDgvUsuario.Columns["setor"].HeaderText = "Setor"; // DateTime
                        GNDgvUsuario.Columns["perfil"].HeaderText = "Perfil"; // DateTime
                        break;
                    }
                default:
                    {
                        TxtEmail.PlaceholderText = "Email";
                        TxtUsuario.PlaceholderText = "Usuário";
                        TxtSenha.PlaceholderText = "Senha";
                        TxtSetor.PlaceholderText = "Setor";
                        GNLblAdim.Text = "Administrador";
                        GNLblUsuario.Text = "Usuário";
                        BtnRegistrar.Text = "Cadastrar";
                        BtnAtualizar.Text = "Atualizar";
                        BtnLimpar.Text = "Limpar";

                        GNDgvUsuario.Columns["id"].HeaderText = "Id"; // string
                        GNDgvUsuario.Columns["usuario_nome"].HeaderText = "Usuário"; // string
                        GNDgvUsuario.Columns["email"].HeaderText = "Email"; // string
                        GNDgvUsuario.Columns["setor"].HeaderText = "Setor"; // DateTime
                        GNDgvUsuario.Columns["perfil"].HeaderText = "Perfil"; // DateTime
                        break;
                    }
            }
        }


        public void LimparCampos()
        {
            GNLblUsuarioId.Text = "";
            TxtUsuario.Text = "";
            TxtEmail.Text = "";
            TxtSetor.Text = "";
            TxtSenha.Text = "";
            GNCbxAdim.Checked = false;
            GNCbxUser.Checked = false;
            BtnRegistrar.Enabled = true;
            BtnAtualizar.Enabled = false;
            DesingDataGridView.DesignGunaDataGrid(GNDgvUsuario);
            CarregarUsuario();
            GNDgvUsuario.ClearSelection();
        }
        public void CarregarUsuario()
        {
            try
            {
                var listaDados = Usuario.RecuperarUsuarios("SELECT * FROM bdflowvalmet.usuario where id != 1");

                // Limpa dados existentes (opcional)
                GNDgvUsuario.Rows.Clear();

                // Verifica se há dados
                if (listaDados != null && listaDados.Any())
                {
                    foreach (var tupla in listaDados)
                    {
                            int rowIndex = GNDgvUsuario.Rows.Add();

                            // Preenche cada célula com os elementos da tupla
                            GNDgvUsuario.Rows[rowIndex].Cells["id"].Value = tupla.Item1; // string
                            GNDgvUsuario.Rows[rowIndex].Cells["usuario_nome"].Value = tupla.Item2; // string
                            GNDgvUsuario.Rows[rowIndex].Cells["email"].Value = tupla.Item3; // string
                            GNDgvUsuario.Rows[rowIndex].Cells["setor"].Value = tupla.Item4; // DateTime
                            GNDgvUsuario.Rows[rowIndex].Cells["perfil"].Value = tupla.Item5; // DateTime

                    }
                }


            }
            catch
            {

                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error loading!");

                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al cargar!");
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao carregar!");
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao carregar!");
                            break;
                        }
                }

            }
        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            string perfil = "User";
            try
            {

                if (TxtUsuario.Text != "" &&
                   TxtEmail.Text != "" &&
                   TxtSetor.Text != "" &&
                   TxtSenha.Text != "" &&
                   (GNCbxAdim.Checked || GNCbxUser.Checked))
                {
                    string senhaHash = Usuario.GerarHashSHA256(TxtSenha.Text);
                    if (GNCbxAdim.Checked)
                    {
                        perfil = "Admin";
                    }
                    else if (GNCbxUser.Checked)
                    {
                        perfil = "User";
                    }

                    Usuario.InserirUsuario(TxtUsuario.Text, TxtEmail.Text.ToLower(), TxtSetor.Text, perfil, senhaHash);
                    LimparCampos();
                }
                else
                {
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Fill in all fields!");

                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("Complete todos los campos!");
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                    }

                }

            }
            catch (Exception ex)
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error registering!" + ex);

                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al registrarse!" + ex);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao cadastrar: " + ex);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao cadastrar: " + ex);
                            break;
                        }
                }

                LimparCampos();
            }
        }

        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            string perfil = "User";
            try
            {

                if (TxtUsuario.Text != "" &&
                   TxtEmail.Text != "" &&
                   TxtSetor.Text != "" &&
                   TxtSenha.Text != "" &&
                   (GNCbxAdim.Checked || GNCbxUser.Checked))
                {
                    string senhaHash = Usuario.GerarHashSHA256(TxtSenha.Text);
                    if (GNCbxAdim.Checked)
                    {
                        perfil = "Admin";
                    }
                    else if (GNCbxUser.Checked)
                    {
                        perfil = "User";
                    }

                    Usuario.AtualizarUsuario(Convert.ToInt32(GNLblUsuarioId.Text), TxtUsuario.Text, TxtEmail.Text.ToLower(), TxtSetor.Text, perfil, senhaHash);
                    LimparCampos();
                }
                else
                {
                    switch (SessaoIdioma.Idioma)
                    {
                        case "en":
                            {
                                MessageBox.Show("Fill in all fields");

                                break;
                            }
                        case "es":
                            {
                                MessageBox.Show("Complete todos los campos");
                                break;
                            }
                        case "pt":
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Preencher todos os campos");
                                break;
                            }
                    }
                }

            }
            catch (Exception ex)
            {
                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            MessageBox.Show("Error registering!" + ex);

                            break;
                        }
                    case "es":
                        {
                            MessageBox.Show("Error al registrarse!" + ex);
                            break;
                        }
                    case "pt":
                        {
                            MessageBox.Show("Erro ao cadastrar: " + ex);
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Erro ao cadastrar: " + ex);
                            break;
                        }
                }
                LimparCampos();
            }
        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void GNDgvUsuario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            LimparCampos();
            if (e.RowIndex >= 0)
            {

                var linha = GNDgvUsuario.Rows[e.RowIndex];

                string titulo;
                string descrição;

                switch (SessaoIdioma.Idioma)
                {
                    case "en":
                        {
                            titulo = "User registration";
                            descrição = "Do you really want to continue?";

                            break;
                        }
                    case "es":
                        {
                            titulo = "Registro de usuario";
                            descrição = "Realmente deseas continuar?";
                            break;
                        }
                    case "pt":
                        {
                            titulo = "Cadastro Usuário";
                            descrição = "Deseja realmente continuar?";
                            break;
                        }
                    default:
                        {
                            titulo = "Cadastro Usuário";
                            descrição = "Deseja realmente continuar?";
                            break;
                        }
                }


                var form = new PopUPGUS(titulo, descrição);
                    form.ShowDialog();

                    switch (form.Result)
                    {
                        case PopUPGUS.CustomDialogResult.Excluir:
                            Usuario.ExcluirUsuario(Convert.ToInt32(linha.Cells[0].Value?.ToString()));
                            LimparCampos();
                            break;
                        case PopUPGUS.CustomDialogResult.Alterar:
                            GNLblUsuarioId.Text = linha.Cells[0].Value?.ToString();
                            TxtUsuario.Text = linha.Cells[1].Value?.ToString();
                            TxtEmail.Text = linha.Cells[2].Value?.ToString().ToLower();
                            TxtSetor.Text = linha.Cells[3].Value?.ToString();
                            if (linha.Cells[4].Value?.ToString() == "Admin")
                            {
                                GNCbxAdim.Checked = true;
                                GNCbxUser.Checked = false;

                            }
                            else if (linha.Cells[4].Value?.ToString() == "User")
                            {
                                GNCbxAdim.Checked = false;
                                GNCbxUser.Checked = true;
                            }

                            BtnRegistrar.Enabled = false;
                            BtnAtualizar.Enabled = true;
                            break;
                        case PopUPGUS.CustomDialogResult.Cancelar:
                            break;
                    }

            }
        }

        private void GNCbxAdim_Click_1(object sender, EventArgs e)
        {
            if (GNCbxAdim.Checked)
            {
                GNCbxUser.Checked = false;
            }
        }

        private void GNCbxUser_Click_1(object sender, EventArgs e)
        {
            if (GNCbxUser.Checked)
            {
                GNCbxAdim.Checked = false;
            }
        }
    }
}

