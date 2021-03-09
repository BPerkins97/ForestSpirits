
namespace Frontend
{
    partial class ForestSpirits
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lPaint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lPaint
            // 
            this.lPaint.AutoSize = true;
            this.lPaint.Location = new System.Drawing.Point(518, 401);
            this.lPaint.Name = "lPaint";
            this.lPaint.Size = new System.Drawing.Size(35, 13);
            this.lPaint.TabIndex = 0;
            this.lPaint.Text = "label1";
            // 
            // ForestSpirits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(730, 473);
            this.Controls.Add(this.lPaint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ForestSpirits";
            this.Text = "Forest Spirits";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.draw);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lPaint;
    }
}

