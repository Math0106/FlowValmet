namespace FlowValmet.Viwes
{
    partial class TelaIndicadores
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
            this.GNBTnSalvarPDF = new Guna.UI2.WinForms.Guna2Button();
            this.GNPanelCentro.SuspendLayout();
            this.SuspendLayout();
            // 
            // GNPanelCentro
            // 
            this.GNPanelCentro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelCentro.BorderRadius = 5;
            this.GNPanelCentro.Controls.Add(this.GNBTnSalvarPDF);
            this.GNPanelCentro.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GNPanelCentro.Location = new System.Drawing.Point(7, 5);
            this.GNPanelCentro.Name = "GNPanelCentro";
            this.GNPanelCentro.Size = new System.Drawing.Size(1368, 935);
            this.GNPanelCentro.TabIndex = 4;
            this.GNPanelCentro.Text = "guna2ContainerControl1";
            // 
            // GNBTnSalvarPDF
            // 
            this.GNBTnSalvarPDF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNBTnSalvarPDF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GNBTnSalvarPDF.BorderRadius = 20;
            this.GNBTnSalvarPDF.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.GNBTnSalvarPDF.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.GNBTnSalvarPDF.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.GNBTnSalvarPDF.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.GNBTnSalvarPDF.FillColor = System.Drawing.Color.Teal;
            this.GNBTnSalvarPDF.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.GNBTnSalvarPDF.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.GNBTnSalvarPDF.Location = new System.Drawing.Point(1222, 887);
            this.GNBTnSalvarPDF.Name = "GNBTnSalvarPDF";
            this.GNBTnSalvarPDF.Size = new System.Drawing.Size(138, 40);
            this.GNBTnSalvarPDF.TabIndex = 1;
            this.GNBTnSalvarPDF.Text = "Salvar PDF";
            // 
            // TelaIndicadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(171)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(1382, 944);
            this.Controls.Add(this.GNPanelCentro);
            this.Name = "TelaIndicadores";
            this.Text = "TelaIndicadores";
            this.GNPanelCentro.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelCentro;
        private Guna.UI2.WinForms.Guna2Button GNBTnSalvarPDF;
    }
}