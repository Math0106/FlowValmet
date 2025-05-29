namespace FlowValmet.Viwes
{
    partial class OpDetalhada
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
            this.GNPanelPrincipal = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.SuspendLayout();
            // 
            // GNPanelPrincipal
            // 
            this.GNPanelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelPrincipal.BorderRadius = 5;
            this.GNPanelPrincipal.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GNPanelPrincipal.Location = new System.Drawing.Point(2, 2);
            this.GNPanelPrincipal.Name = "GNPanelPrincipal";
            this.GNPanelPrincipal.Size = new System.Drawing.Size(1383, 946);
            this.GNPanelPrincipal.TabIndex = 4;
            this.GNPanelPrincipal.Text = "guna2ContainerControl1";
            // 
            // OpDetalhada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(171)))), ((int)(((byte)(167)))));
            this.ClientSize = new System.Drawing.Size(1387, 949);
            this.Controls.Add(this.GNPanelPrincipal);
            this.Name = "OpDetalhada";
            this.Text = "OpDetalhada";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelPrincipal;
    }
}