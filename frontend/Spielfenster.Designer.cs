
namespace ForestSpirits.Frontend
{
    partial class Spielfenster
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
            this.lSpielzeitText = new System.Windows.Forms.Label();
            this.lSpielzeitWert = new System.Windows.Forms.Label();
            this.lCo2LevelText = new System.Windows.Forms.Label();
            this.lCo2LevelWert = new System.Windows.Forms.Label();
            this.sonne = new System.Windows.Forms.Button();
            this.wasser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lSpielzeitText
            // 
            this.lSpielzeitText.AutoSize = true;
            this.lSpielzeitText.Location = new System.Drawing.Point(558, 75);
            this.lSpielzeitText.Name = "lSpielzeitText";
            this.lSpielzeitText.Size = new System.Drawing.Size(49, 13);
            this.lSpielzeitText.TabIndex = 0;
            this.lSpielzeitText.Text = "Spielzeit:";
            // 
            // lSpielzeitWert
            // 
            this.lSpielzeitWert.AutoSize = true;
            this.lSpielzeitWert.Location = new System.Drawing.Point(623, 74);
            this.lSpielzeitWert.Name = "lSpielzeitWert";
            this.lSpielzeitWert.Size = new System.Drawing.Size(35, 13);
            this.lSpielzeitWert.TabIndex = 1;
            this.lSpielzeitWert.Text = "label2";
            // 
            // lCo2LevelText
            // 
            this.lCo2LevelText.AutoSize = true;
            this.lCo2LevelText.Location = new System.Drawing.Point(558, 103);
            this.lCo2LevelText.Name = "lCo2LevelText";
            this.lCo2LevelText.Size = new System.Drawing.Size(52, 13);
            this.lCo2LevelText.TabIndex = 2;
            this.lCo2LevelText.Text = "Co2 Wert";
            // 
            // lCo2LevelWert
            // 
            this.lCo2LevelWert.AutoSize = true;
            this.lCo2LevelWert.Location = new System.Drawing.Point(626, 103);
            this.lCo2LevelWert.Name = "lCo2LevelWert";
            this.lCo2LevelWert.Size = new System.Drawing.Size(13, 13);
            this.lCo2LevelWert.TabIndex = 3;
            this.lCo2LevelWert.Text = "0";
            // 
            // sonne
            // 
            this.sonne.AllowDrop = true;
            this.sonne.BackColor = System.Drawing.Color.Yellow;
            this.sonne.Location = new System.Drawing.Point(12, 354);
            this.sonne.Name = "sonne";
            this.sonne.Size = new System.Drawing.Size(108, 45);
            this.sonne.TabIndex = 4;
            this.sonne.Text = "sonne";
            this.sonne.UseVisualStyleBackColor = false;
            // 
            // wasser
            // 
            this.wasser.AllowDrop = true;
            this.wasser.BackColor = System.Drawing.Color.Aqua;
            this.wasser.Location = new System.Drawing.Point(12, 416);
            this.wasser.Name = "wasser";
            this.wasser.Size = new System.Drawing.Size(108, 45);
            this.wasser.TabIndex = 5;
            this.wasser.Text = "button1";
            this.wasser.UseVisualStyleBackColor = false;
            // 
            // Spielfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(730, 473);
            this.Controls.Add(this.wasser);
            this.Controls.Add(this.sonne);
            this.Controls.Add(this.lCo2LevelWert);
            this.Controls.Add(this.lCo2LevelText);
            this.Controls.Add(this.lSpielzeitWert);
            this.Controls.Add(this.lSpielzeitText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Spielfenster";
            this.Text = "Forest Spirits";
            this.Shown += new System.EventHandler(this.start);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSpielzeitText;
        private System.Windows.Forms.Label lSpielzeitWert;
        private System.Windows.Forms.Label lCo2LevelText;
        private System.Windows.Forms.Label lCo2LevelWert;
        private System.Windows.Forms.Button sonne;
        private System.Windows.Forms.Button wasser;
    }
}

