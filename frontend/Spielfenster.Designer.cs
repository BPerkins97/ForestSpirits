
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
            this.lLastClickPixelsText = new System.Windows.Forms.Label();
            this.lLastClickCoordinatesText = new System.Windows.Forms.Label();
            this.lLastClickPixelsWert = new System.Windows.Forms.Label();
            this.lLastClickCoordinatesWert = new System.Windows.Forms.Label();
            this.lDebugInfoText = new System.Windows.Forms.Label();
            this.lDisasterText = new System.Windows.Forms.Label();
            this.lDisasterWert = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pilze = new System.Windows.Forms.Button();
            this.setzlinge = new System.Windows.Forms.Button();
            this.sonne = new System.Windows.Forms.Button();
            this.wasser = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lSpielzeitText
            // 
            this.lSpielzeitText.AutoSize = true;
            this.lSpielzeitText.Location = new System.Drawing.Point(33, 22);
            this.lSpielzeitText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lSpielzeitText.Name = "lSpielzeitText";
            this.lSpielzeitText.Size = new System.Drawing.Size(100, 25);
            this.lSpielzeitText.TabIndex = 0;
            this.lSpielzeitText.Text = "Spielzeit:";
            this.lSpielzeitText.Click += new System.EventHandler(this.lSpielzeitText_Click);
            // 
            // lSpielzeitWert
            // 
            this.lSpielzeitWert.AutoSize = true;
            this.lSpielzeitWert.Location = new System.Drawing.Point(200, 23);
            this.lSpielzeitWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lSpielzeitWert.Name = "lSpielzeitWert";
            this.lSpielzeitWert.Size = new System.Drawing.Size(70, 25);
            this.lSpielzeitWert.TabIndex = 1;
            this.lSpielzeitWert.Text = "label2";
            // 
            // lCo2LevelText
            // 
            this.lCo2LevelText.AutoSize = true;
            this.lCo2LevelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCo2LevelText.Location = new System.Drawing.Point(18, 27);
            this.lCo2LevelText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lCo2LevelText.Name = "lCo2LevelText";
            this.lCo2LevelText.Size = new System.Drawing.Size(162, 37);
            this.lCo2LevelText.TabIndex = 2;
            this.lCo2LevelText.Text = "Co2 Wert:";
            // 
            // lCo2LevelWert
            // 
            this.lCo2LevelWert.AutoSize = true;
            this.lCo2LevelWert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCo2LevelWert.Location = new System.Drawing.Point(231, 27);
            this.lCo2LevelWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lCo2LevelWert.Name = "lCo2LevelWert";
            this.lCo2LevelWert.Size = new System.Drawing.Size(31, 33);
            this.lCo2LevelWert.TabIndex = 3;
            this.lCo2LevelWert.Text = "0";
            this.lCo2LevelWert.Click += new System.EventHandler(this.lCo2LevelWert_Click);
            // 
            // lLastClickPixelsText
            // 
            this.lLastClickPixelsText.AutoSize = true;
            this.lLastClickPixelsText.Location = new System.Drawing.Point(1778, 796);
            this.lLastClickPixelsText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickPixelsText.Name = "lLastClickPixelsText";
            this.lLastClickPixelsText.Size = new System.Drawing.Size(59, 25);
            this.lLastClickPixelsText.TabIndex = 7;
            this.lLastClickPixelsText.Text = "Pixel";
            // 
            // lLastClickCoordinatesText
            // 
            this.lLastClickCoordinatesText.AutoSize = true;
            this.lLastClickCoordinatesText.Location = new System.Drawing.Point(1778, 843);
            this.lLastClickCoordinatesText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickCoordinatesText.Name = "lLastClickCoordinatesText";
            this.lLastClickCoordinatesText.Size = new System.Drawing.Size(128, 25);
            this.lLastClickCoordinatesText.TabIndex = 8;
            this.lLastClickCoordinatesText.Text = "Koordinaten";
            // 
            // lLastClickPixelsWert
            // 
            this.lLastClickPixelsWert.AutoSize = true;
            this.lLastClickPixelsWert.Location = new System.Drawing.Point(1958, 796);
            this.lLastClickPixelsWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickPixelsWert.Name = "lLastClickPixelsWert";
            this.lLastClickPixelsWert.Size = new System.Drawing.Size(70, 25);
            this.lLastClickPixelsWert.TabIndex = 9;
            this.lLastClickPixelsWert.Text = "label2";
            // 
            // lLastClickCoordinatesWert
            // 
            this.lLastClickCoordinatesWert.AutoSize = true;
            this.lLastClickCoordinatesWert.Location = new System.Drawing.Point(1958, 843);
            this.lLastClickCoordinatesWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickCoordinatesWert.Name = "lLastClickCoordinatesWert";
            this.lLastClickCoordinatesWert.Size = new System.Drawing.Size(70, 25);
            this.lLastClickCoordinatesWert.TabIndex = 10;
            this.lLastClickCoordinatesWert.Text = "label3";
            // 
            // lDebugInfoText
            // 
            this.lDebugInfoText.AutoSize = true;
            this.lDebugInfoText.Location = new System.Drawing.Point(1778, 642);
            this.lDebugInfoText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDebugInfoText.Name = "lDebugInfoText";
            this.lDebugInfoText.Size = new System.Drawing.Size(81, 25);
            this.lDebugInfoText.TabIndex = 11;
            this.lDebugInfoText.Text = "Debug:";
            // 
            // lDisasterText
            // 
            this.lDisasterText.AutoSize = true;
            this.lDisasterText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisasterText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lDisasterText.Location = new System.Drawing.Point(8, 27);
            this.lDisasterText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDisasterText.Name = "lDisasterText";
            this.lDisasterText.Size = new System.Drawing.Size(173, 29);
            this.lDisasterText.TabIndex = 13;
            this.lDisasterText.Text = "Katastrophe in:";
            this.lDisasterText.Click += new System.EventHandler(this.lDisasterText_Click);
            // 
            // lDisasterWert
            // 
            this.lDisasterWert.AutoSize = true;
            this.lDisasterWert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisasterWert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lDisasterWert.Location = new System.Drawing.Point(184, 27);
            this.lDisasterWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDisasterWert.Name = "lDisasterWert";
            this.lDisasterWert.Size = new System.Drawing.Size(29, 31);
            this.lDisasterWert.TabIndex = 14;
            this.lDisasterWert.Text = "0";
            this.lDisasterWert.Click += new System.EventHandler(this.lDisasterWert_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.pilze);
            this.panel1.Controls.Add(this.setzlinge);
            this.panel1.Controls.Add(this.sonne);
            this.panel1.Controls.Add(this.wasser);
            this.panel1.Location = new System.Drawing.Point(973, 889);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1183, 206);
            this.panel1.TabIndex = 15;
            // 
            // pilze
            // 
            this.pilze.AllowDrop = true;
            this.pilze.BackColor = System.Drawing.Color.Transparent;
            this.pilze.BackgroundImage = global::Frontend.Properties.Resources.mushroom;
            this.pilze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pilze.Location = new System.Drawing.Point(721, 23);
            this.pilze.Margin = new System.Windows.Forms.Padding(6);
            this.pilze.Name = "pilze";
            this.pilze.Size = new System.Drawing.Size(132, 133);
            this.pilze.TabIndex = 12;
            this.pilze.UseVisualStyleBackColor = false;
            // 
            // setzlinge
            // 
            this.setzlinge.AllowDrop = true;
            this.setzlinge.BackColor = System.Drawing.Color.Transparent;
            this.setzlinge.BackgroundImage = global::Frontend.Properties.Resources.setzling;
            this.setzlinge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setzlinge.Location = new System.Drawing.Point(566, 23);
            this.setzlinge.Margin = new System.Windows.Forms.Padding(6);
            this.setzlinge.Name = "setzlinge";
            this.setzlinge.Size = new System.Drawing.Size(132, 133);
            this.setzlinge.TabIndex = 6;
            this.setzlinge.UseVisualStyleBackColor = false;
            this.setzlinge.Click += new System.EventHandler(this.setzlinge_Click);
            // 
            // sonne
            // 
            this.sonne.AllowDrop = true;
            this.sonne.BackColor = System.Drawing.Color.Transparent;
            this.sonne.BackgroundImage = global::Frontend.Properties.Resources.sonne;
            this.sonne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sonne.Location = new System.Drawing.Point(294, 23);
            this.sonne.Margin = new System.Windows.Forms.Padding(6);
            this.sonne.Name = "sonne";
            this.sonne.Size = new System.Drawing.Size(132, 133);
            this.sonne.TabIndex = 4;
            this.sonne.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.sonne.UseVisualStyleBackColor = false;
            this.sonne.Click += new System.EventHandler(this.sonne_Click);
            // 
            // wasser
            // 
            this.wasser.AllowDrop = true;
            this.wasser.BackColor = System.Drawing.Color.Transparent;
            this.wasser.BackgroundImage = global::Frontend.Properties.Resources.wasser;
            this.wasser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.wasser.Location = new System.Drawing.Point(140, 23);
            this.wasser.Margin = new System.Windows.Forms.Padding(6);
            this.wasser.Name = "wasser";
            this.wasser.Size = new System.Drawing.Size(132, 133);
            this.wasser.TabIndex = 5;
            this.wasser.UseVisualStyleBackColor = false;
            this.wasser.Click += new System.EventHandler(this.wasser_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lSpielzeitText);
            this.panel2.Controls.Add(this.lSpielzeitWert);
            this.panel2.Location = new System.Drawing.Point(1694, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(463, 67);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.lCo2LevelText);
            this.panel3.Controls.Add(this.lCo2LevelWert);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(1694, 122);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(463, 89);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.lDisasterText);
            this.panel4.Controls.Add(this.lDisasterWert);
            this.panel4.Location = new System.Drawing.Point(1783, 242);
            this.panel4.Margin = new System.Windows.Forms.Padding(6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(374, 85);
            this.panel4.TabIndex = 18;
            // 
            // Spielfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(2152, 1108);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lDebugInfoText);
            this.Controls.Add(this.lLastClickCoordinatesWert);
            this.Controls.Add(this.lLastClickPixelsWert);
            this.Controls.Add(this.lLastClickCoordinatesText);
            this.Controls.Add(this.lLastClickPixelsText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Spielfenster";
            this.Text = "Forest Spirits";
            this.Shown += new System.EventHandler(this.start);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onClick);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
		private System.Windows.Forms.Label lDisasterText;
		private System.Windows.Forms.Label lDisasterWert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}

