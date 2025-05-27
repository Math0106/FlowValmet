namespace FlowValmet.Viwes
{
    partial class FaseUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Fasetxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Fasetxt
            // 
            this.Fasetxt.AutoSize = true;
            this.Fasetxt.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Fasetxt.Location = new System.Drawing.Point(12, 8);
            this.Fasetxt.Name = "Fasetxt";
            this.Fasetxt.Size = new System.Drawing.Size(40, 21);
            this.Fasetxt.TabIndex = 0;
            this.Fasetxt.Text = "Fase";
            // 
            // FaseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Fasetxt);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FaseUserControl";
            this.Size = new System.Drawing.Size(155, 39);
            this.Load += new System.EventHandler(this.FaseUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Fasetxt;
    }
}
