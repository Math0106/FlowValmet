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
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.GNPanelCentro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.SuspendLayout();
            // 
            // GNPanelCentro
            // 
            this.GNPanelCentro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GNPanelCentro.BorderRadius = 5;
            this.GNPanelCentro.Controls.Add(this.webView21);
            this.GNPanelCentro.FillColor = System.Drawing.Color.WhiteSmoke;
            this.GNPanelCentro.Location = new System.Drawing.Point(7, 5);
            this.GNPanelCentro.Name = "GNPanelCentro";
            this.GNPanelCentro.Size = new System.Drawing.Size(1368, 935);
            this.GNPanelCentro.TabIndex = 4;
            this.GNPanelCentro.Text = "guna2ContainerControl1";
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(15, 18);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(1337, 900);
            this.webView21.TabIndex = 2;
            this.webView21.ZoomFactor = 1D;
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
            this.Load += new System.EventHandler(this.TelaIndicadores_Load);
            this.GNPanelCentro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl GNPanelCentro;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}