namespace FlowValmet.Viwes
{
    partial class CadastroLembretes
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroLembretes));
            this.GNPanelCadastroLembretes = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.GNLblLembreteId = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GnBtnLimpar = new Guna.UI2.WinForms.Guna2Button();
            this.GNBtnAtualizar = new Guna.UI2.WinForms.Guna2Button();
            this.GNTxtTituloLembrete = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.GNBtnCadastrarCadastroLembretes = new Guna.UI2.WinForms.Guna2Button();
            this.GNCheckBoxVincular = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.GNTxtDEscricaoCadastrarLembretes = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.GNDgvLembretes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vinculo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.GNCbxOps = new Guna.UI2.WinForms.Guna2ComboBox();
            this.GNPanelCadastroLembretes.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GNDgvLembretes)).BeginInit();
            this.SuspendLayout();
            // 
            // GNPanelCadastroLembretes
            // 
            this.GNPanelCadastroLembretes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelCadastroLembretes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(171)))), ((int)(((byte)(167)))));
            this.GNPanelCadastroLembretes.BorderRadius = 20;
            this.GNPanelCadastroLembretes.Controls.Add(this.guna2Panel2);
            this.GNPanelCadastroLembretes.Controls.Add(this.guna2Panel1);
            this.GNPanelCadastroLembretes.Location = new System.Drawing.Point(246, 108);
            this.GNPanelCadastroLembretes.Name = "GNPanelCadastroLembretes";
            this.GNPanelCadastroLembretes.Size = new System.Drawing.Size(910, 684);
            this.GNPanelCadastroLembretes.TabIndex = 1;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Teal;
            this.guna2Panel2.BorderRadius = 20;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.GNCbxOps);
            this.guna2Panel2.Controls.Add(this.GNLblLembreteId);
            this.guna2Panel2.Controls.Add(this.GnBtnLimpar);
            this.guna2Panel2.Controls.Add(this.GNBtnAtualizar);
            this.guna2Panel2.Controls.Add(this.GNTxtTituloLembrete);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel2.Controls.Add(this.GNBtnCadastrarCadastroLembretes);
            this.guna2Panel2.Controls.Add(this.GNCheckBoxVincular);
            this.guna2Panel2.Controls.Add(this.GNTxtDEscricaoCadastrarLembretes);
            this.guna2Panel2.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel2.Location = new System.Drawing.Point(20, 19);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(332, 492);
            this.guna2Panel2.TabIndex = 35;
            // 
            // GNLblLembreteId
            // 
            this.GNLblLembreteId.BackColor = System.Drawing.Color.Transparent;
            this.GNLblLembreteId.Location = new System.Drawing.Point(24, 18);
            this.GNLblLembreteId.Name = "GNLblLembreteId";
            this.GNLblLembreteId.Size = new System.Drawing.Size(12, 18);
            this.GNLblLembreteId.TabIndex = 15;
            this.GNLblLembreteId.Text = "...";
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
            this.GnBtnLimpar.Location = new System.Drawing.Point(18, 433);
            this.GnBtnLimpar.Name = "GnBtnLimpar";
            this.GnBtnLimpar.Size = new System.Drawing.Size(299, 45);
            this.GnBtnLimpar.TabIndex = 14;
            this.GnBtnLimpar.Text = "Limpar";
            this.GnBtnLimpar.Click += new System.EventHandler(this.GnBtnLimpar_Click);
            // 
            // GNBtnAtualizar
            // 
            this.GNBtnAtualizar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNBtnAtualizar.BorderRadius = 20;
            this.GNBtnAtualizar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnAtualizar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnAtualizar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnAtualizar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnAtualizar.FillColor = System.Drawing.Color.Teal;
            this.GNBtnAtualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.GNBtnAtualizar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GNBtnAtualizar.Location = new System.Drawing.Point(18, 382);
            this.GNBtnAtualizar.Name = "GNBtnAtualizar";
            this.GNBtnAtualizar.Size = new System.Drawing.Size(299, 45);
            this.GNBtnAtualizar.TabIndex = 16;
            this.GNBtnAtualizar.Text = "Atualizar";
            this.GNBtnAtualizar.Click += new System.EventHandler(this.GNBtnAtualizar_Click);
            // 
            // GNTxtTituloLembrete
            // 
            this.GNTxtTituloLembrete.BorderColor = System.Drawing.Color.Teal;
            this.GNTxtTituloLembrete.BorderRadius = 20;
            this.GNTxtTituloLembrete.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtTituloLembrete.DefaultText = "";
            this.GNTxtTituloLembrete.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtTituloLembrete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtTituloLembrete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtTituloLembrete.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtTituloLembrete.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtTituloLembrete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNTxtTituloLembrete.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtTituloLembrete.Location = new System.Drawing.Point(18, 44);
            this.GNTxtTituloLembrete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtTituloLembrete.MaxLength = 15;
            this.GNTxtTituloLembrete.Name = "GNTxtTituloLembrete";
            this.GNTxtTituloLembrete.PlaceholderText = "Título";
            this.GNTxtTituloLembrete.SelectedText = "";
            this.GNTxtTituloLembrete.Size = new System.Drawing.Size(299, 46);
            this.GNTxtTituloLembrete.TabIndex = 0;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(24, 102);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(132, 21);
            this.guna2HtmlLabel2.TabIndex = 11;
            this.guna2HtmlLabel2.Text = "Vincular em uma OP";
            // 
            // GNBtnCadastrarCadastroLembretes
            // 
            this.GNBtnCadastrarCadastroLembretes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNBtnCadastrarCadastroLembretes.BorderRadius = 20;
            this.GNBtnCadastrarCadastroLembretes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnCadastrarCadastroLembretes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBtnCadastrarCadastroLembretes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBtnCadastrarCadastroLembretes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBtnCadastrarCadastroLembretes.FillColor = System.Drawing.Color.Teal;
            this.GNBtnCadastrarCadastroLembretes.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.GNBtnCadastrarCadastroLembretes.ForeColor = System.Drawing.Color.White;
            this.GNBtnCadastrarCadastroLembretes.Location = new System.Drawing.Point(18, 331);
            this.GNBtnCadastrarCadastroLembretes.Name = "GNBtnCadastrarCadastroLembretes";
            this.GNBtnCadastrarCadastroLembretes.Size = new System.Drawing.Size(299, 45);
            this.GNBtnCadastrarCadastroLembretes.TabIndex = 7;
            this.GNBtnCadastrarCadastroLembretes.Text = "Cadastrar";
            this.GNBtnCadastrarCadastroLembretes.Click += new System.EventHandler(this.GNBtnCadastrarCadastroLembretes_Click);
            // 
            // GNCheckBoxVincular
            // 
            this.GNCheckBoxVincular.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNCheckBoxVincular.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCheckBoxVincular.CheckedState.BorderRadius = 2;
            this.GNCheckBoxVincular.CheckedState.BorderThickness = 0;
            this.GNCheckBoxVincular.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNCheckBoxVincular.CheckMarkColor = System.Drawing.Color.WhiteSmoke;
            this.GNCheckBoxVincular.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GNCheckBoxVincular.Location = new System.Drawing.Point(162, 102);
            this.GNCheckBoxVincular.Name = "GNCheckBoxVincular";
            this.GNCheckBoxVincular.Size = new System.Drawing.Size(20, 20);
            this.GNCheckBoxVincular.TabIndex = 10;
            this.GNCheckBoxVincular.Text = "guna2CustomCheckBox1";
            this.GNCheckBoxVincular.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCheckBoxVincular.UncheckedState.BorderRadius = 2;
            this.GNCheckBoxVincular.UncheckedState.BorderThickness = 0;
            this.GNCheckBoxVincular.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.GNCheckBoxVincular.Click += new System.EventHandler(this.GNCheckBoxVincular_Click);
            // 
            // GNTxtDEscricaoCadastrarLembretes
            // 
            this.GNTxtDEscricaoCadastrarLembretes.BorderColor = System.Drawing.Color.Teal;
            this.GNTxtDEscricaoCadastrarLembretes.BorderRadius = 20;
            this.GNTxtDEscricaoCadastrarLembretes.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.GNTxtDEscricaoCadastrarLembretes.DefaultText = "";
            this.GNTxtDEscricaoCadastrarLembretes.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.GNTxtDEscricaoCadastrarLembretes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.GNTxtDEscricaoCadastrarLembretes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtDEscricaoCadastrarLembretes.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.GNTxtDEscricaoCadastrarLembretes.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtDEscricaoCadastrarLembretes.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.GNTxtDEscricaoCadastrarLembretes.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.GNTxtDEscricaoCadastrarLembretes.Location = new System.Drawing.Point(18, 189);
            this.GNTxtDEscricaoCadastrarLembretes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GNTxtDEscricaoCadastrarLembretes.MaxLength = 160;
            this.GNTxtDEscricaoCadastrarLembretes.Multiline = true;
            this.GNTxtDEscricaoCadastrarLembretes.Name = "GNTxtDEscricaoCadastrarLembretes";
            this.GNTxtDEscricaoCadastrarLembretes.PlaceholderText = "Descrição";
            this.GNTxtDEscricaoCadastrarLembretes.SelectedText = "";
            this.GNTxtDEscricaoCadastrarLembretes.Size = new System.Drawing.Size(299, 123);
            this.GNTxtDEscricaoCadastrarLembretes.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Teal;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 1;
            this.guna2Panel1.Controls.Add(this.GNDgvLembretes);
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Location = new System.Drawing.Point(368, 19);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(524, 649);
            this.guna2Panel1.TabIndex = 34;
            // 
            // GNDgvLembretes
            // 
            this.GNDgvLembretes.AllowUserToAddRows = false;
            this.GNDgvLembretes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.GNDgvLembretes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.GNDgvLembretes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.GNDgvLembretes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GNDgvLembretes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.GNDgvLembretes.ColumnHeadersHeight = 4;
            this.GNDgvLembretes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDgvLembretes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.titulo,
            this.descricao,
            this.vinculo,
            this.op});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GNDgvLembretes.DefaultCellStyle = dataGridViewCellStyle9;
            this.GNDgvLembretes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDgvLembretes.Location = new System.Drawing.Point(19, 18);
            this.GNDgvLembretes.Name = "GNDgvLembretes";
            this.GNDgvLembretes.ReadOnly = true;
            this.GNDgvLembretes.RowHeadersVisible = false;
            this.GNDgvLembretes.RowHeadersWidth = 49;
            this.GNDgvLembretes.RowTemplate.Height = 24;
            this.GNDgvLembretes.Size = new System.Drawing.Size(485, 617);
            this.GNDgvLembretes.TabIndex = 8;
            this.GNDgvLembretes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.GNDgvLembretes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.GNDgvLembretes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.GNDgvLembretes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.GNDgvLembretes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.GNDgvLembretes.ThemeStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNDgvLembretes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDgvLembretes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.GNDgvLembretes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.GNDgvLembretes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDgvLembretes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.GNDgvLembretes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.GNDgvLembretes.ThemeStyle.HeaderStyle.Height = 4;
            this.GNDgvLembretes.ThemeStyle.ReadOnly = true;
            this.GNDgvLembretes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.GNDgvLembretes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.GNDgvLembretes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.139131F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GNDgvLembretes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GNDgvLembretes.ThemeStyle.RowsStyle.Height = 24;
            this.GNDgvLembretes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.GNDgvLembretes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.GNDgvLembretes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GNDgvLembretes_CellContentClick);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.MinimumWidth = 6;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // titulo
            // 
            this.titulo.HeaderText = "Tiítulo";
            this.titulo.MinimumWidth = 6;
            this.titulo.Name = "titulo";
            this.titulo.ReadOnly = true;
            // 
            // descricao
            // 
            this.descricao.HeaderText = "Descrição";
            this.descricao.MinimumWidth = 6;
            this.descricao.Name = "descricao";
            this.descricao.ReadOnly = true;
            // 
            // vinculo
            // 
            this.vinculo.HeaderText = "Vinculo";
            this.vinculo.MinimumWidth = 6;
            this.vinculo.Name = "vinculo";
            this.vinculo.ReadOnly = true;
            this.vinculo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.vinculo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // op
            // 
            this.op.HeaderText = "Op";
            this.op.MinimumWidth = 6;
            this.op.Name = "op";
            this.op.ReadOnly = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "lixeira.png");
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
            this.GNCbxOps.Location = new System.Drawing.Point(18, 129);
            this.GNCbxOps.Name = "GNCbxOps";
            this.GNCbxOps.Size = new System.Drawing.Size(299, 36);
            this.GNCbxOps.TabIndex = 17;
            // 
            // CadastroLembretes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(171)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(1402, 900);
            this.Controls.Add(this.GNPanelCadastroLembretes);
            this.Name = "CadastroLembretes";
            this.Text = "CadastroLembretes";
            this.GNPanelCadastroLembretes.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GNDgvLembretes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel GNPanelCadastroLembretes;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtTituloLembrete;
        private Guna.UI2.WinForms.Guna2TextBox GNTxtDEscricaoCadastrarLembretes;
        private Guna.UI2.WinForms.Guna2Button GNBtnCadastrarCadastroLembretes;
        private Guna.UI2.WinForms.Guna2DataGridView GNDgvLembretes;
        private Guna.UI2.WinForms.Guna2CustomCheckBox GNCheckBoxVincular;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button GnBtnLimpar;
        private System.Windows.Forms.ImageList imageList1;
        private Guna.UI2.WinForms.Guna2HtmlLabel GNLblLembreteId;
        private Guna.UI2.WinForms.Guna2Button GNBtnAtualizar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn vinculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private Guna.UI2.WinForms.Guna2ComboBox GNCbxOps;
    }
}