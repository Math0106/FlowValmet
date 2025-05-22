using FlowValmet.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace FlowValmet.Viwes
{
    public partial class CadastrarUsuario : Form
    {
        ControleUsuario Usuario = new ControleUsuario();
        public CadastrarUsuario()
        {
            InitializeComponent();
            
        }

        private void GBBtnCadastrar_Click(object sender, EventArgs e)
        {
            string perfil = "User";
            try
            {
                
                if(GNTxtNome.Text != "" &&
                   GNTxtEmail.Text != "" &&
                   GNTxtSetor.Text != "" &&
                   GNTxtSenha.Text != "" &&
                   (GNCbxAdim.Checked || GnCbxUser.Checked))
                {
                    string senhaHash = Usuario.GerarHashSHA256(GNTxtSenha.Text);
                    if (GNCbxAdim.Checked)
                    {
                        perfil = "Admin";
                    }
                    else if(GnCbxUser.Checked){
                        perfil = "User";
                    }

                    Usuario.InserirUsuario(GNTxtNome.Text, GNTxtEmail.Text.ToLower(), GNTxtSetor.Text, perfil, senhaHash);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Preencher todos os campos");
                }

            } catch (Exception ex) {
                MessageBox.Show("Erro ao cadastrar: " + ex);
                LimparCampos();
            }
        }

        public void LimparCampos()
        {
            GNLblUsuarioId.Text = "";
            GNTxtNome.Text = "";
            GNTxtEmail.Text = "";
            GNTxtSetor.Text = "";
            GNTxtSenha.Text = "";
            GNCbxAdim.Checked = false;
            GnCbxUser.Checked = false;
            GNBtnCadastrar.Enabled = true;
            GNBtnAtualizar.Enabled = false;
            GNDgvUsuario.DataSource = Usuario.RecuperarUsuarios("SELECT * FROM bdflowvalmet.usuario");
            GNDgvUsuario.ClearSelection();
        }

        //public static string GerarHashSHA256(string input)
        //{
        //    using (SHA256 sha256Hash = SHA256.Create())
        //    {
        //        // Converte a string para array de bytes e calcula o hash
        //        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        //        // Converte o array de bytes para string hexadecimal
        //        StringBuilder builder = new StringBuilder();
        //        for (int i = 0; i < bytes.Length; i++)
        //        {
        //            builder.Append(bytes[i].ToString("x2")); // "x2" formata para hexadecimal
        //        }

        //        return builder.ToString();
        //    }
        //}



        private void GnCbxUser_Click(object sender, EventArgs e)
        {
            if (GnCbxUser.Checked)
            {
                GNCbxAdim.Checked = false;
            }
        }

        private void GNCbxAdim_Click(object sender, EventArgs e)
        {
            if (GNCbxAdim.Checked)
            {
                GnCbxUser.Checked = false;
            }
        }

        private void CadastrarUsuario_Load(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void GNDgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCampos();
            if (e.RowIndex >= 0)
            {

                var linha = GNDgvUsuario.Rows[e.RowIndex];
                if (linha.Cells[0].Value?.ToString() != "1")
                {
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
                            GNTxtNome.Text = linha.Cells[1].Value?.ToString();
                            GNTxtEmail.Text = linha.Cells[2].Value?.ToString().ToLower();
                            GNTxtSetor.Text = linha.Cells[3].Value?.ToString();
                            if (linha.Cells[4].Value?.ToString() == "Admin")
                            {
                                GNCbxAdim.Checked = true;
                                GnCbxUser.Checked = false;

                            }
                            else if (linha.Cells[4].Value?.ToString() == "User")
                            {
                                GNCbxAdim.Checked = false;
                                GnCbxUser.Checked = true;
                            }

                            GNBtnCadastrar.Enabled = false;
                            GNBtnAtualizar.Enabled = true;
                            break;
                        case PopUPGUS.CustomDialogResult.Cancelar:
                            break;
                    }

                }else
                {
                    MessageBox.Show("Não é possivel manipular o primeiro usuario!");
                }

            }


        }

        private void GNBtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void GNBtnAtualizar_Click(object sender, EventArgs e)
        {
            string perfil = "User";
            try
            {

                if (GNTxtNome.Text != "" &&
                   GNTxtEmail.Text != "" &&
                   GNTxtSetor.Text != "" &&
                   GNTxtSenha.Text != "" &&
                   (GNCbxAdim.Checked || GnCbxUser.Checked))
                {
                    string senhaHash = Usuario.GerarHashSHA256(GNTxtSenha.Text);
                    if (GNCbxAdim.Checked)
                    {
                        perfil = "Admin";
                    }
                    else if (GnCbxUser.Checked)
                    {
                        perfil = "User";
                    }

                    Usuario.AtualizarUsuario(Convert.ToInt32(GNLblUsuarioId.Text),GNTxtNome.Text, GNTxtEmail.Text.ToLower(), GNTxtSetor.Text, perfil, senhaHash);
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
    }
}
