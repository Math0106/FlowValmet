namespace FlowValmet.Viwes
{
    partial class CadastroOP
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
            this.GNPanelCadastroOP = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.GBBtnCadastrar = new Guna.UI2.WinForms.Guna2Button();
            this.GnDvgOp = new Guna.UI2.WinForms.Guna2DataGridView();
            this.GNDatePikerEntregaOP = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.GNLabelDataEntregaOP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNDatePikerInicioOP = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.GNLabelDataInicioOP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNLabelDesenhoOP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNTxtDesenhoOP = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNLabelDescricaoOp = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNTxtDescriçãoOP = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNLabelNumeroOP = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNTxtNumeroOP = new Guna.UI2.WinForms.Guna2TextBox();
            this.GNPanelCadastroOP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GnDvgOp)).BeginInit();
            this.SuspendLayout();
            // 
            // GNPanelCadastroOP
            // 
            this.GNPanelCadastroOP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelCadastroOP.BorderRadius = 20;
            this.GNPanelCadastroOP.Controls.Add(this.GBBtnCadastrar);
            this.GNPanelCadastroOP.Controls.Add(this.GnDvgOp);
            this.GNPanelCadastroOP.Controls.Add(this.GNDatePikerEntregaOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNLabelDataEntregaOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNDatePikerInicioOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNLabelDataInicioOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNLabelDesenhoOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNTxtDesenhoOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNLabelDescricaoOp);
            this.GNPanelCadastroOP.Controls.Add(this.GNTxtDescriçãoOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNLabelNumeroOP);
            this.GNPanelCadastroOP.Controls.Add(this.GNTxtNumeroOP);
            this.GNPanelCadastroOP.Location = new System.Drawing.Point(190, 72);
            this.GNPanelCadastroOP.Name = "GNPanelCadastroOP";
            this.GNPanelCadastroOP.Size = new System.Drawing.Size(1000, 800);
            this.GNPanelCadastroOP.TabIndex = 1;
            // 
            // GBBtnCadastrar
            // 
            this.GBBtnCadastrar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GBBtnCadastrar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GBBtnCadastrar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GBBtnCadastrar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GBBtnCadastrar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GBBtnCadastrar.ForeColor = System.Drawing.Color.White;
            this.GBBtnCadastrar.Location = new System.Drawing.Point(123, 524);
            this.GBBtnCadastrar.Name = "GBBtnCadastrar";
            this.GBBtnCadastrar.Size = new System.Drawing.Size(180, 45);
            this.GBBtnCadastrar.TabIndex = 17;
            this.GBBtnCadastrar.Text = "Cadastrar";
            this.GBBtnCadastrar.Click += new System.EventHandler(this.GBBtnCadastrar_Click);
            // 
            // GnDvgOp
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.GnDvgOp.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.GnDvgOp.BackgroundColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GnDvgOp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GnDvgOp.ColumnHeadersHeight = 4;
            this.GnDvgOp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GnDvgOp.DefaultCellStyle = dataGridViewCellStyle6;
            this.GnDvgOp.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GnDvgOp.Location = new System.Drawing.Point(377, 100);
            this.GnDvgOp.Name = "GnDvgOp";
            this.GnDvgOp.RowHeadersVisible = false;
            this.GnDvgOp.RowHeadersWidth = 49;
            this.GnDvgOp.RowTemplate.Height = 24;
            this.GnDvgOp.Size = new System.Drawing.Size(567, 531);
            this.GnDvgOp.TabIndex = 16;
            this.GnDvgOp.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GnDvgOp.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GnDvgOp.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GnDvgOp.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GnDvgOp.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GnDvgOp.ThemeStyle.BackColor = System.Drawing.Color.Gray;
            this.GnDvgOp.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GnDvgOp.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GnDvgOp.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GnDvgOp.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GnDvgOp.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GnDvgOp.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GnDvgOp.ThemeStyle.HeaderStyle.Height = 4;
            this.GnDvgOp.ThemeStyle.ReadOnly = false;
            this.GnDvgOp.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GnDvgOp.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GnDvgOp.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GnDvgOp.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GnDvgOp.ThemeStyle.RowsStyle.Height = 24;
            this.GnDvgOp.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GnDvgOp.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GnDvgOp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GnDvgOp_CellContentClick);
            // 
            // GNDatePikerEntregaOP
            // 
            this.GNDatePikerEntregaOP.Checked = true;
            this.GNDatePikerEntregaOP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNDatePikerEntregaOP.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNDatePikerEntregaOP.Location = new System.Drawing.Point(65, 425);
            this.GNDatePikerEntregaOP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNDatePikerEntregaOP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNDatePikerEntregaOP.Name = "GNDatePikerEntregaOP";
            this.GNDatePikerEntregaOP.Size = new System.Drawing.Size(306, 36);
            this.GNDatePikerEntregaOP.TabIndex = 10;
            this.GNDatePikerEntregaOP.Value = new System.DateTime(2025, 4, 30, 12, 45, 49, 708);
            // 
            // GNLabelDataEntregaOP
            // 
            this.GNLabelDataEntregaOP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelDataEntregaOP.Location = new System.Drawing.Point(65, 401);
            this.GNLabelDataEntregaOP.Name = "GNLabelDataEntregaOP";
            this.GNLabelDataEntregaOP.Size = new System.Drawing.Size(101, 18);
            this.GNLabelDataEntregaOP.TabIndex = 9;
            this.GNLabelDataEntregaOP.Text = "Data de Entrega";
            // 
            // GNDatePikerInicioOP
            // 
            this.GNDatePikerInicioOP.Checked = true;
            this.GNDatePikerInicioOP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNDatePikerInicioOP.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNDatePikerInicioOP.Location = new System.Drawing.Point(65, 344);
            this.GNDatePikerInicioOP.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNDatePikerInicioOP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNDatePikerInicioOP.Name = "GNDatePikerInicioOP";
            this.GNDatePikerInicioOP.Size = new System.Drawing.Size(306, 36);
            this.GNDatePikerInicioOP.TabIndex = 8;
            this.GNDatePikerInicioOP.Value = new System.DateTime(2025, 4, 30, 12, 45, 49, 708);
            // 
            // GNLabelDataInicioOP
            // 
            this.GNLabelDataInicioOP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelDataInicioOP.Location = new System.Drawing.Point(65, 320);
            this.GNLabelDataInicioOP.Name = "GNLabelDataInicioOP";
            this.GNLabelDataInicioOP.Size = new System.Drawing.Size(66, 18);
            this.GNLabelDataInicioOP.TabIndex = 7;
            this.GNLabelDataInicioOP.Text = "Data início";
            // 
            // GNLabelDesenhoOP
            // 
            this.GNLabelDesenhoOP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelDesenhoOP.Location = new System.Drawing.Point(66, 232);
            this.GNLabelDesenhoOP.Name = "GNLabelDesenhoOP";
            this.GNLabelDesenhoOP.Size = new System.Drawing.Size(58, 18);
            this.GNLabelDesenhoOP.TabIndex = 5;
            this.GNLabelDesenhoOP.Text = "Desenho";
            // 
            // GNTxtDesenhoOP
            // 
            this.GNTxtDesenhoOP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtDesenhoOP.DefaultText = "";
            this.GNTxtDesenhoOP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtDesenhoOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtDesenhoOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtDesenhoOP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtDesenhoOP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtDesenhoOP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNTxtDesenhoOP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtDesenhoOP.Location = new System.Drawing.Point(66, 257);
            this.GNTxtDesenhoOP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtDesenhoOP.Name = "GNTxtDesenhoOP";
            this.GNTxtDesenhoOP.PlaceholderText = "";
            this.GNTxtDesenhoOP.SelectedText = "";
            this.GNTxtDesenhoOP.Size = new System.Drawing.Size(305, 46);
            this.GNTxtDesenhoOP.TabIndex = 4;
            // 
            // GNLabelDescricaoOp
            // 
            this.GNLabelDescricaoOp.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelDescricaoOp.Location = new System.Drawing.Point(66, 154);
            this.GNLabelDescricaoOp.Name = "GNLabelDescricaoOp";
            this.GNLabelDescricaoOp.Size = new System.Drawing.Size(65, 18);
            this.GNLabelDescricaoOp.TabIndex = 3;
            this.GNLabelDescricaoOp.Text = "Descrição";
            // 
            // GNTxtDescriçãoOP
            // 
            this.GNTxtDescriçãoOP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtDescriçãoOP.DefaultText = "";
            this.GNTxtDescriçãoOP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtDescriçãoOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtDescriçãoOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtDescriçãoOP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtDescriçãoOP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtDescriçãoOP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNTxtDescriçãoOP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtDescriçãoOP.Location = new System.Drawing.Point(66, 179);
            this.GNTxtDescriçãoOP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtDescriçãoOP.Name = "GNTxtDescriçãoOP";
            this.GNTxtDescriçãoOP.PlaceholderText = "";
            this.GNTxtDescriçãoOP.SelectedText = "";
            this.GNTxtDescriçãoOP.Size = new System.Drawing.Size(305, 46);
            this.GNTxtDescriçãoOP.TabIndex = 2;
            // 
            // GNLabelNumeroOP
            // 
            this.GNLabelNumeroOP.BackColor = System.Drawing.Color.Transparent;
            this.GNLabelNumeroOP.Location = new System.Drawing.Point(66, 76);
            this.GNLabelNumeroOP.Name = "GNLabelNumeroOP";
            this.GNLabelNumeroOP.Size = new System.Drawing.Size(22, 18);
            this.GNLabelNumeroOP.TabIndex = 1;
            this.GNLabelNumeroOP.Text = "OP";
            // 
            // GNTxtNumeroOP
            // 
            this.GNTxtNumeroOP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtNumeroOP.DefaultText = "";
            this.GNTxtNumeroOP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtNumeroOP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtNumeroOP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtNumeroOP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtNumeroOP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtNumeroOP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.GNTxtNumeroOP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtNumeroOP.Location = new System.Drawing.Point(66, 101);
            this.GNTxtNumeroOP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtNumeroOP.Name = "GNTxtNumeroOP";
            this.GNTxtNumeroOP.PlaceholderText = "";
            this.GNTxtNumeroOP.SelectedText = "";
            this.GNTxtNumeroOP.Size = new System.Drawing.Size(305, 46);
            this.GNTxtNumeroOP.TabIndex = 0;
            // 
            // CadastroOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(89)))), ((int)(((byte)(76)))));
            this.ClientSize = new System.Drawing.Size(1418, 945);
            this.Controls.Add(this.GNPanelCadastroOP);
            this.Name = "CadastroOP";
            this.Text = "CadastroOP";
            this.GNPanelCadastroOP.ResumeLayout(false);
            this.GNPanelCadastroOP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GnDvgOp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel GNPanelCadastroOP;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtNumeroOP;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNDatePikerInicioOP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelDataInicioOP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelDesenhoOP;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtDesenhoOP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelDescricaoOp;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtDescriçãoOP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelNumeroOP;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNDatePikerEntregaOP;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLabelDataEntregaOP;
        private Guna.UI2.WinForms.Guna2DataGridView GnDvgOp;
        private Guna.UI2.WinForms.Guna2Button GBBtnCadastrar;
    }
}