
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
            this.setzlinge = new System.Windows.Forms.Button();
            this.lLastClickPixelsText = new System.Windows.Forms.Label();
            this.lLastClickCoordinatesText = new System.Windows.Forms.Label();
            this.lLastClickPixelsWert = new System.Windows.Forms.Label();
            this.lLastClickCoordinatesWert = new System.Windows.Forms.Label();
            this.lDebugInfoText = new System.Windows.Forms.Label();
            this.pilze = new System.Windows.Forms.Button();
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
            this.sonne.Text = "Sonne";
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
            this.wasser.Text = "Wasser";
            this.wasser.UseVisualStyleBackColor = false;
            // 
            // setzlinge
            // 
            this.setzlinge.AllowDrop = true;
            this.setzlinge.BackColor = System.Drawing.Color.OliveDrab;
            this.setzlinge.Location = new System.Drawing.Point(135, 354);
            this.setzlinge.Name = "setzlinge";
            this.setzlinge.Size = new System.Drawing.Size(108, 45);
            this.setzlinge.TabIndex = 6;
            this.setzlinge.Text = "Setzlinge";
            this.setzlinge.UseVisualStyleBackColor = false;
            this.setzlinge.Click += new System.EventHandler(this.setzlinge_Click);
            // 
            // lLastClickPixelsText
            // 
            this.lLastClickPixelsText.AutoSize = true;
            this.lLastClickPixelsText.Location = new System.Drawing.Point(536, 384);
            this.lLastClickPixelsText.Name = "lLastClickPixelsText";
            this.lLastClickPixelsText.Size = new System.Drawing.Size(29, 13);
            this.lLastClickPixelsText.TabIndex = 7;
            this.lLastClickPixelsText.Text = "Pixel";
            // 
            // lLastClickCoordinatesText
            // 
            this.lLastClickCoordinatesText.AutoSize = true;
            this.lLastClickCoordinatesText.Location = new System.Drawing.Point(536, 416);
            this.lLastClickCoordinatesText.Name = "lLastClickCoordinatesText";
            this.lLastClickCoordinatesText.Size = new System.Drawing.Size(64, 13);
            this.lLastClickCoordinatesText.TabIndex = 8;
            this.lLastClickCoordinatesText.Text = "Koordinaten";
            // 
            // lLastClickPixelsWert
            // 
            this.lLastClickPixelsWert.AutoSize = true;
            this.lLastClickPixelsWert.Location = new System.Drawing.Point(626, 384);
            this.lLastClickPixelsWert.Name = "lLastClickPixelsWert";
            this.lLastClickPixelsWert.Size = new System.Drawing.Size(35, 13);
            this.lLastClickPixelsWert.TabIndex = 9;
            this.lLastClickPixelsWert.Text = "label2";
            // 
            // lLastClickCoordinatesWert
            // 
            this.lLastClickCoordinatesWert.AutoSize = true;
            this.lLastClickCoordinatesWert.Location = new System.Drawing.Point(628, 416);
            this.lLastClickCoordinatesWert.Name = "lLastClickCoordinatesWert";
            this.lLastClickCoordinatesWert.Size = new System.Drawing.Size(35, 13);
            this.lLastClickCoordinatesWert.TabIndex = 10;
            this.lLastClickCoordinatesWert.Text = "label3";
            // 
            // lDebugInfoText
            // 
            this.lDebugInfoText.AutoSize = true;
            this.lDebugInfoText.Location = new System.Drawing.Point(536, 331);
            this.lDebugInfoText.Name = "lDebugInfoText";
            this.lDebugInfoText.Size = new System.Drawing.Size(42, 13);
            this.lDebugInfoText.TabIndex = 11;
            this.lDebugInfoText.Text = "Debug:";
            // 
            // pilze
            // 
            this.pilze.AllowDrop = true;
            this.pilze.BackColor = System.Drawing.Color.Crimson;
            this.pilze.Location = new System.Drawing.Point(135, 416);
            this.pilze.Name = "pilze";
            this.pilze.Size = new System.Drawing.Size(108, 45);
            this.pilze.TabIndex = 12;
            this.pilze.Text = "Pilze";
            this.pilze.UseVisualStyleBackColor = false;
            // 
            // Spielfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(730, 473);
            this.Controls.Add(this.pilze);
            this.Controls.Add(this.lDebugInfoText);
            this.Controls.Add(this.lLastClickCoordinatesWert);
            this.Controls.Add(this.lLastClickPixelsWert);
            this.Controls.Add(this.lLastClickCoordinatesText);
            this.Controls.Add(this.lLastClickPixelsText);
            this.Controls.Add(this.setzlinge);
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
        private System.Windows.Forms.Button setzlinge;
		private System.Windows.Forms.Label lLastClickPixelsText;
		private System.Windows.Forms.Label lLastClickCoordinatesText;
		private System.Windows.Forms.Label lLastClickPixelsWert;
		private System.Windows.Forms.Label lLastClickCoordinatesWert;
		private System.Windows.Forms.Label lDebugInfoText;
        private System.Windows.Forms.Button pilze;
    }
}

