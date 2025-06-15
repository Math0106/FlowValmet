using FlowValmet.Controllers;
using FlowValmet.Idioma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                    string senhaHash = GerarHashSHA256(GNTxtSenha.Text);
                    if (GNCbxAdim.Checked)
                    {
                        perfil = "Admin";
                    }
                    else if(GnCbxUser.Checked){
                        perfil = "User";
                    }

                    Usuario.InserirUsuario(GNTxtNome.Text, GNTxtEmail.Text, GNTxtSetor.Text, perfil, senhaHash);
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
            GNDgvUsuario.DataSource = Usuario.RecuperarUsuarios("SELECT * FROM bdflowvalmet.usuario");


        }

        public void LimparCampos()
        {
            GNTxtNome.Text = "";
            GNTxtEmail.Text = "";
            GNTxtSetor.Text = "";
            GNTxtSenha.Text = "";
            GNCbxAdim.Checked = false;
            GnCbxUser.Checked = false;
        }

        public static string GerarHashSHA256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Converte a string para array de bytes e calcula o hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Converte o array de bytes para string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // "x2" formata para hexadecimal
                }

                return builder.ToString();
            }
        }



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
            GNDgvUsuario.DataSource = Usuario.RecuperarUsuarios("SELECT * FROM bdflowvalmet.usuario");
        }

        private void GNDgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LimparCampos();
            if (e.RowIndex >= 0)
            {
                var linha = GNDgvUsuario.Rows[e.RowIndex];
                if (linha.Cells[0].Value?.ToString() != "1")
                {

                    var confirmacao = MessageBox.Show($"Deseja escluir linha: {linha.Cells[0].Value?.ToString()}", linha.Cells[1].Value?.ToString(), MessageBoxButtons.OKCancel).ToString();
                    if (confirmacao == "OK")
                    {
                        Usuario.ExcluirUsuario(Convert.ToInt32(linha.Cells[0].Value?.ToString()));
                    }

                    GNDgvUsuario.ClearSelection();
                    GNDgvUsuario.DataSource = Usuario.RecuperarUsuarios("SELECT * FROM bdflowvalmet.usuario");
                }
                else
                {
                    MessageBox.Show("Não é possivel excluir o primeiro usuario!");
                }



            }

            
        }

        private void GNBtnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}

