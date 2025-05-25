namespace FlowValmet.Viwes
{
    partial class PopUPGUS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LblTitulo = new System.Windows.Forms.Label();
            this.LblMensagem = new System.Windows.Forms.Label();
            this.GNBtnCancelar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GNBtnAtualizar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.GnBtnDeletar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LblTitulo.Location = new System.Drawing.Point(12, 9);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(64, 25);
            this.LblTitulo.TabIndex = 24;
            this.LblTitulo.Text = "label1";
            // 
            // LblMensagem
            // 
            this.LblMensagem.AutoSize = true;
            this.LblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LblMensagem.Location = new System.Drawing.Point(13, 66);
            this.LblMensagem.Name = "LblMensagem";
            this.LblMensagem.Size = new System.Drawing.Size(51, 20);
            this.LblMensagem.TabIndex = 25;
            this.LblMensagem.Text = "label2";
            // 
            // GNBtnCancelar
            // 
            this.GNBtnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNBtnCancelar.BorderRadius = 20;
            this.GNBtnCancelar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnCancelar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnCancelar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnCancelar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnCancelar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnCancelar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.GNBtnCancelar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.GNBtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GNBtnCancelar.ForeColor = System.Drawing.Color.White;
            this.GNBtnCancelar.Image = global::FlowValmet.Properties.Resources.cancelar;
            this.GNBtnCancelar.Location = new System.Drawing.Point(264, 135);
            this.GNBtnCancelar.Name = "GNBtnCancelar";
            this.GNBtnCancelar.Size = new System.Drawing.Size(119, 48);
            this.GNBtnCancelar.TabIndex = 23;
            this.GNBtnCancelar.Text = "Cancelar";
            this.GNBtnCancelar.Click += new System.EventHandler(this.GNBtnCancelar_Click_1);
            // 
            // GNBtnAtualizar
            // 
            this.GNBtnAtualizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNBtnAtualizar.BorderRadius = 20;
            this.GNBtnAtualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnAtualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnAtualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnAtualizar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnAtualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnAtualizar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.GNBtnAtualizar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.GNBtnAtualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GNBtnAtualizar.ForeColor = System.Drawing.Color.White;
            this.GNBtnAtualizar.Image = global::FlowValmet.Properties.Resources.limpar_limpo;
            this.GNBtnAtualizar.Location = new System.Drawing.Point(138, 135);
            this.GNBtnAtualizar.Name = "GNBtnAtualizar";
            this.GNBtnAtualizar.Size = new System.Drawing.Size(119, 48);
            this.GNBtnAtualizar.TabIndex = 22;
            this.GNBtnAtualizar.Text = "Atualizar";
            this.GNBtnAtualizar.Click += new System.EventHandler(this.GNBtnAtualizar_Click_1);
            // 
            // GnBtnDeletar
            // 
            this.GnBtnDeletar.BorderRadius = 20;
            this.GnBtnDeletar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GnBtnDeletar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GnBtnDeletar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GnBtnDeletar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GnBtnDeletar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GnBtnDeletar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.GnBtnDeletar.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.GnBtnDeletar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.GnBtnDeletar.ForeColor = System.Drawing.Color.White;
            this.GnBtnDeletar.Image = global::FlowValmet.Properties.Resources.lixeira;
            this.GnBtnDeletar.Location = new System.Drawing.Point(9, 135);
            this.GnBtnDeletar.Name = "GnBtnDeletar";
            this.GnBtnDeletar.Size = new System.Drawing.Size(119, 48);
            this.GnBtnDeletar.TabIndex = 21;
            this.GnBtnDeletar.Text = "Deletar";
            this.GnBtnDeletar.Click += new System.EventHandler(this.GnBtnDeletar_Click);
            // 
            // PopUPGUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(395, 187);
            this.ControlBox = false;
            this.Controls.Add(this.GNBtnCancelar);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.GNBtnAtualizar);
            this.Controls.Add(this.LblMensagem);
            this.Controls.Add(this.GnBtnDeletar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Location = new System.Drawing.Point(1000, 15);
            this.MaximizeBox = false;
            this.Name = "PopUPGUS";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientButton GnBtnDeletar;
        private Guna.UI2.WinForms.Guna2GradientButton GNBtnAtualizar;
        private Guna.UI2.WinForms.Guna2GradientButton GNBtnCancelar;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label LblMensagem;
    }
}