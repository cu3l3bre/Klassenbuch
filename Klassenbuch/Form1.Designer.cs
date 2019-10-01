namespace Klassenbuch
{
    partial class FormMain
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
            this.panelSchueler = new System.Windows.Forms.Panel();
            this.labelSchueler = new System.Windows.Forms.Label();
            this.panelUnterricht = new System.Windows.Forms.Panel();
            this.labelFachText = new System.Windows.Forms.Label();
            this.labelLehrerText = new System.Windows.Forms.Label();
            this.labelKlasseText = new System.Windows.Forms.Label();
            this.labelUnterrichtText = new System.Windows.Forms.Label();
            this.panelLehrstoff = new System.Windows.Forms.Panel();
            this.labelLehrstoffText = new System.Windows.Forms.Label();
            this.comboBoxRaum = new System.Windows.Forms.ComboBox();
            this.labelRaumText = new System.Windows.Forms.Label();
            this.comboBoxEinheit = new System.Windows.Forms.ComboBox();
            this.labelEinheitText = new System.Windows.Forms.Label();
            this.labelKlasse = new System.Windows.Forms.Label();
            this.labelLehrer = new System.Windows.Forms.Label();
            this.labelFach = new System.Windows.Forms.Label();
            this.labelUnterrichtBeginn = new System.Windows.Forms.Label();
            this.labelUnterrichtEnde = new System.Windows.Forms.Label();
            this.labelUnterrichtBeginnText = new System.Windows.Forms.Label();
            this.labelUnterrichtEndeText = new System.Windows.Forms.Label();
            this.textBoxLehrstoff = new System.Windows.Forms.TextBox();
            this.panelSchueler.SuspendLayout();
            this.panelUnterricht.SuspendLayout();
            this.panelLehrstoff.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSchueler
            // 
            this.panelSchueler.BackColor = System.Drawing.Color.Transparent;
            this.panelSchueler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSchueler.Controls.Add(this.labelSchueler);
            this.panelSchueler.Location = new System.Drawing.Point(13, 179);
            this.panelSchueler.Name = "panelSchueler";
            this.panelSchueler.Size = new System.Drawing.Size(1032, 334);
            this.panelSchueler.TabIndex = 0;
            // 
            // labelSchueler
            // 
            this.labelSchueler.AutoSize = true;
            this.labelSchueler.Location = new System.Drawing.Point(7, 14);
            this.labelSchueler.Name = "labelSchueler";
            this.labelSchueler.Size = new System.Drawing.Size(111, 13);
            this.labelSchueler.TabIndex = 0;
            this.labelSchueler.Text = "Schueler im Unterricht";
            // 
            // panelUnterricht
            // 
            this.panelUnterricht.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUnterricht.Controls.Add(this.labelFach);
            this.panelUnterricht.Controls.Add(this.labelLehrer);
            this.panelUnterricht.Controls.Add(this.labelKlasse);
            this.panelUnterricht.Controls.Add(this.labelFachText);
            this.panelUnterricht.Controls.Add(this.labelLehrerText);
            this.panelUnterricht.Controls.Add(this.labelKlasseText);
            this.panelUnterricht.Controls.Add(this.labelUnterrichtText);
            this.panelUnterricht.Location = new System.Drawing.Point(13, 51);
            this.panelUnterricht.Name = "panelUnterricht";
            this.panelUnterricht.Size = new System.Drawing.Size(1031, 97);
            this.panelUnterricht.TabIndex = 1;
            // 
            // labelFachText
            // 
            this.labelFachText.AutoSize = true;
            this.labelFachText.Location = new System.Drawing.Point(6, 72);
            this.labelFachText.Name = "labelFachText";
            this.labelFachText.Size = new System.Drawing.Size(31, 13);
            this.labelFachText.TabIndex = 3;
            this.labelFachText.Text = "Fach";
            // 
            // labelLehrerText
            // 
            this.labelLehrerText.AutoSize = true;
            this.labelLehrerText.Location = new System.Drawing.Point(6, 49);
            this.labelLehrerText.Name = "labelLehrerText";
            this.labelLehrerText.Size = new System.Drawing.Size(37, 13);
            this.labelLehrerText.TabIndex = 2;
            this.labelLehrerText.Text = "Lehrer";
            // 
            // labelKlasseText
            // 
            this.labelKlasseText.AutoSize = true;
            this.labelKlasseText.Location = new System.Drawing.Point(6, 28);
            this.labelKlasseText.Name = "labelKlasseText";
            this.labelKlasseText.Size = new System.Drawing.Size(38, 13);
            this.labelKlasseText.TabIndex = 1;
            this.labelKlasseText.Text = "Klasse";
            // 
            // labelUnterrichtText
            // 
            this.labelUnterrichtText.AutoSize = true;
            this.labelUnterrichtText.Location = new System.Drawing.Point(3, 0);
            this.labelUnterrichtText.Name = "labelUnterrichtText";
            this.labelUnterrichtText.Size = new System.Drawing.Size(53, 13);
            this.labelUnterrichtText.TabIndex = 0;
            this.labelUnterrichtText.Text = "Unterricht";
            // 
            // panelLehrstoff
            // 
            this.panelLehrstoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLehrstoff.Controls.Add(this.textBoxLehrstoff);
            this.panelLehrstoff.Controls.Add(this.labelLehrstoffText);
            this.panelLehrstoff.Location = new System.Drawing.Point(12, 550);
            this.panelLehrstoff.Name = "panelLehrstoff";
            this.panelLehrstoff.Size = new System.Drawing.Size(1032, 100);
            this.panelLehrstoff.TabIndex = 2;
            // 
            // labelLehrstoffText
            // 
            this.labelLehrstoffText.AutoSize = true;
            this.labelLehrstoffText.Location = new System.Drawing.Point(10, 15);
            this.labelLehrstoffText.Name = "labelLehrstoffText";
            this.labelLehrstoffText.Size = new System.Drawing.Size(48, 13);
            this.labelLehrstoffText.TabIndex = 0;
            this.labelLehrstoffText.Text = "Lehrstoff";
            // 
            // comboBoxRaum
            // 
            this.comboBoxRaum.FormattingEnabled = true;
            this.comboBoxRaum.Location = new System.Drawing.Point(739, 14);
            this.comboBoxRaum.Name = "comboBoxRaum";
            this.comboBoxRaum.Size = new System.Drawing.Size(305, 21);
            this.comboBoxRaum.TabIndex = 3;
            this.comboBoxRaum.TextChanged += new System.EventHandler(this.ComboBoxRaum_TextChanged);
            // 
            // labelRaumText
            // 
            this.labelRaumText.AutoSize = true;
            this.labelRaumText.Location = new System.Drawing.Point(698, 17);
            this.labelRaumText.Name = "labelRaumText";
            this.labelRaumText.Size = new System.Drawing.Size(35, 13);
            this.labelRaumText.TabIndex = 4;
            this.labelRaumText.Text = "Raum";
            // 
            // comboBoxEinheit
            // 
            this.comboBoxEinheit.FormattingEnabled = true;
            this.comboBoxEinheit.Location = new System.Drawing.Point(527, 14);
            this.comboBoxEinheit.Name = "comboBoxEinheit";
            this.comboBoxEinheit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEinheit.TabIndex = 5;
            // 
            // labelEinheitText
            // 
            this.labelEinheitText.AutoSize = true;
            this.labelEinheitText.Location = new System.Drawing.Point(482, 17);
            this.labelEinheitText.Name = "labelEinheitText";
            this.labelEinheitText.Size = new System.Drawing.Size(39, 13);
            this.labelEinheitText.TabIndex = 6;
            this.labelEinheitText.Text = "Einheit";
            // 
            // labelKlasse
            // 
            this.labelKlasse.AutoSize = true;
            this.labelKlasse.Location = new System.Drawing.Point(50, 28);
            this.labelKlasse.Name = "labelKlasse";
            this.labelKlasse.Size = new System.Drawing.Size(10, 13);
            this.labelKlasse.TabIndex = 4;
            this.labelKlasse.Text = "-";
            // 
            // labelLehrer
            // 
            this.labelLehrer.AutoSize = true;
            this.labelLehrer.Location = new System.Drawing.Point(50, 49);
            this.labelLehrer.Name = "labelLehrer";
            this.labelLehrer.Size = new System.Drawing.Size(10, 13);
            this.labelLehrer.TabIndex = 5;
            this.labelLehrer.Text = "-";
            // 
            // labelFach
            // 
            this.labelFach.AutoSize = true;
            this.labelFach.Location = new System.Drawing.Point(50, 72);
            this.labelFach.Name = "labelFach";
            this.labelFach.Size = new System.Drawing.Size(10, 13);
            this.labelFach.TabIndex = 6;
            this.labelFach.Text = "-";
            // 
            // labelUnterrichtBeginn
            // 
            this.labelUnterrichtBeginn.AutoSize = true;
            this.labelUnterrichtBeginn.Location = new System.Drawing.Point(77, 17);
            this.labelUnterrichtBeginn.Name = "labelUnterrichtBeginn";
            this.labelUnterrichtBeginn.Size = new System.Drawing.Size(10, 13);
            this.labelUnterrichtBeginn.TabIndex = 7;
            this.labelUnterrichtBeginn.Text = "-";
            // 
            // labelUnterrichtEnde
            // 
            this.labelUnterrichtEnde.AutoSize = true;
            this.labelUnterrichtEnde.Location = new System.Drawing.Point(169, 17);
            this.labelUnterrichtEnde.Name = "labelUnterrichtEnde";
            this.labelUnterrichtEnde.Size = new System.Drawing.Size(10, 13);
            this.labelUnterrichtEnde.TabIndex = 8;
            this.labelUnterrichtEnde.Text = "-";
            // 
            // labelUnterrichtBeginnText
            // 
            this.labelUnterrichtBeginnText.AutoSize = true;
            this.labelUnterrichtBeginnText.Location = new System.Drawing.Point(23, 17);
            this.labelUnterrichtBeginnText.Name = "labelUnterrichtBeginnText";
            this.labelUnterrichtBeginnText.Size = new System.Drawing.Size(26, 13);
            this.labelUnterrichtBeginnText.TabIndex = 9;
            this.labelUnterrichtBeginnText.Text = "Von";
            // 
            // labelUnterrichtEndeText
            // 
            this.labelUnterrichtEndeText.AutoSize = true;
            this.labelUnterrichtEndeText.Location = new System.Drawing.Point(137, 17);
            this.labelUnterrichtEndeText.Name = "labelUnterrichtEndeText";
            this.labelUnterrichtEndeText.Size = new System.Drawing.Size(20, 13);
            this.labelUnterrichtEndeText.TabIndex = 10;
            this.labelUnterrichtEndeText.Text = "bis";
            // 
            // textBoxLehrstoff
            // 
            this.textBoxLehrstoff.Location = new System.Drawing.Point(67, 15);
            this.textBoxLehrstoff.Name = "textBoxLehrstoff";
            this.textBoxLehrstoff.Size = new System.Drawing.Size(246, 20);
            this.textBoxLehrstoff.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 710);
            this.Controls.Add(this.labelUnterrichtEndeText);
            this.Controls.Add(this.labelUnterrichtBeginnText);
            this.Controls.Add(this.labelUnterrichtEnde);
            this.Controls.Add(this.labelUnterrichtBeginn);
            this.Controls.Add(this.labelEinheitText);
            this.Controls.Add(this.comboBoxEinheit);
            this.Controls.Add(this.labelRaumText);
            this.Controls.Add(this.comboBoxRaum);
            this.Controls.Add(this.panelLehrstoff);
            this.Controls.Add(this.panelUnterricht);
            this.Controls.Add(this.panelSchueler);
            this.Name = "FormMain";
            this.Text = "Klassenbuch";
            this.panelSchueler.ResumeLayout(false);
            this.panelSchueler.PerformLayout();
            this.panelUnterricht.ResumeLayout(false);
            this.panelUnterricht.PerformLayout();
            this.panelLehrstoff.ResumeLayout(false);
            this.panelLehrstoff.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSchueler;
        private System.Windows.Forms.Panel panelUnterricht;
        private System.Windows.Forms.Panel panelLehrstoff;
        private System.Windows.Forms.ComboBox comboBoxRaum;
        private System.Windows.Forms.Label labelSchueler;
        private System.Windows.Forms.Label labelFachText;
        private System.Windows.Forms.Label labelLehrerText;
        private System.Windows.Forms.Label labelKlasseText;
        private System.Windows.Forms.Label labelUnterrichtText;
        private System.Windows.Forms.Label labelLehrstoffText;
        private System.Windows.Forms.Label labelRaumText;
        private System.Windows.Forms.ComboBox comboBoxEinheit;
        private System.Windows.Forms.Label labelEinheitText;
        private System.Windows.Forms.Label labelFach;
        private System.Windows.Forms.Label labelLehrer;
        private System.Windows.Forms.Label labelKlasse;
        private System.Windows.Forms.Label labelUnterrichtBeginn;
        private System.Windows.Forms.Label labelUnterrichtEnde;
        private System.Windows.Forms.Label labelUnterrichtBeginnText;
        private System.Windows.Forms.Label labelUnterrichtEndeText;
        private System.Windows.Forms.TextBox textBoxLehrstoff;
    }
}

