namespace FlowValmet.Viwes
{
    partial class TelaKanban
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.PendenteFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.EmAndamentoflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.EmAtrasoflowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(27, 12);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(119, 43);
            this.guna2HtmlLabel1.TabIndex = 10;
            this.guna2HtmlLabel1.Text = "Kanban";
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Enabled = false;
            this.guna2Button1.FillColor = System.Drawing.Color.Silver;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(27, 105);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(437, 45);
            this.guna2Button1.TabIndex = 12;
            this.guna2Button1.Text = "Não Iniciado";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.Enabled = false;
            this.guna2Button2.FillColor = System.Drawing.Color.Silver;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(470, 105);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(437, 45);
            this.guna2Button2.TabIndex = 13;
            this.guna2Button2.Text = "Em Andamento";
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.Enabled = false;
            this.guna2Button3.FillColor = System.Drawing.Color.Silver;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(913, 105);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(437, 45);
            this.guna2Button3.TabIndex = 14;
            this.guna2Button3.Text = "Em Atraso";
            // 
            // PendenteFlowLayoutPanel
            // 
            this.PendenteFlowLayoutPanel.Location = new System.Drawing.Point(27, 156);
            this.PendenteFlowLayoutPanel.Name = "PendenteFlowLayoutPanel";
            this.PendenteFlowLayoutPanel.Size = new System.Drawing.Size(437, 582);
            this.PendenteFlowLayoutPanel.TabIndex = 15;
            this.PendenteFlowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PendenteFlowLayoutPanel_Paint);
            // 
            // EmAndamentoflowLayoutPanel
            // 
            this.EmAndamentoflowLayoutPanel.Location = new System.Drawing.Point(470, 156);
            this.EmAndamentoflowLayoutPanel.Name = "EmAndamentoflowLayoutPanel";
            this.EmAndamentoflowLayoutPanel.Size = new System.Drawing.Size(437, 582);
            this.EmAndamentoflowLayoutPanel.TabIndex = 16;
            this.EmAndamentoflowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.EmAndamentoflowLayoutPanel_Paint);
            // 
            // EmAtrasoflowLayoutPanel
            // 
            this.EmAtrasoflowLayoutPanel.Location = new System.Drawing.Point(913, 156);
            this.EmAtrasoflowLayoutPanel.Name = "EmAtrasoflowLayoutPanel";
            this.EmAtrasoflowLayoutPanel.Size = new System.Drawing.Size(437, 582);
            this.EmAtrasoflowLayoutPanel.TabIndex = 17;
            // 
            // TelaKanban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 750);
            this.Controls.Add(this.EmAtrasoflowLayoutPanel);
            this.Controls.Add(this.EmAndamentoflowLayoutPanel);
            this.Controls.Add(this.PendenteFlowLayoutPanel);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TelaKanban";
            this.Text = "TelaKanban";
            this.Load += new System.EventHandler(this.TelaKanban_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.FlowLayoutPanel PendenteFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel EmAndamentoflowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel EmAtrasoflowLayoutPanel;
    }
}