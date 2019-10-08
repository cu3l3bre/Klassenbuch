namespace Klassenbuch
{
    partial class Form1
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
            this.labelFach = new System.Windows.Forms.Label();
            this.labelLehrer = new System.Windows.Forms.Label();
            this.labelKlasse = new System.Windows.Forms.Label();
            this.labelFachText = new System.Windows.Forms.Label();
            this.labelLehrerText = new System.Windows.Forms.Label();
            this.labelKlasseText = new System.Windows.Forms.Label();
            this.labelUnterrichtText = new System.Windows.Forms.Label();
            this.panelLehrstoff = new System.Windows.Forms.Panel();
            this.textBoxLehrstoff = new System.Windows.Forms.TextBox();
            this.labelLehrstoffText = new System.Windows.Forms.Label();
            this.comboBoxRaum = new System.Windows.Forms.ComboBox();
            this.labelRaumText = new System.Windows.Forms.Label();
            this.comboBoxEinheit = new System.Windows.Forms.ComboBox();
            this.labelEinheitText = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonDatumHeute = new System.Windows.Forms.Button();
            this.buttonTagZurueck = new System.Windows.Forms.Button();
            this.buttonTagVor = new System.Windows.Forms.Button();
            this.buttonJetzt = new System.Windows.Forms.Button();
            this.buttonSpeichern = new System.Windows.Forms.Button();
            this.buttonUnterrichtHinzu = new System.Windows.Forms.Button();
            this.comboBoxKlasse = new System.Windows.Forms.ComboBox();
            this.comboBoxFach = new System.Windows.Forms.ComboBox();
            this.labelcbKlasseText = new System.Windows.Forms.Label();
            this.labelcbFachText = new System.Windows.Forms.Label();
            this.buttonSchuelerHinzu = new System.Windows.Forms.Button();
            this.panelUnterricht.SuspendLayout();
            this.panelLehrstoff.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSchueler
            // 
            this.panelSchueler.BackColor = System.Drawing.Color.Transparent;
            this.panelSchueler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSchueler.Location = new System.Drawing.Point(13, 220);
            this.panelSchueler.Name = "panelSchueler";
            this.panelSchueler.Size = new System.Drawing.Size(1178, 334);
            this.panelSchueler.TabIndex = 0;
            // 
            // labelSchueler
            // 
            this.labelSchueler.AutoSize = true;
            this.labelSchueler.Location = new System.Drawing.Point(10, 204);
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
            this.panelUnterricht.Location = new System.Drawing.Point(13, 95);
            this.panelUnterricht.Name = "panelUnterricht";
            this.panelUnterricht.Size = new System.Drawing.Size(1178, 97);
            this.panelUnterricht.TabIndex = 1;
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
            // labelLehrer
            // 
            this.labelLehrer.AutoSize = true;
            this.labelLehrer.Location = new System.Drawing.Point(50, 49);
            this.labelLehrer.Name = "labelLehrer";
            this.labelLehrer.Size = new System.Drawing.Size(10, 13);
            this.labelLehrer.TabIndex = 5;
            this.labelLehrer.Text = "-";
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
            this.labelUnterrichtText.Location = new System.Drawing.Point(10, 79);
            this.labelUnterrichtText.Name = "labelUnterrichtText";
            this.labelUnterrichtText.Size = new System.Drawing.Size(53, 13);
            this.labelUnterrichtText.TabIndex = 0;
            this.labelUnterrichtText.Text = "Unterricht";
            // 
            // panelLehrstoff
            // 
            this.panelLehrstoff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLehrstoff.Controls.Add(this.textBoxLehrstoff);
            this.panelLehrstoff.Location = new System.Drawing.Point(12, 591);
            this.panelLehrstoff.Name = "panelLehrstoff";
            this.panelLehrstoff.Size = new System.Drawing.Size(1179, 100);
            this.panelLehrstoff.TabIndex = 2;
            // 
            // textBoxLehrstoff
            // 
            this.textBoxLehrstoff.Location = new System.Drawing.Point(3, 3);
            this.textBoxLehrstoff.MaxLength = 100;
            this.textBoxLehrstoff.Multiline = true;
            this.textBoxLehrstoff.Name = "textBoxLehrstoff";
            this.textBoxLehrstoff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLehrstoff.Size = new System.Drawing.Size(1171, 92);
            this.textBoxLehrstoff.TabIndex = 1;
            // 
            // labelLehrstoffText
            // 
            this.labelLehrstoffText.AutoSize = true;
            this.labelLehrstoffText.Location = new System.Drawing.Point(9, 575);
            this.labelLehrstoffText.Name = "labelLehrstoffText";
            this.labelLehrstoffText.Size = new System.Drawing.Size(48, 13);
            this.labelLehrstoffText.TabIndex = 0;
            this.labelLehrstoffText.Text = "Lehrstoff";
            // 
            // comboBoxRaum
            // 
            this.comboBoxRaum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRaum.FormattingEnabled = true;
            this.comboBoxRaum.Location = new System.Drawing.Point(626, 33);
            this.comboBoxRaum.Name = "comboBoxRaum";
            this.comboBoxRaum.Size = new System.Drawing.Size(71, 21);
            this.comboBoxRaum.TabIndex = 3;
            // 
            // labelRaumText
            // 
            this.labelRaumText.AutoSize = true;
            this.labelRaumText.Location = new System.Drawing.Point(623, 17);
            this.labelRaumText.Name = "labelRaumText";
            this.labelRaumText.Size = new System.Drawing.Size(35, 13);
            this.labelRaumText.TabIndex = 4;
            this.labelRaumText.Text = "Raum";
            // 
            // comboBoxEinheit
            // 
            this.comboBoxEinheit.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.comboBoxEinheit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEinheit.FormattingEnabled = true;
            this.comboBoxEinheit.Location = new System.Drawing.Point(403, 33);
            this.comboBoxEinheit.Name = "comboBoxEinheit";
            this.comboBoxEinheit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxEinheit.TabIndex = 5;
            // 
            // labelEinheitText
            // 
            this.labelEinheitText.AutoSize = true;
            this.labelEinheitText.Location = new System.Drawing.Point(400, 17);
            this.labelEinheitText.Name = "labelEinheitText";
            this.labelEinheitText.Size = new System.Drawing.Size(74, 13);
            this.labelEinheitText.TabIndex = 6;
            this.labelEinheitText.Text = "Unterrichtszeit";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(44, 33);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker.TabIndex = 11;
            // 
            // buttonDatumHeute
            // 
            this.buttonDatumHeute.Location = new System.Drawing.Point(273, 33);
            this.buttonDatumHeute.Name = "buttonDatumHeute";
            this.buttonDatumHeute.Size = new System.Drawing.Size(45, 21);
            this.buttonDatumHeute.TabIndex = 12;
            this.buttonDatumHeute.Text = "Heute";
            this.buttonDatumHeute.UseVisualStyleBackColor = true;
            this.buttonDatumHeute.Click += new System.EventHandler(this.ButtonDatumHeute_Click);
            // 
            // buttonTagZurueck
            // 
            this.buttonTagZurueck.Location = new System.Drawing.Point(20, 33);
            this.buttonTagZurueck.Name = "buttonTagZurueck";
            this.buttonTagZurueck.Size = new System.Drawing.Size(20, 20);
            this.buttonTagZurueck.TabIndex = 13;
            this.buttonTagZurueck.Text = "<";
            this.buttonTagZurueck.UseVisualStyleBackColor = true;
            this.buttonTagZurueck.Click += new System.EventHandler(this.ButtonTagZurueck_Click);
            // 
            // buttonTagVor
            // 
            this.buttonTagVor.Location = new System.Drawing.Point(249, 33);
            this.buttonTagVor.Name = "buttonTagVor";
            this.buttonTagVor.Size = new System.Drawing.Size(20, 20);
            this.buttonTagVor.TabIndex = 14;
            this.buttonTagVor.Text = ">";
            this.buttonTagVor.UseVisualStyleBackColor = true;
            this.buttonTagVor.Click += new System.EventHandler(this.ButtonTagVor_Click);
            // 
            // buttonJetzt
            // 
            this.buttonJetzt.Location = new System.Drawing.Point(528, 33);
            this.buttonJetzt.Name = "buttonJetzt";
            this.buttonJetzt.Size = new System.Drawing.Size(45, 21);
            this.buttonJetzt.TabIndex = 15;
            this.buttonJetzt.Text = "Jetzt";
            this.buttonJetzt.UseVisualStyleBackColor = true;
            this.buttonJetzt.Click += new System.EventHandler(this.ButtonJetzt_Click);
            // 
            // buttonSpeichern
            // 
            this.buttonSpeichern.Location = new System.Drawing.Point(1116, 697);
            this.buttonSpeichern.Name = "buttonSpeichern";
            this.buttonSpeichern.Size = new System.Drawing.Size(75, 23);
            this.buttonSpeichern.TabIndex = 16;
            this.buttonSpeichern.Text = "Speichern";
            this.buttonSpeichern.UseVisualStyleBackColor = true;
            this.buttonSpeichern.Click += new System.EventHandler(this.ButtonSpeichern_Click);
            // 
            // buttonUnterrichtHinzu
            // 
            this.buttonUnterrichtHinzu.Location = new System.Drawing.Point(1013, 36);
            this.buttonUnterrichtHinzu.Name = "buttonUnterrichtHinzu";
            this.buttonUnterrichtHinzu.Size = new System.Drawing.Size(75, 21);
            this.buttonUnterrichtHinzu.TabIndex = 17;
            this.buttonUnterrichtHinzu.Text = "Hinzu";
            this.buttonUnterrichtHinzu.UseVisualStyleBackColor = true;
            this.buttonUnterrichtHinzu.Click += new System.EventHandler(this.ButtonUnterrichtHinzu_Click);
            // 
            // comboBoxKlasse
            // 
            this.comboBoxKlasse.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.comboBoxKlasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKlasse.FormattingEnabled = true;
            this.comboBoxKlasse.Location = new System.Drawing.Point(827, 37);
            this.comboBoxKlasse.Name = "comboBoxKlasse";
            this.comboBoxKlasse.Size = new System.Drawing.Size(88, 21);
            this.comboBoxKlasse.TabIndex = 18;
            // 
            // comboBoxFach
            // 
            this.comboBoxFach.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.comboBoxFach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFach.FormattingEnabled = true;
            this.comboBoxFach.Location = new System.Drawing.Point(921, 36);
            this.comboBoxFach.Name = "comboBoxFach";
            this.comboBoxFach.Size = new System.Drawing.Size(88, 21);
            this.comboBoxFach.TabIndex = 19;
            // 
            // labelcbKlasseText
            // 
            this.labelcbKlasseText.AutoSize = true;
            this.labelcbKlasseText.Location = new System.Drawing.Point(824, 21);
            this.labelcbKlasseText.Name = "labelcbKlasseText";
            this.labelcbKlasseText.Size = new System.Drawing.Size(38, 13);
            this.labelcbKlasseText.TabIndex = 20;
            this.labelcbKlasseText.Text = "Klasse";
            // 
            // labelcbFachText
            // 
            this.labelcbFachText.AutoSize = true;
            this.labelcbFachText.Location = new System.Drawing.Point(918, 20);
            this.labelcbFachText.Name = "labelcbFachText";
            this.labelcbFachText.Size = new System.Drawing.Size(31, 13);
            this.labelcbFachText.TabIndex = 21;
            this.labelcbFachText.Text = "Fach";
            // 
            // buttonSchuelerHinzu
            // 
            this.buttonSchuelerHinzu.Location = new System.Drawing.Point(1116, 37);
            this.buttonSchuelerHinzu.Name = "buttonSchuelerHinzu";
            this.buttonSchuelerHinzu.Size = new System.Drawing.Size(75, 21);
            this.buttonSchuelerHinzu.TabIndex = 22;
            this.buttonSchuelerHinzu.Text = "Schueler";
            this.buttonSchuelerHinzu.UseVisualStyleBackColor = true;
            this.buttonSchuelerHinzu.Click += new System.EventHandler(this.ButtonSchuelerHinzu_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 725);
            this.Controls.Add(this.buttonSchuelerHinzu);
            this.Controls.Add(this.labelcbFachText);
            this.Controls.Add(this.labelcbKlasseText);
            this.Controls.Add(this.comboBoxFach);
            this.Controls.Add(this.comboBoxKlasse);
            this.Controls.Add(this.buttonUnterrichtHinzu);
            this.Controls.Add(this.buttonSpeichern);
            this.Controls.Add(this.buttonJetzt);
            this.Controls.Add(this.buttonTagVor);
            this.Controls.Add(this.buttonTagZurueck);
            this.Controls.Add(this.buttonDatumHeute);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.labelSchueler);
            this.Controls.Add(this.labelLehrstoffText);
            this.Controls.Add(this.labelEinheitText);
            this.Controls.Add(this.labelUnterrichtText);
            this.Controls.Add(this.comboBoxEinheit);
            this.Controls.Add(this.labelRaumText);
            this.Controls.Add(this.comboBoxRaum);
            this.Controls.Add(this.panelLehrstoff);
            this.Controls.Add(this.panelUnterricht);
            this.Controls.Add(this.panelSchueler);
            this.Name = "Form1";
            this.Text = "Klassenbuch";
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
        private System.Windows.Forms.TextBox textBoxLehrstoff;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonDatumHeute;
        private System.Windows.Forms.Button buttonTagZurueck;
        private System.Windows.Forms.Button buttonTagVor;
        private System.Windows.Forms.Button buttonJetzt;
        private System.Windows.Forms.Button buttonSpeichern;
        private System.Windows.Forms.Button buttonUnterrichtHinzu;
        private System.Windows.Forms.ComboBox comboBoxKlasse;
        private System.Windows.Forms.ComboBox comboBoxFach;
        private System.Windows.Forms.Label labelcbKlasseText;
        private System.Windows.Forms.Label labelcbFachText;
        private System.Windows.Forms.Button buttonSchuelerHinzu;
    }
}

