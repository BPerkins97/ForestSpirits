
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
            this.lDisasterTimeText = new System.Windows.Forms.Label();
            this.lDisasterTimeWert = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lDisasterTypeText = new System.Windows.Forms.Label();
            this.lDisasterTypeWert = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pilze = new System.Windows.Forms.Button();
            this.sonne = new System.Windows.Forms.Button();
            this.wasser = new System.Windows.Forms.Button();
            this.setzlinge = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lSpielzeitText
            // 
            this.lSpielzeitText.AutoSize = true;
            this.lSpielzeitText.Font = new System.Drawing.Font("Tw Cen MT", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSpielzeitText.Location = new System.Drawing.Point(32, 20);
            this.lSpielzeitText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lSpielzeitText.Name = "lSpielzeitText";
            this.lSpielzeitText.Size = new System.Drawing.Size(114, 31);
            this.lSpielzeitText.TabIndex = 0;
            this.lSpielzeitText.Text = "Spielzeit:";
            this.lSpielzeitText.Click += new System.EventHandler(this.lSpielzeitText_Click);
            // 
            // lSpielzeitWert
            // 
            this.lSpielzeitWert.AutoSize = true;
            this.lSpielzeitWert.Font = new System.Drawing.Font("Tw Cen MT", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSpielzeitWert.Location = new System.Drawing.Point(174, 20);
            this.lSpielzeitWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lSpielzeitWert.Name = "lSpielzeitWert";
            this.lSpielzeitWert.Size = new System.Drawing.Size(85, 31);
            this.lSpielzeitWert.TabIndex = 1;
            this.lSpielzeitWert.Text = "label2";
            // 
            // lCo2LevelText
            // 
            this.lCo2LevelText.AutoSize = true;
            this.lCo2LevelText.Font = new System.Drawing.Font("Tw Cen MT Condensed", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCo2LevelText.Location = new System.Drawing.Point(15, 20);
            this.lCo2LevelText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lCo2LevelText.Name = "lCo2LevelText";
            this.lCo2LevelText.Size = new System.Drawing.Size(146, 44);
            this.lCo2LevelText.TabIndex = 2;
            this.lCo2LevelText.Text = "Co2 Wert:";
            this.lCo2LevelText.Click += new System.EventHandler(this.lCo2LevelText_Click);
            // 
            // lCo2LevelWert
            // 
            this.lCo2LevelWert.AutoSize = true;
            this.lCo2LevelWert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCo2LevelWert.Location = new System.Drawing.Point(173, 27);
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
            this.lLastClickPixelsText.Location = new System.Drawing.Point(1500, 955);
            this.lLastClickPixelsText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickPixelsText.Name = "lLastClickPixelsText";
            this.lLastClickPixelsText.Size = new System.Drawing.Size(59, 25);
            this.lLastClickPixelsText.TabIndex = 7;
            this.lLastClickPixelsText.Text = "Pixel";
            this.lLastClickPixelsText.Click += new System.EventHandler(this.lLastClickPixelsText_Click);
            // 
            // lLastClickCoordinatesText
            // 
            this.lLastClickCoordinatesText.AutoSize = true;
            this.lLastClickCoordinatesText.Location = new System.Drawing.Point(1500, 1001);
            this.lLastClickCoordinatesText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickCoordinatesText.Name = "lLastClickCoordinatesText";
            this.lLastClickCoordinatesText.Size = new System.Drawing.Size(128, 25);
            this.lLastClickCoordinatesText.TabIndex = 8;
            this.lLastClickCoordinatesText.Text = "Koordinaten";
            this.lLastClickCoordinatesText.Click += new System.EventHandler(this.lLastClickCoordinatesText_Click);
            // 
            // lLastClickPixelsWert
            // 
            this.lLastClickPixelsWert.AutoSize = true;
            this.lLastClickPixelsWert.Location = new System.Drawing.Point(1680, 955);
            this.lLastClickPixelsWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickPixelsWert.Name = "lLastClickPixelsWert";
            this.lLastClickPixelsWert.Size = new System.Drawing.Size(70, 25);
            this.lLastClickPixelsWert.TabIndex = 9;
            this.lLastClickPixelsWert.Text = "label2";
            this.lLastClickPixelsWert.Click += new System.EventHandler(this.lLastClickPixelsWert_Click);
            // 
            // lLastClickCoordinatesWert
            // 
            this.lLastClickCoordinatesWert.AutoSize = true;
            this.lLastClickCoordinatesWert.Location = new System.Drawing.Point(1680, 1001);
            this.lLastClickCoordinatesWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lLastClickCoordinatesWert.Name = "lLastClickCoordinatesWert";
            this.lLastClickCoordinatesWert.Size = new System.Drawing.Size(70, 25);
            this.lLastClickCoordinatesWert.TabIndex = 10;
            this.lLastClickCoordinatesWert.Text = "label3";
            this.lLastClickCoordinatesWert.Click += new System.EventHandler(this.lLastClickCoordinatesWert_Click);
            // 
            // lDebugInfoText
            // 
            this.lDebugInfoText.AutoSize = true;
            this.lDebugInfoText.Location = new System.Drawing.Point(1497, 905);
            this.lDebugInfoText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDebugInfoText.Name = "lDebugInfoText";
            this.lDebugInfoText.Size = new System.Drawing.Size(81, 25);
            this.lDebugInfoText.TabIndex = 11;
            this.lDebugInfoText.Text = "Debug:";
            this.lDebugInfoText.Click += new System.EventHandler(this.lDebugInfoText_Click);
            // 
            // lDisasterTimeText
            // 
            this.lDisasterTimeText.AutoSize = true;
            this.lDisasterTimeText.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisasterTimeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lDisasterTimeText.Location = new System.Drawing.Point(6, 27);
            this.lDisasterTimeText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDisasterTimeText.Name = "lDisasterTimeText";
            this.lDisasterTimeText.Size = new System.Drawing.Size(165, 38);
            this.lDisasterTimeText.TabIndex = 13;
            this.lDisasterTimeText.Text = "Katastrophe in:";
            this.lDisasterTimeText.Click += new System.EventHandler(this.lDisasterText_Click);
            // 
            // lDisasterTimeWert
            // 
            this.lDisasterTimeWert.AutoSize = true;
            this.lDisasterTimeWert.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisasterTimeWert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lDisasterTimeWert.Location = new System.Drawing.Point(163, 28);
            this.lDisasterTimeWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDisasterTimeWert.Name = "lDisasterTimeWert";
            this.lDisasterTimeWert.Size = new System.Drawing.Size(35, 37);
            this.lDisasterTimeWert.TabIndex = 14;
            this.lDisasterTimeWert.Text = "0";
            this.lDisasterTimeWert.Click += new System.EventHandler(this.lDisasterWert_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pilze);
            this.panel1.Controls.Add(this.sonne);
            this.panel1.Controls.Add(this.wasser);
            this.panel1.Controls.Add(this.setzlinge);
            this.panel1.Location = new System.Drawing.Point(1608, 447);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 486);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lSpielzeitText);
            this.panel2.Controls.Add(this.lSpielzeitWert);
            this.panel2.Location = new System.Drawing.Point(1482, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 67);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.lCo2LevelText);
            this.panel3.Controls.Add(this.lCo2LevelWert);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(1482, 89);
            this.panel3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(506, 88);
            this.panel3.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel4.Controls.Add(this.lDisasterTypeWert);
            this.panel4.Controls.Add(this.lDisasterTypeText);
            this.panel4.Controls.Add(this.lDisasterTimeText);
            this.panel4.Controls.Add(this.lDisasterTimeWert);
            this.panel4.Location = new System.Drawing.Point(1535, 210);
            this.panel4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(453, 153);
            this.panel4.TabIndex = 18;
            // 
            // lDisasterTypeText
            // 
            this.lDisasterTypeText.AutoSize = true;
            this.lDisasterTypeText.Font = new System.Drawing.Font("Tw Cen MT Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisasterTypeText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lDisasterTypeText.Location = new System.Drawing.Point(7, 89);
            this.lDisasterTypeText.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDisasterTypeText.Name = "lDisasterTypeText";
            this.lDisasterTypeText.Size = new System.Drawing.Size(181, 38);
            this.lDisasterTypeText.TabIndex = 13;
            this.lDisasterTypeText.Text = "Katastrophenart:";
            // 
            // lDisasterTypeWert
            // 
            this.lDisasterTypeWert.AutoSize = true;
            this.lDisasterTypeWert.Font = new System.Drawing.Font("Tw Cen MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDisasterTypeWert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lDisasterTypeWert.Location = new System.Drawing.Point(187, 90);
            this.lDisasterTypeWert.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lDisasterTypeWert.Name = "lDisasterTypeWert";
            this.lDisasterTypeWert.Size = new System.Drawing.Size(28, 37);
            this.lDisasterTypeWert.TabIndex = 14;
            this.lDisasterTypeWert.Text = "s";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tw Cen MT Condensed", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SlateGray;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 44);
            this.label1.TabIndex = 4;
            this.label1.Text = "Iventar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pilze
            // 
            this.pilze.AllowDrop = true;
            this.pilze.BackColor = System.Drawing.Color.Transparent;
            this.pilze.BackgroundImage = global::Frontend.Properties.Resources.mushroom;
            this.pilze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pilze.Location = new System.Drawing.Point(200, 303);
            this.pilze.Margin = new System.Windows.Forms.Padding(6);
            this.pilze.Name = "pilze";
            this.pilze.Size = new System.Drawing.Size(132, 133);
            this.pilze.TabIndex = 12;
            this.pilze.UseVisualStyleBackColor = false;
            // 
            // sonne
            // 
            this.sonne.AllowDrop = true;
            this.sonne.BackColor = System.Drawing.Color.Transparent;
            this.sonne.BackgroundImage = global::Frontend.Properties.Resources.sonne;
            this.sonne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sonne.Location = new System.Drawing.Point(200, 95);
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
            this.wasser.Location = new System.Drawing.Point(28, 95);
            this.wasser.Margin = new System.Windows.Forms.Padding(6);
            this.wasser.Name = "wasser";
            this.wasser.Size = new System.Drawing.Size(132, 133);
            this.wasser.TabIndex = 5;
            this.wasser.UseVisualStyleBackColor = false;
            this.wasser.Click += new System.EventHandler(this.wasser_Click);
            // 
            // setzlinge
            // 
            this.setzlinge.AllowDrop = true;
            this.setzlinge.BackColor = System.Drawing.Color.Transparent;
            this.setzlinge.BackgroundImage = global::Frontend.Properties.Resources.beech_seedling_;
            this.setzlinge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.setzlinge.Location = new System.Drawing.Point(28, 302);
            this.setzlinge.Margin = new System.Windows.Forms.Padding(6);
            this.setzlinge.Name = "setzlinge";
            this.setzlinge.Size = new System.Drawing.Size(132, 133);
            this.setzlinge.TabIndex = 6;
            this.setzlinge.UseVisualStyleBackColor = false;
            this.setzlinge.Click += new System.EventHandler(this.setzlinge_Click);
            // 
            // Spielfenster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1972, 1112);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Spielfenster";
            this.Text = "Forest Spirits";
            this.Shown += new System.EventHandler(this.start);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
		private System.Windows.Forms.Label lDisasterTimeText;
		private System.Windows.Forms.Label lDisasterTimeWert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label lDisasterTypeText;
		private System.Windows.Forms.Label lDisasterTypeWert;
        private System.Windows.Forms.Label label1;
    }
}

