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
    public partial class CadastroUsuarioGUS: Form
    {

        ControleUsuario Usuario = new ControleUsuario();
        DesingDataGridView DesingDataGridView = new DesingDataGridView();
        public CadastroUsuarioGUS()
        {
            InitializeComponent();
            LimparCampos();

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
                MessageBox.Show("Erro ao carregar!");
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
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
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
                    MessageBox.Show("Preencher todos os campos");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex);
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

                    var form = new PopUPGUS("Cadastro Usuário", "Deseja realmente continuar?");
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

