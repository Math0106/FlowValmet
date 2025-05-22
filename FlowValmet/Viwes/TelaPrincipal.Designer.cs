namespace FlowValmet.Viwes
{
    partial class TelaPrincipal
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
            this.GNPanelCentro = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.GNPanelBtnsEsquerdo = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.GNBtnOp = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNBtnProcessos = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNBtnUsuario = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.GNbtnLembretes = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNPanelLembretes = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.GNPanelBtnsEsquerdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // GNPanelCentro
            // 
            this.GNPanelCentro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GNPanelCentro.BorderRadius = 5;
            this.GNPanelCentro.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.GNPanelCentro.Location = new System.Drawing.Point(122, 5);
            this.GNPanelCentro.Name = "GNPanelCentro";
            this.GNPanelCentro.Size = new System.Drawing.Size(1400, 945);
            this.GNPanelCentro.TabIndex = 2;
            this.GNPanelCentro.Text = "guna2ContainerControl1";
            // 
            // GNPanelBtnsEsquerdo
            // 
            this.GNPanelBtnsEsquerdo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GNPanelBtnsEsquerdo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.GNPanelBtnsEsquerdo.BorderRadius = 5;
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnOp);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnProcessos);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnUsuario);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.guna2Panel1);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNbtnLembretes);
            this.GNPanelBtnsEsquerdo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.GNPanelBtnsEsquerdo.Location = new System.Drawing.Point(8, 5);
            this.GNPanelBtnsEsquerdo.Name = "GNPanelBtnsEsquerdo";
            this.GNPanelBtnsEsquerdo.Size = new System.Drawing.Size(108, 945);
            this.GNPanelBtnsEsquerdo.TabIndex = 3;
            this.GNPanelBtnsEsquerdo.Text = "guna2ContainerControl2";
            // 
            // GNBtnOp
            // 
            this.GNBtnOp.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnOp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnOp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnOp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnOp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnOp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBtnOp.ForeColor = System.Drawing.Color.White;
            this.GNBtnOp.Location = new System.Drawing.Point(22, 413);
            this.GNBtnOp.Name = "GNBtnOp";
            this.GNBtnOp.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnOp.Size = new System.Drawing.Size(60, 60);
            this.GNBtnOp.TabIndex = 4;
            this.GNBtnOp.Text = "OP";
            this.GNBtnOp.Click += new System.EventHandler(this.GNBtnOp_Click);
            // 
            // GNBtnProcessos
            // 
            this.GNBtnProcessos.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnProcessos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnProcessos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnProcessos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnProcessos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnProcessos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBtnProcessos.ForeColor = System.Drawing.Color.White;
            this.GNBtnProcessos.Location = new System.Drawing.Point(22, 520);
            this.GNBtnProcessos.Name = "GNBtnProcessos";
            this.GNBtnProcessos.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnProcessos.Size = new System.Drawing.Size(60, 60);
            this.GNBtnProcessos.TabIndex = 3;
            this.GNBtnProcessos.Text = "Processos";
            this.GNBtnProcessos.Click += new System.EventHandler(this.GNBtnProcessos_Click);
            // 
            // GNBtnUsuario
            // 
            this.GNBtnUsuario.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnUsuario.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnUsuario.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnUsuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnUsuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnUsuario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBtnUsuario.ForeColor = System.Drawing.Color.White;
            this.GNBtnUsuario.Location = new System.Drawing.Point(22, 631);
            this.GNBtnUsuario.Name = "GNBtnUsuario";
            this.GNBtnUsuario.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnUsuario.Size = new System.Drawing.Size(60, 60);
            this.GNBtnUsuario.TabIndex = 2;
            this.GNBtnUsuario.Text = "Usuário ";
            this.GNBtnUsuario.Click += new System.EventHandler(this.GNBtnUsuario_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.guna2Panel1.BackgroundImage = global::FlowValmet.Properties.Resources.LogoValmet;
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Location = new System.Drawing.Point(22, 13);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(73, 16);
            this.guna2Panel1.TabIndex = 1;
            // 
            // GNbtnLembretes
            // 
            this.GNbtnLembretes.BackColor = System.Drawing.Color.LightGray;
            this.GNbtnLembretes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNbtnLembretes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNbtnLembretes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNbtnLembretes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNbtnLembretes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNbtnLembretes.ForeColor = System.Drawing.Color.White;
            this.GNbtnLembretes.Location = new System.Drawing.Point(22, 751);
            this.GNbtnLembretes.Name = "GNbtnLembretes";
            this.GNbtnLembretes.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNbtnLembretes.Size = new System.Drawing.Size(60, 60);
            this.GNbtnLembretes.TabIndex = 0;
            this.GNbtnLembretes.Text = "Lembretes";
            this.GNbtnLembretes.Click += new System.EventHandler(this.GNbtnLembretes_Click);
            // 
            // GNPanelLembretes
            // 
            this.GNPanelLembretes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelLembretes.AutoScroll = true;
            this.GNPanelLembretes.BorderRadius = 5;
            this.GNPanelLembretes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.GNPanelLembretes.Location = new System.Drawing.Point(1528, 5);
            this.GNPanelLembretes.Name = "GNPanelLembretes";
            this.GNPanelLembretes.Size = new System.Drawing.Size(346, 945);
            this.GNPanelLembretes.TabIndex = 3;
            this.GNPanelLembretes.Text = "guna2ContainerControl1";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(89)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1882, 955);
            this.Controls.Add(this.GNPanelLembretes);
            this.Controls.Add(this.GNPanelBtnsEsquerdo);
            this.Controls.Add(this.GNPanelCentro);
            this.Name = "TelaPrincipal";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPrincipal";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.GNPanelBtnsEsquerdo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelCentro;
        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelBtnsEsquerdo;
        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelLembretes;
        private Guna.UI2.WinForms.Guna2CircleButton GNbtnLembretes;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnUsuario;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnProcessos;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnOp;
    }
}