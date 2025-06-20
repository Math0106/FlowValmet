namespace FlowValmet.Viwes
{
    partial class CadastroUsuarioGUS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.GNDgvUsuario = new Guna.UI2.WinForms.Guna2DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario_nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.GNLblUsuarioId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNLblUsuario = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNLblAdim = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNCbxUser = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.GNCbxAdim = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.TxtSetor = new Guna.UI2.WinForms.Guna2TextBox();
            this.picture2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.TxtSenha = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnLimpar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TxtUsuario = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnAtualizar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.TxtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.BtnRegistrar = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNDgvUsuario)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderColor = System.Drawing.Color.Transparent;
            this.panel2.BorderRadius = 20;
            this.panel2.Controls.Add(this.guna2Panel1);
            this.panel2.Controls.Add(this.guna2Panel2);
            this.panel2.FillColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(142, 148);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1098, 605);
            this.panel2.TabIndex = 1;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Teal;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.GNDgvUsuario);
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Location = new System.Drawing.Point(551, 21);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(532, 566);
            this.guna2Panel1.TabIndex = 32;
            // 
            // GNDgvUsuario
            // 
            this.GNDgvUsuario.AllowUserToAddRows = false;
            this.GNDgvUsuario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.GNDgvUsuario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GNDgvUsuario.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GNDgvUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GNDgvUsuario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GNDgvUsuario.ColumnHeadersHeight = 4;
            this.GNDgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDgvUsuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.usuario_nome,
            this.email,
            this.setor,
            this.perfil});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GNDgvUsuario.DefaultCellStyle = dataGridViewCellStyle3;
            this.GNDgvUsuario.GridColor = System.Drawing.Color.White;
            this.GNDgvUsuario.Location = new System.Drawing.Point(18, 20);
            this.GNDgvUsuario.Name = "GNDgvUsuario";
            this.GNDgvUsuario.ReadOnly = true;
            this.GNDgvUsuario.RowHeadersVisible = false;
            this.GNDgvUsuario.RowHeadersWidth = 49;
            this.GNDgvUsuario.RowTemplate.Height = 24;
            this.GNDgvUsuario.Size = new System.Drawing.Size(499, 530);
            this.GNDgvUsuario.TabIndex = 32;
            this.GNDgvUsuario.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GNDgvUsuario.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GNDgvUsuario.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GNDgvUsuario.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GNDgvUsuario.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GNDgvUsuario.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNDgvUsuario.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.GNDgvUsuario.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GNDgvUsuario.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GNDgvUsuario.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDgvUsuario.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GNDgvUsuario.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDgvUsuario.ThemeStyle.HeaderStyle.Height = 4;
            this.GNDgvUsuario.ThemeStyle.ReadOnly = true;
            this.GNDgvUsuario.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GNDgvUsuario.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GNDgvUsuario.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDgvUsuario.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GNDgvUsuario.ThemeStyle.RowsStyle.Height = 24;
            this.GNDgvUsuario.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDgvUsuario.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GNDgvUsuario.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GNDgvUsuario_CellContentClick_1);
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // usuario_nome
            // 
            this.usuario_nome.HeaderText = "Usuario";
            this.usuario_nome.MinimumWidth = 6;
            this.usuario_nome.Name = "usuario_nome";
            this.usuario_nome.ReadOnly = true;
            // 
            // email
            // 
            this.email.HeaderText = "Email";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // setor
            // 
            this.setor.HeaderText = "Setor";
            this.setor.MinimumWidth = 6;
            this.setor.Name = "setor";
            this.setor.ReadOnly = true;
            // 
            // perfil
            // 
            this.perfil.HeaderText = "Perfil";
            this.perfil.MinimumWidth = 6;
            this.perfil.Name = "perfil";
            this.perfil.ReadOnly = true;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Teal;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.GNLblUsuarioId);
            this.guna2Panel2.Controls.Add(this.GNLblUsuario);
            this.guna2Panel2.Controls.Add(this.GNLblAdim);
            this.guna2Panel2.Controls.Add(this.GNCbxUser);
            this.guna2Panel2.Controls.Add(this.GNCbxAdim);
            this.guna2Panel2.Controls.Add(this.TxtSetor);
            this.guna2Panel2.Controls.Add(this.picture2);
            this.guna2Panel2.Controls.Add(this.TxtSenha);
            this.guna2Panel2.Controls.Add(this.BtnLimpar);
            this.guna2Panel2.Controls.Add(this.TxtUsuario);
            this.guna2Panel2.Controls.Add(this.BtnAtualizar);
            this.guna2Panel2.Controls.Add(this.TxtEmail);
            this.guna2Panel2.Controls.Add(this.BtnRegistrar);
            this.guna2Panel2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.Location = new System.Drawing.Point(15, 21);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(532, 566);
            this.guna2Panel2.TabIndex = 31;
            // 
            // GNLblUsuarioId
            // 
            this.GNLblUsuarioId.BackColor = System.Drawing.Color.Transparent;
            this.GNLblUsuarioId.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNLblUsuarioId.Location = new System.Drawing.Point(25, 213);
            this.GNLblUsuarioId.Name = "GNLblUsuarioId";
            this.GNLblUsuarioId.Size = new System.Drawing.Size(12, 21);
            this.GNLblUsuarioId.TabIndex = 33;
            this.GNLblUsuarioId.Text = "...";
            // 
            // GNLblUsuario
            // 
            this.GNLblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.GNLblUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNLblUsuario.Location = new System.Drawing.Point(312, 374);
            this.GNLblUsuario.Name = "GNLblUsuario";
            this.GNLblUsuario.Size = new System.Drawing.Size(31, 21);
            this.GNLblUsuario.TabIndex = 24;
            this.GNLblUsuario.Text = "User";
            // 
            // GNLblAdim
            // 
            this.GNLblAdim.BackColor = System.Drawing.Color.Transparent;
            this.GNLblAdim.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNLblAdim.Location = new System.Drawing.Point(312, 348);
            this.GNLblAdim.Name = "GNLblAdim";
            this.GNLblAdim.Size = new System.Drawing.Size(96, 21);
            this.GNLblAdim.TabIndex = 23;
            this.GNLblAdim.Text = "Adiministrador";
            // 
            // GNCbxUser
            // 
            this.GNCbxUser.BackColor = System.Drawing.Color.White;
            this.GNCbxUser.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxUser.CheckedState.BorderRadius = 2;
            this.GNCbxUser.CheckedState.BorderThickness = 0;
            this.GNCbxUser.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxUser.Location = new System.Drawing.Point(286, 374);
            this.GNCbxUser.Name = "GNCbxUser";
            this.GNCbxUser.Size = new System.Drawing.Size(20, 20);
            this.GNCbxUser.TabIndex = 22;
            this.GNCbxUser.Text = "guna2CustomCheckBox1";
            this.GNCbxUser.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCbxUser.UncheckedState.BorderRadius = 2;
            this.GNCbxUser.UncheckedState.BorderThickness = 0;
            this.GNCbxUser.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCbxUser.Click += new System.EventHandler(this.GNCbxUser_Click_1);
            // 
            // GNCbxAdim
            // 
            this.GNCbxAdim.BackColor = System.Drawing.Color.White;
            this.GNCbxAdim.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxAdim.CheckedState.BorderRadius = 2;
            this.GNCbxAdim.CheckedState.BorderThickness = 0;
            this.GNCbxAdim.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxAdim.Location = new System.Drawing.Point(286, 348);
            this.GNCbxAdim.Name = "GNCbxAdim";
            this.GNCbxAdim.Size = new System.Drawing.Size(20, 20);
            this.GNCbxAdim.TabIndex = 21;
            this.GNCbxAdim.Text = "guna2CustomCheckBox1";
            this.GNCbxAdim.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCbxAdim.UncheckedState.BorderRadius = 2;
            this.GNCbxAdim.UncheckedState.BorderThickness = 0;
            this.GNCbxAdim.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCbxAdim.Click += new System.EventHandler(this.GNCbxAdim_Click_1);
            // 
            // TxtSetor
            // 
            this.TxtSetor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtSetor.BorderColor = System.Drawing.Color.Teal;
            this.TxtSetor.BorderRadius = 20;
            this.TxtSetor.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtSetor.DefaultText = "";
            this.TxtSetor.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtSetor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtSetor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtSetor.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtSetor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtSetor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TxtSetor.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtSetor.Location = new System.Drawing.Point(274, 294);
            this.TxtSetor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSetor.Name = "TxtSetor";
            this.TxtSetor.PlaceholderText = "Setor";
            this.TxtSetor.SelectedText = "";
            this.TxtSetor.Size = new System.Drawing.Size(247, 48);
            this.TxtSetor.TabIndex = 20;
            // 
            // picture2
            // 
            this.picture2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picture2.Image = global::FlowValmet.Properties.Resources.profile;
            this.picture2.ImageRotate = 0F;
            this.picture2.Location = new System.Drawing.Point(167, 20);
            this.picture2.Name = "picture2";
            this.picture2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picture2.Size = new System.Drawing.Size(200, 200);
            this.picture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture2.TabIndex = 19;
            this.picture2.TabStop = false;
            // 
            // TxtSenha
            // 
            this.TxtSenha.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtSenha.BorderColor = System.Drawing.Color.Teal;
            this.TxtSenha.BorderRadius = 20;
            this.TxtSenha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtSenha.DefaultText = "";
            this.TxtSenha.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtSenha.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtSenha.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtSenha.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtSenha.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtSenha.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TxtSenha.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtSenha.IconLeftSize = new System.Drawing.Size(18, 18);
            this.TxtSenha.IconRightSize = new System.Drawing.Size(15, 15);
            this.TxtSenha.Location = new System.Drawing.Point(16, 350);
            this.TxtSenha.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.PasswordChar = '*';
            this.TxtSenha.PlaceholderText = "Senha";
            this.TxtSenha.SelectedText = "";
            this.TxtSenha.Size = new System.Drawing.Size(247, 48);
            this.TxtSenha.TabIndex = 17;
            // 
            // BtnLimpar
            // 
            this.BtnLimpar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnLimpar.BorderRadius = 20;
            this.BtnLimpar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnLimpar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnLimpar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnLimpar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnLimpar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnLimpar.FillColor = System.Drawing.Color.Teal;
            this.BtnLimpar.FillColor2 = System.Drawing.Color.Teal;
            this.BtnLimpar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLimpar.ForeColor = System.Drawing.Color.White;
            this.BtnLimpar.Location = new System.Drawing.Point(165, 499);
            this.BtnLimpar.Name = "BtnLimpar";
            this.BtnLimpar.Size = new System.Drawing.Size(223, 51);
            this.BtnLimpar.TabIndex = 11;
            this.BtnLimpar.Text = "Limpar";
            this.BtnLimpar.Click += new System.EventHandler(this.BtnLimpar_Click);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtUsuario.BorderColor = System.Drawing.Color.Teal;
            this.TxtUsuario.BorderRadius = 20;
            this.TxtUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtUsuario.DefaultText = "";
            this.TxtUsuario.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtUsuario.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtUsuario.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUsuario.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtUsuario.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUsuario.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TxtUsuario.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtUsuario.Location = new System.Drawing.Point(16, 294);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.PlaceholderText = "Usuario";
            this.TxtUsuario.SelectedText = "";
            this.TxtUsuario.Size = new System.Drawing.Size(247, 48);
            this.TxtUsuario.TabIndex = 16;
            // 
            // BtnAtualizar
            // 
            this.BtnAtualizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnAtualizar.BorderRadius = 20;
            this.BtnAtualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnAtualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnAtualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAtualizar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnAtualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnAtualizar.FillColor = System.Drawing.Color.Teal;
            this.BtnAtualizar.FillColor2 = System.Drawing.Color.Teal;
            this.BtnAtualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAtualizar.ForeColor = System.Drawing.Color.White;
            this.BtnAtualizar.Location = new System.Drawing.Point(298, 421);
            this.BtnAtualizar.Name = "BtnAtualizar";
            this.BtnAtualizar.Size = new System.Drawing.Size(223, 51);
            this.BtnAtualizar.TabIndex = 10;
            this.BtnAtualizar.Text = "Atualizar";
            this.BtnAtualizar.Click += new System.EventHandler(this.BtnAtualizar_Click);
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtEmail.BorderColor = System.Drawing.Color.Teal;
            this.TxtEmail.BorderRadius = 20;
            this.TxtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtEmail.DefaultText = "";
            this.TxtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.TxtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtEmail.Location = new System.Drawing.Point(16, 238);
            this.TxtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.PlaceholderText = "E-mail";
            this.TxtEmail.SelectedText = "";
            this.TxtEmail.Size = new System.Drawing.Size(505, 48);
            this.TxtEmail.TabIndex = 0;
            // 
            // BtnRegistrar
            // 
            this.BtnRegistrar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnRegistrar.BorderRadius = 20;
            this.BtnRegistrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnRegistrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnRegistrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnRegistrar.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnRegistrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnRegistrar.FillColor = System.Drawing.Color.Teal;
            this.BtnRegistrar.FillColor2 = System.Drawing.Color.Teal;
            this.BtnRegistrar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRegistrar.ForeColor = System.Drawing.Color.White;
            this.BtnRegistrar.Location = new System.Drawing.Point(16, 421);
            this.BtnRegistrar.Name = "BtnRegistrar";
            this.BtnRegistrar.Size = new System.Drawing.Size(223, 51);
            this.BtnRegistrar.TabIndex = 9;
            this.BtnRegistrar.Text = "Cadastrar";
            this.BtnRegistrar.Click += new System.EventHandler(this.BtnRegistrar_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(312, 350);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(89, 18);
            this.guna2HtmlLabel2.TabIndex = 23;
            this.guna2HtmlLabel2.Text = "Adiministrador";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(312, 376);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(32, 18);
            this.guna2HtmlLabel1.TabIndex = 24;
            this.guna2HtmlLabel1.Text = "User";
            // 
            // CadastroUsuarioGUS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(171)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(1382, 900);
            this.Controls.Add(this.panel2);
            this.Name = "CadastroUsuarioGUS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CadastroUsuarioGUS";
            this.panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GNDgvUsuario)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel panel2;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picture2;
        private Guna.UI2.WinForms.Guna2TextBox TxtSenha;
        private Guna.UI2.WinForms.Guna2TextBox TxtUsuario;
        private Guna.UI2.WinForms.Guna2GradientButton BtnRegistrar;
        private Guna.UI2.WinForms.Guna2TextBox TxtEmail;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2GradientButton BtnLimpar;
        private Guna.UI2.WinForms.Guna2GradientButton BtnAtualizar;
        private Guna.UI2.WinForms.Guna2TextBox TxtSetor;
        private Guna.UI2.WinForms.Guna2CustomCheckBox GNCbxUser;
        private Guna.UI2.WinForms.Guna2CustomCheckBox GNCbxAdim;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLblAdim;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLblUsuario;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView GNDgvUsuario;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLblUsuarioId;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario_nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn setor;
        private System.Windows.Forms.DataGridViewTextBoxColumn perfil;
    }
}