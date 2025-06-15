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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.GNPanelCentro = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.GNPanelBtnsEsquerdo = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.GNBtnPCP = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNBtnVincular = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNBtnOp = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNBtnProcessos = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNBtnUsuario = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNbtnLembretes = new Guna.UI2.WinForms.Guna2CircleButton();
            this.GNPanelLembretes = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.GNPanelBtnsEsquerdo.SuspendLayout();
            this.SuspendLayout();
            // 
            // GNPanelCentro
            // 
            resources.ApplyResources(this.GNPanelCentro, "GNPanelCentro");
            this.GNPanelCentro.BorderRadius = 5;
            this.GNPanelCentro.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.GNPanelCentro.Name = "GNPanelCentro";
            this.GNPanelCentro.Click += new System.EventHandler(this.GNPanelCentro_Click);
            // 
            // GNPanelBtnsEsquerdo
            // 
            resources.ApplyResources(this.GNPanelBtnsEsquerdo, "GNPanelBtnsEsquerdo");
            this.GNPanelBtnsEsquerdo.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.GNPanelBtnsEsquerdo.BorderRadius = 5;
            this.GNPanelBtnsEsquerdo.Controls.Add(this.guna2CircleButton1);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.comboBox1);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnPCP);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnVincular);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnOp);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnProcessos);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNBtnUsuario);
            this.GNPanelBtnsEsquerdo.Controls.Add(this.GNbtnLembretes);
            this.GNPanelBtnsEsquerdo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.GNPanelBtnsEsquerdo.Name = "GNPanelBtnsEsquerdo";
            this.GNPanelBtnsEsquerdo.Click += new System.EventHandler(this.GNPanelBtnsEsquerdo_Click);
            // 
            // guna2CircleButton1
            // 
            resources.ApplyResources(this.guna2CircleButton1, "guna2CircleButton1");
            this.guna2CircleButton1.BackColor = System.Drawing.Color.LightGray;
            this.guna2CircleButton1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2CircleButton1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2CircleButton1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            resources.ApplyResources(this.comboBox1, "comboBox1");
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GNBtnPCP
            // 
            resources.ApplyResources(this.GNBtnPCP, "GNBtnPCP");
            this.GNBtnPCP.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnPCP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnPCP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnPCP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnPCP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnPCP.ForeColor = System.Drawing.Color.White;
            this.GNBtnPCP.Name = "GNBtnPCP";
            this.GNBtnPCP.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnPCP.Click += new System.EventHandler(this.GNBtnPCP_Click);
            // 
            // GNBtnVincular
            // 
            resources.ApplyResources(this.GNBtnVincular, "GNBtnVincular");
            this.GNBtnVincular.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnVincular.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnVincular.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnVincular.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnVincular.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnVincular.ForeColor = System.Drawing.Color.White;
            this.GNBtnVincular.Name = "GNBtnVincular";
            this.GNBtnVincular.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnVincular.Click += new System.EventHandler(this.GNBtnVincular_Click);
            // 
            // GNBtnOp
            // 
            resources.ApplyResources(this.GNBtnOp, "GNBtnOp");
            this.GNBtnOp.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnOp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnOp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnOp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnOp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnOp.ForeColor = System.Drawing.Color.White;
            this.GNBtnOp.Name = "GNBtnOp";
            this.GNBtnOp.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnOp.Click += new System.EventHandler(this.GNBtnOp_Click);
            // 
            // GNBtnProcessos
            // 
            resources.ApplyResources(this.GNBtnProcessos, "GNBtnProcessos");
            this.GNBtnProcessos.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnProcessos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnProcessos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnProcessos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnProcessos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnProcessos.ForeColor = System.Drawing.Color.White;
            this.GNBtnProcessos.Name = "GNBtnProcessos";
            this.GNBtnProcessos.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnProcessos.Click += new System.EventHandler(this.GNBtnProcessos_Click);
            // 
            // GNBtnUsuario
            // 
            resources.ApplyResources(this.GNBtnUsuario, "GNBtnUsuario");
            this.GNBtnUsuario.BackColor = System.Drawing.Color.LightGray;
            this.GNBtnUsuario.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnUsuario.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnUsuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnUsuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnUsuario.ForeColor = System.Drawing.Color.White;
            this.GNBtnUsuario.Name = "GNBtnUsuario";
            this.GNBtnUsuario.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNBtnUsuario.Click += new System.EventHandler(this.GNBtnUsuario_Click);
            // 
            // GNbtnLembretes
            // 
            resources.ApplyResources(this.GNbtnLembretes, "GNbtnLembretes");
            this.GNbtnLembretes.BackColor = System.Drawing.Color.LightGray;
            this.GNbtnLembretes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNbtnLembretes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNbtnLembretes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNbtnLembretes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNbtnLembretes.ForeColor = System.Drawing.Color.White;
            this.GNbtnLembretes.Name = "GNbtnLembretes";
            this.GNbtnLembretes.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.GNbtnLembretes.Click += new System.EventHandler(this.GNbtnLembretes_Click);
            // 
            // GNPanelLembretes
            // 
            resources.ApplyResources(this.GNPanelLembretes, "GNPanelLembretes");
            this.GNPanelLembretes.BorderRadius = 5;
            this.GNPanelLembretes.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(216)))), ((int)(((byte)(215)))));
            this.GNPanelLembretes.Name = "GNPanelLembretes";
            // 
            // TelaPrincipal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(89)))), ((int)(((byte)(76)))));
            this.Controls.Add(this.GNPanelLembretes);
            this.Controls.Add(this.GNPanelBtnsEsquerdo);
            this.Controls.Add(this.GNPanelCentro);
            this.Name = "TelaPrincipal";
            this.Load += new System.EventHandler(this.TelaPrincipal_Load);
            this.GNPanelBtnsEsquerdo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelCentro;
        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelBtnsEsquerdo;
        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelLembretes;
        private Guna.UI2.WinForms.Guna2CircleButton GNbtnLembretes;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnUsuario;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnProcessos;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnOp;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnVincular;
        private Guna.UI2.WinForms.Guna2CircleButton GNBtnPCP;
        private System.Windows.Forms.ComboBox comboBox1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
    }
}