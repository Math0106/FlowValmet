namespace FlowValmet.Viwes
{
    partial class CadastroLinhaProducao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GNPanelLinhaP = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.GNLimparCampos = new Guna.UI2.WinForms.Guna2Button();
            this.GNBtnCadastrar = new Guna.UI2.WinForms.Guna2Button();
            this.GNPanelCores = new Guna.UI2.WinForms.Guna2Panel();
            this.GNLabelLinhaCadastradaLinhaP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNDataGridLinhasCadastradaLinhaP = new Guna.UI2.WinForms.Guna2DataGridView();
            this.GNlabelSiglaLinhap = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNTxtSilglaLinhaP = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNCbxCor = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GNLabelCorLinhaP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNLabelLinhaP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNTxtNomeLinhaP = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNPanelLinhaP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNDataGridLinhasCadastradaLinhaP)).BeginInit();
            this.SuspendLayout();
            // 
            // GNPanelLinhaP
            // 
            this.GNPanelLinhaP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelLinhaP.BackColor = System.Drawing.Color.Transparent;
            this.GNPanelLinhaP.BorderRadius = 20;
            this.GNPanelLinhaP.Controls.Add(this.GNLimparCampos);
            this.GNPanelLinhaP.Controls.Add(this.GNBtnCadastrar);
            this.GNPanelLinhaP.Controls.Add(this.GNPanelCores);
            this.GNPanelLinhaP.Controls.Add(this.GNLabelLinhaCadastradaLinhaP);
            this.GNPanelLinhaP.Controls.Add(this.GNDataGridLinhasCadastradaLinhaP);
            this.GNPanelLinhaP.Controls.Add(this.GNlabelSiglaLinhap);
            this.GNPanelLinhaP.Controls.Add(this.GNTxtSilglaLinhaP);
            this.GNPanelLinhaP.Controls.Add(this.GNCbxCor);
            this.GNPanelLinhaP.Controls.Add(this.GNLabelCorLinhaP);
            this.GNPanelLinhaP.Controls.Add(this.GNLabelLinhaP);
            this.GNPanelLinhaP.Controls.Add(this.GNTxtNomeLinhaP);
            this.GNPanelLinhaP.Location = new System.Drawing.Point(200, 50);
            this.GNPanelLinhaP.Name = "GNPanelLinhaP";
            this.GNPanelLinhaP.Size = new System.Drawing.Size(1000, 800);
            this.GNPanelLinhaP.TabIndex = 2;
            // 
            // GNLimparCampos
            // 
            this.GNLimparCampos.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNLimparCampos.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNLimparCampos.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNLimparCampos.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNLimparCampos.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNLimparCampos.ForeColor = System.Drawing.Color.White;
            this.GNLimparCampos.Location = new System.Drawing.Point(263, 435);
            this.GNLimparCampos.Name = "GNLimparCampos";
            this.GNLimparCampos.Size = new System.Drawing.Size(180, 45);
            this.GNLimparCampos.TabIndex = 13;
            this.GNLimparCampos.Text = "Limpar";
            this.GNLimparCampos.Click += new System.EventHandler(this.GNLimparCampos_Click);
            // 
            // GNBtnCadastrar
            // 
            this.GNBtnCadastrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnCadastrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnCadastrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnCadastrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnCadastrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNBtnCadastrar.ForeColor = System.Drawing.Color.White;
            this.GNBtnCadastrar.Location = new System.Drawing.Point(77, 435);
            this.GNBtnCadastrar.Name = "GNBtnCadastrar";
            this.GNBtnCadastrar.Size = new System.Drawing.Size(180, 45);
            this.GNBtnCadastrar.TabIndex = 12;
            this.GNBtnCadastrar.Text = "Cadastrar";
            this.GNBtnCadastrar.Click += new System.EventHandler(this.GNBtnCadastrar_Click);
            // 
            // GNPanelCores
            // 
            this.GNPanelCores.Location = new System.Drawing.Point(371, 222);
            this.GNPanelCores.Name = "GNPanelCores";
            this.GNPanelCores.Size = new System.Drawing.Size(20, 20);
            this.GNPanelCores.TabIndex = 11;
            // 
            // GNLabelLinhaCadastradaLinhaP
            // 
            this.GNLabelLinhaCadastradaLinhaP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNLabelLinhaCadastradaLinhaP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelLinhaCadastradaLinhaP.Location = new System.Drawing.Point(629, 102);
            this.GNLabelLinhaCadastradaLinhaP.Name = "GNLabelLinhaCadastradaLinhaP";
            this.GNLabelLinhaCadastradaLinhaP.Size = new System.Drawing.Size(123, 18);
            this.GNLabelLinhaCadastradaLinhaP.TabIndex = 10;
            this.GNLabelLinhaCadastradaLinhaP.Text = "Linhas Cadastradas";
            // 
            // GNDataGridLinhasCadastradaLinhaP
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.GNDataGridLinhasCadastradaLinhaP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GNDataGridLinhasCadastradaLinhaP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNDataGridLinhasCadastradaLinhaP.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GNDataGridLinhasCadastradaLinhaP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GNDataGridLinhasCadastradaLinhaP.ColumnHeadersHeight = 4;
            this.GNDataGridLinhasCadastradaLinhaP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GNDataGridLinhasCadastradaLinhaP.DefaultCellStyle = dataGridViewCellStyle6;
            this.GNDataGridLinhasCadastradaLinhaP.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDataGridLinhasCadastradaLinhaP.Location = new System.Drawing.Point(449, 130);
            this.GNDataGridLinhasCadastradaLinhaP.Name = "GNDataGridLinhasCadastradaLinhaP";
            this.GNDataGridLinhasCadastradaLinhaP.RowHeadersVisible = false;
            this.GNDataGridLinhasCadastradaLinhaP.RowHeadersWidth = 49;
            this.GNDataGridLinhasCadastradaLinhaP.RowTemplate.Height = 24;
            this.GNDataGridLinhasCadastradaLinhaP.Size = new System.Drawing.Size(479, 400);
            this.GNDataGridLinhasCadastradaLinhaP.TabIndex = 9;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.HeaderStyle.Height = 4;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.ReadOnly = false;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.Height = 24;
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDataGridLinhasCadastradaLinhaP.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GNDataGridLinhasCadastradaLinhaP.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GNDataGridLinhasCadastradaLinhaP_CellContentClick);
            // 
            // GNlabelSiglaLinhap
            // 
            this.GNlabelSiglaLinhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNlabelSiglaLinhap.BackColor = System.Drawing.Color.Transparent;
            this.GNlabelSiglaLinhap.Location = new System.Drawing.Point(106, 260);
            this.GNlabelSiglaLinhap.Name = "GNlabelSiglaLinhap";
            this.GNlabelSiglaLinhap.Size = new System.Drawing.Size(34, 18);
            this.GNlabelSiglaLinhap.TabIndex = 8;
            this.GNlabelSiglaLinhap.Text = "Sigla";
            // 
            // GNTxtSilglaLinhaP
            // 
            this.GNTxtSilglaLinhaP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtSilglaLinhaP.DefaultText = "";
            this.GNTxtSilglaLinhaP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtSilglaLinhaP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtSilglaLinhaP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtSilglaLinhaP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtSilglaLinhaP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtSilglaLinhaP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNTxtSilglaLinhaP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtSilglaLinhaP.Location = new System.Drawing.Point(106, 288);
            this.GNTxtSilglaLinhaP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtSilglaLinhaP.Name = "GNTxtSilglaLinhaP";
            this.GNTxtSilglaLinhaP.PlaceholderText = "";
            this.GNTxtSilglaLinhaP.SelectedText = "";
            this.GNTxtSilglaLinhaP.Size = new System.Drawing.Size(116, 46);
            this.GNTxtSilglaLinhaP.TabIndex = 7;
            // 
            // GNCbxCor
            // 
            this.GNCbxCor.AllowDrop = true;
            this.GNCbxCor.BackColor = System.Drawing.Color.Transparent;
            this.GNCbxCor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GNCbxCor.DropDownHeight = 250;
            this.GNCbxCor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GNCbxCor.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxCor.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxCor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.GNCbxCor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.GNCbxCor.IntegralHeight = false;
            this.GNCbxCor.ItemHeight = 30;
            this.GNCbxCor.Items.AddRange(new object[] {
            "Azul Bebê-(173, 216, 230)",
            "Verde Menta-(152, 255, 152)",
            "Rosa Claro-(255, 182, 193)",
            "Lavanda-(230, 230, 250)",
            "Pêssego Claro-(255, 218, 185)",
            "Amarelo Claro-(255, 255, 204)",
            "Lilás-(200, 162, 200)",
            "Coral Claro-(255, 204, 204)",
            "Verde Pastel-(119, 221, 119)",
            "Azul Céu Claro-(135, 206, 250)",
            "Bege-(245, 245, 220)",
            "Creme-(255, 253, 208)",
            "Salmão Claro-(255, 160, 122)",
            "Turquesa Claro-(175, 238, 238)",
            "Rosa Bebê-(255, 228, 225)"});
            this.GNCbxCor.Location = new System.Drawing.Point(106, 214);
            this.GNCbxCor.MaxDropDownItems = 3;
            this.GNCbxCor.Name = "GNCbxCor";
            this.GNCbxCor.Size = new System.Drawing.Size(259, 36);
            this.GNCbxCor.TabIndex = 6;
            this.GNCbxCor.SelectedIndexChanged += new System.EventHandler(this.GNCbxCor_SelectedIndexChanged);
            // 
            // GNLabelCorLinhaP
            // 
            this.GNLabelCorLinhaP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNLabelCorLinhaP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelCorLinhaP.Location = new System.Drawing.Point(106, 186);
            this.GNLabelCorLinhaP.Name = "GNLabelCorLinhaP";
            this.GNLabelCorLinhaP.Size = new System.Drawing.Size(24, 18);
            this.GNLabelCorLinhaP.TabIndex = 5;
            this.GNLabelCorLinhaP.Text = "Cor";
            // 
            // GNLabelLinhaP
            // 
            this.GNLabelLinhaP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNLabelLinhaP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelLinhaP.Location = new System.Drawing.Point(106, 102);
            this.GNLabelLinhaP.Name = "GNLabelLinhaP";
            this.GNLabelLinhaP.Size = new System.Drawing.Size(116, 18);
            this.GNLabelLinhaP.TabIndex = 1;
            this.GNLabelLinhaP.Text = "Linha de Produção";
            // 
            // GNTxtNomeLinhaP
            // 
            this.GNTxtNomeLinhaP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtNomeLinhaP.DefaultText = "";
            this.GNTxtNomeLinhaP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtNomeLinhaP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtNomeLinhaP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtNomeLinhaP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtNomeLinhaP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtNomeLinhaP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNTxtNomeLinhaP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtNomeLinhaP.Location = new System.Drawing.Point(106, 130);
            this.GNTxtNomeLinhaP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtNomeLinhaP.Name = "GNTxtNomeLinhaP";
            this.GNTxtNomeLinhaP.PlaceholderText = "";
            this.GNTxtNomeLinhaP.SelectedText = "";
            this.GNTxtNomeLinhaP.Size = new System.Drawing.Size(259, 32);
            this.GNTxtNomeLinhaP.TabIndex = 0;
            // 
            // CadastroLinhaProducao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(89)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.GNPanelLinhaP);
            this.Name = "CadastroLinhaProducao";
            this.Text = "CadasdroLinhaProducao";
            this.GNPanelLinhaP.ResumeLayout(false);
            this.GNPanelLinhaP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNDataGridLinhasCadastradaLinhaP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel GNPanelLinhaP;
        private Guna.UI2.WinForms.Guna2ComboBox GNCbxCor;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelCorLinhaP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelLinhaP;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtNomeLinhaP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelLinhaCadastradaLinhaP;
        private Guna.UI2.WinForms.Guna2DataGridView GNDataGridLinhasCadastradaLinhaP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNlabelSiglaLinhap;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtSilglaLinhaP;
        private Guna.UI2.WinForms.Guna2Panel GNPanelCores;
        private Guna.UI2.WinForms.Guna2Button GNBtnCadastrar;
        private Guna.UI2.WinForms.Guna2Button GNLimparCampos;
    }
}