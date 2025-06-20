namespace FlowValmet.Viwes
{
    partial class VincularProcessos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GNPanelCadastroOP = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.GNDgvVinculado = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Idop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.GnBtnLimpar = new Guna.UI2.WinForms.Guna2Button();
            this.LblOp_vinculo = new System.Windows.Forms.Label();
            this.Lbl_processo = new System.Windows.Forms.Label();
            this.LblData_final = new System.Windows.Forms.Label();
            this.GNCheckboxTravarVinculoOp = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.GNBtnVincular = new Guna.UI2.WinForms.Guna2Button();
            this.LblDataInicio = new System.Windows.Forms.Label();
            this.GNCbxOps = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GNDtpDataFim = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.GnCbxProcessos = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GNDtpDataInicio = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.GnBtnCadastrarVinculo = new Guna.UI2.WinForms.Guna2Button();
            this.GNPanelCadastroOP.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNDgvVinculado)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GNPanelCadastroOP
            // 
            this.GNPanelCadastroOP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GNPanelCadastroOP.BorderRadius = 20;
            this.GNPanelCadastroOP.Controls.Add(this.guna2Panel1);
            this.GNPanelCadastroOP.Controls.Add(this.guna2Panel2);
            this.GNPanelCadastroOP.Controls.Add(this.GnBtnCadastrarVinculo);
            this.GNPanelCadastroOP.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GNPanelCadastroOP.FillColor2 = System.Drawing.Color.WhiteSmoke;
            this.GNPanelCadastroOP.FillColor3 = System.Drawing.Color.WhiteSmoke;
            this.GNPanelCadastroOP.FillColor4 = System.Drawing.Color.WhiteSmoke;
            this.GNPanelCadastroOP.Location = new System.Drawing.Point(108, 75);
            this.GNPanelCadastroOP.Name = "GNPanelCadastroOP";
            this.GNPanelCadastroOP.Size = new System.Drawing.Size(1185, 751);
            this.GNPanelCadastroOP.TabIndex = 2;
            this.GNPanelCadastroOP.Paint += new System.Windows.Forms.PaintEventHandler(this.GNPanelCadastroOP_Paint);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Teal;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.GNDgvVinculado);
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Location = new System.Drawing.Point(431, 19);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(736, 717);
            this.guna2Panel1.TabIndex = 35;
            // 
            // GNDgvVinculado
            // 
            this.GNDgvVinculado.AllowUserToAddRows = false;
            this.GNDgvVinculado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(223)))), ((int)(((byte)(219)))));
            this.GNDgvVinculado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.GNDgvVinculado.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GNDgvVinculado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.GNDgvVinculado.ColumnHeadersHeight = 25;
            this.GNDgvVinculado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDgvVinculado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idop,
            this.processo,
            this.dataInicio,
            this.dataFim});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GNDgvVinculado.DefaultCellStyle = dataGridViewCellStyle9;
            this.GNDgvVinculado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.GNDgvVinculado.Location = new System.Drawing.Point(15, 20);
            this.GNDgvVinculado.Name = "GNDgvVinculado";
            this.GNDgvVinculado.ReadOnly = true;
            this.GNDgvVinculado.RowHeadersVisible = false;
            this.GNDgvVinculado.RowHeadersWidth = 49;
            this.GNDgvVinculado.RowTemplate.Height = 24;
            this.GNDgvVinculado.Size = new System.Drawing.Size(702, 675);
            this.GNDgvVinculado.TabIndex = 2;
            this.GNDgvVinculado.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Teal;
            this.GNDgvVinculado.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(223)))), ((int)(((byte)(219)))));
            this.GNDgvVinculado.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GNDgvVinculado.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GNDgvVinculado.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GNDgvVinculado.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GNDgvVinculado.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNDgvVinculado.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(222)))), ((int)(((byte)(218)))));
            this.GNDgvVinculado.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.GNDgvVinculado.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GNDgvVinculado.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDgvVinculado.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GNDgvVinculado.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDgvVinculado.ThemeStyle.HeaderStyle.Height = 25;
            this.GNDgvVinculado.ThemeStyle.ReadOnly = true;
            this.GNDgvVinculado.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(233)))), ((int)(((byte)(231)))));
            this.GNDgvVinculado.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GNDgvVinculado.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDgvVinculado.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.GNDgvVinculado.ThemeStyle.RowsStyle.Height = 24;
            this.GNDgvVinculado.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(185)))), ((int)(((byte)(175)))));
            this.GNDgvVinculado.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.GNDgvVinculado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GNDgvVinculado_CellContentClick);
            // 
            // Idop
            // 
            this.Idop.HeaderText = "Id Op";
            this.Idop.MinimumWidth = 6;
            this.Idop.Name = "Idop";
            this.Idop.ReadOnly = true;
            // 
            // processo
            // 
            this.processo.HeaderText = "Processo";
            this.processo.MinimumWidth = 6;
            this.processo.Name = "processo";
            this.processo.ReadOnly = true;
            // 
            // dataInicio
            // 
            this.dataInicio.HeaderText = "Data início";
            this.dataInicio.MinimumWidth = 6;
            this.dataInicio.Name = "dataInicio";
            this.dataInicio.ReadOnly = true;
            // 
            // dataFim
            // 
            this.dataFim.HeaderText = "Data Fim";
            this.dataFim.MinimumWidth = 6;
            this.dataFim.Name = "dataFim";
            this.dataFim.ReadOnly = true;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Teal;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.GnBtnLimpar);
            this.guna2Panel2.Controls.Add(this.LblOp_vinculo);
            this.guna2Panel2.Controls.Add(this.Lbl_processo);
            this.guna2Panel2.Controls.Add(this.LblData_final);
            this.guna2Panel2.Controls.Add(this.GNCheckboxTravarVinculoOp);
            this.guna2Panel2.Controls.Add(this.GNBtnVincular);
            this.guna2Panel2.Controls.Add(this.LblDataInicio);
            this.guna2Panel2.Controls.Add(this.GNCbxOps);
            this.guna2Panel2.Controls.Add(this.GNDtpDataFim);
            this.guna2Panel2.Controls.Add(this.GnCbxProcessos);
            this.guna2Panel2.Controls.Add(this.GNDtpDataInicio);
            this.guna2Panel2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.Location = new System.Drawing.Point(19, 19);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(406, 450);
            this.guna2Panel2.TabIndex = 34;
            // 
            // GnBtnLimpar
            // 
            this.GnBtnLimpar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GnBtnLimpar.BorderRadius = 20;
            this.GnBtnLimpar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GnBtnLimpar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GnBtnLimpar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GnBtnLimpar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GnBtnLimpar.FillColor = System.Drawing.Color.Teal;
            this.GnBtnLimpar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.GnBtnLimpar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GnBtnLimpar.Location = new System.Drawing.Point(43, 378);
            this.GnBtnLimpar.Name = "GnBtnLimpar";
            this.GnBtnLimpar.Size = new System.Drawing.Size(300, 48);
            this.GnBtnLimpar.TabIndex = 34;
            this.GnBtnLimpar.Text = "Limpar";
            this.GnBtnLimpar.Click += new System.EventHandler(this.GnBtnLimpar_Click);
            // 
            // LblOp_vinculo
            // 
            this.LblOp_vinculo.AutoSize = true;
            this.LblOp_vinculo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblOp_vinculo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblOp_vinculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.LblOp_vinculo.Location = new System.Drawing.Point(10, 20);
            this.LblOp_vinculo.Name = "LblOp_vinculo";
            this.LblOp_vinculo.Size = new System.Drawing.Size(124, 21);
            this.LblOp_vinculo.TabIndex = 33;
            this.LblOp_vinculo.Text = "Op para vinculo";
            // 
            // Lbl_processo
            // 
            this.Lbl_processo.AutoSize = true;
            this.Lbl_processo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Lbl_processo.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.Lbl_processo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.Lbl_processo.Location = new System.Drawing.Point(10, 83);
            this.Lbl_processo.Name = "Lbl_processo";
            this.Lbl_processo.Size = new System.Drawing.Size(76, 21);
            this.Lbl_processo.TabIndex = 32;
            this.Lbl_processo.Text = "Processo";
            // 
            // LblData_final
            // 
            this.LblData_final.AutoSize = true;
            this.LblData_final.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblData_final.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblData_final.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.LblData_final.Location = new System.Drawing.Point(10, 223);
            this.LblData_final.Name = "LblData_final";
            this.LblData_final.Size = new System.Drawing.Size(93, 21);
            this.LblData_final.TabIndex = 31;
            this.LblData_final.Text = "Data da fim";
            // 
            // GNCheckboxTravarVinculoOp
            // 
            this.GNCheckboxTravarVinculoOp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNCheckboxTravarVinculoOp.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCheckboxTravarVinculoOp.CheckedState.BorderRadius = 2;
            this.GNCheckboxTravarVinculoOp.CheckedState.BorderThickness = 0;
            this.GNCheckboxTravarVinculoOp.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCheckboxTravarVinculoOp.CheckMarkColor = System.Drawing.Color.Teal;
            this.GNCheckboxTravarVinculoOp.Location = new System.Drawing.Point(366, 52);
            this.GNCheckboxTravarVinculoOp.Name = "GNCheckboxTravarVinculoOp";
            this.GNCheckboxTravarVinculoOp.Size = new System.Drawing.Size(20, 20);
            this.GNCheckboxTravarVinculoOp.TabIndex = 12;
            this.GNCheckboxTravarVinculoOp.Text = "guna2CustomCheckBox1";
            this.GNCheckboxTravarVinculoOp.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCheckboxTravarVinculoOp.UncheckedState.BorderRadius = 2;
            this.GNCheckboxTravarVinculoOp.UncheckedState.BorderThickness = 0;
            this.GNCheckboxTravarVinculoOp.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCheckboxTravarVinculoOp.Click += new System.EventHandler(this.GNCheckboxTravarVinculoOp_Click);
            // 
            // GNBtnVincular
            // 
            this.GNBtnVincular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNBtnVincular.BorderRadius = 20;
            this.GNBtnVincular.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnVincular.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnVincular.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnVincular.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnVincular.FillColor = System.Drawing.Color.Teal;
            this.GNBtnVincular.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.GNBtnVincular.ForeColor = System.Drawing.Color.White;
            this.GNBtnVincular.Location = new System.Drawing.Point(43, 324);
            this.GNBtnVincular.Name = "GNBtnVincular";
            this.GNBtnVincular.Size = new System.Drawing.Size(300, 48);
            this.GNBtnVincular.TabIndex = 10;
            this.GNBtnVincular.Text = "Vincular";
            this.GNBtnVincular.Click += new System.EventHandler(this.GNBtnVincular_Click);
            // 
            // LblDataInicio
            // 
            this.LblDataInicio.AutoSize = true;
            this.LblDataInicio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblDataInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblDataInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.LblDataInicio.Location = new System.Drawing.Point(10, 147);
            this.LblDataInicio.Name = "LblDataInicio";
            this.LblDataInicio.Size = new System.Drawing.Size(87, 21);
            this.LblDataInicio.TabIndex = 30;
            this.LblDataInicio.Text = "Data Inicio";
            // 
            // GNCbxOps
            // 
            this.GNCbxOps.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNCbxOps.BorderColor = System.Drawing.Color.Teal;
            this.GNCbxOps.BorderRadius = 20;
            this.GNCbxOps.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GNCbxOps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GNCbxOps.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxOps.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCbxOps.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNCbxOps.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.GNCbxOps.ItemHeight = 30;
            this.GNCbxOps.Location = new System.Drawing.Point(10, 44);
            this.GNCbxOps.Name = "GNCbxOps";
            this.GNCbxOps.Size = new System.Drawing.Size(333, 36);
            this.GNCbxOps.TabIndex = 0;
            // 
            // GNDtpDataFim
            // 
            this.GNDtpDataFim.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNDtpDataFim.BorderRadius = 20;
            this.GNDtpDataFim.Checked = true;
            this.GNDtpDataFim.FillColor = System.Drawing.Color.Teal;
            this.GNDtpDataFim.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNDtpDataFim.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNDtpDataFim.Location = new System.Drawing.Point(6, 248);
            this.GNDtpDataFim.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNDtpDataFim.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNDtpDataFim.Name = "GNDtpDataFim";
            this.GNDtpDataFim.Size = new System.Drawing.Size(380, 48);
            this.GNDtpDataFim.TabIndex = 7;
            this.GNDtpDataFim.Value = new System.DateTime(2025, 5, 5, 12, 44, 47, 525);
            // 
            // GnCbxProcessos
            // 
            this.GnCbxProcessos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GnCbxProcessos.BorderColor = System.Drawing.Color.Teal;
            this.GnCbxProcessos.BorderRadius = 20;
            this.GnCbxProcessos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.GnCbxProcessos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GnCbxProcessos.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GnCbxProcessos.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GnCbxProcessos.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GnCbxProcessos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.GnCbxProcessos.ItemHeight = 30;
            this.GnCbxProcessos.Location = new System.Drawing.Point(6, 108);
            this.GnCbxProcessos.Name = "GnCbxProcessos";
            this.GnCbxProcessos.Size = new System.Drawing.Size(380, 36);
            this.GnCbxProcessos.TabIndex = 4;
            // 
            // GNDtpDataInicio
            // 
            this.GNDtpDataInicio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNDtpDataInicio.BorderRadius = 20;
            this.GNDtpDataInicio.Checked = true;
            this.GNDtpDataInicio.FillColor = System.Drawing.Color.Teal;
            this.GNDtpDataInicio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNDtpDataInicio.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.GNDtpDataInicio.Location = new System.Drawing.Point(6, 172);
            this.GNDtpDataInicio.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.GNDtpDataInicio.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.GNDtpDataInicio.Name = "GNDtpDataInicio";
            this.GNDtpDataInicio.Size = new System.Drawing.Size(380, 48);
            this.GNDtpDataInicio.TabIndex = 6;
            this.GNDtpDataInicio.Value = new System.DateTime(2025, 5, 5, 12, 44, 47, 525);
            // 
            // GnBtnCadastrarVinculo
            // 
            this.GnBtnCadastrarVinculo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GnBtnCadastrarVinculo.BorderRadius = 20;
            this.GnBtnCadastrarVinculo.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GnBtnCadastrarVinculo.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GnBtnCadastrarVinculo.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GnBtnCadastrarVinculo.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GnBtnCadastrarVinculo.FillColor = System.Drawing.Color.Teal;
            this.GnBtnCadastrarVinculo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.GnBtnCadastrarVinculo.ForeColor = System.Drawing.Color.White;
            this.GnBtnCadastrarVinculo.Location = new System.Drawing.Point(81, 688);
            this.GnBtnCadastrarVinculo.Name = "GnBtnCadastrarVinculo";
            this.GnBtnCadastrarVinculo.Size = new System.Drawing.Size(300, 48);
            this.GnBtnCadastrarVinculo.TabIndex = 11;
            this.GnBtnCadastrarVinculo.Text = "Aplicar Vínculo";
            this.GnBtnCadastrarVinculo.Click += new System.EventHandler(this.GnBtnCadastrarVinculo_Click_1);
            // 
            // VincularProcessos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(171)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(1400, 900);
            this.Controls.Add(this.GNPanelCadastroOP);
            this.Name = "VincularProcessos";
            this.Text = "VincularProcessos";
            this.GNPanelCadastroOP.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GNDgvVinculado)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel GNPanelCadastroOP;
        private Guna.UI2.WinForms.Guna2ComboBox GNCbxOps;
        private Guna.UI2.WinForms.Guna2ComboBox GnCbxProcessos;
        private Guna.UI2.WinForms.Guna2DataGridView GNDgvVinculado;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNDtpDataFim;
        private Guna.UI2.WinForms.Guna2DateTimePicker GNDtpDataInicio;
        private Guna.UI2.WinForms.Guna2Button GNBtnVincular;
        private Guna.UI2.WinForms.Guna2Button GnBtnCadastrarVinculo;
        private Guna.UI2.WinForms.Guna2CustomCheckBox GNCheckboxTravarVinculoOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idop;
        private System.Windows.Forms.DataGridViewTextBoxColumn processo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataFim;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label LblData_final;
        private System.Windows.Forms.Label LblDataInicio;
        private System.Windows.Forms.Label LblOp_vinculo;
        private System.Windows.Forms.Label Lbl_processo;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button GnBtnLimpar;
    }
}