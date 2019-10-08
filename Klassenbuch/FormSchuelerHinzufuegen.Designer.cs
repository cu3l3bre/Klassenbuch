namespace Klassenbuch
{
    partial class FormSchuelerHinzufuegen
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
            this.comboBoxKlasse = new System.Windows.Forms.ComboBox();
            this.textBoxNachname = new System.Windows.Forms.TextBox();
            this.textBoxVorname = new System.Windows.Forms.TextBox();
            this.buttonSpeichern = new System.Windows.Forms.Button();
            this.buttonAbbrechen = new System.Windows.Forms.Button();
            this.pictureBoxBild = new System.Windows.Forms.PictureBox();
            this.labelVornameText = new System.Windows.Forms.Label();
            this.labelNachnameText = new System.Windows.Forms.Label();
            this.labelKlasseText = new System.Windows.Forms.Label();
            this.panelBild = new System.Windows.Forms.Panel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonFileDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBild)).BeginInit();
            this.panelBild.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxKlasse
            // 
            this.comboBoxKlasse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKlasse.FormattingEnabled = true;
            this.comboBoxKlasse.Location = new System.Drawing.Point(85, 297);
            this.comboBoxKlasse.Name = "comboBoxKlasse";
            this.comboBoxKlasse.Size = new System.Drawing.Size(161, 21);
            this.comboBoxKlasse.TabIndex = 3;
            // 
            // textBoxNachname
            // 
            this.textBoxNachname.Location = new System.Drawing.Point(85, 271);
            this.textBoxNachname.Name = "textBoxNachname";
            this.textBoxNachname.Size = new System.Drawing.Size(161, 20);
            this.textBoxNachname.TabIndex = 2;
            // 
            // textBoxVorname
            // 
            this.textBoxVorname.Location = new System.Drawing.Point(85, 245);
            this.textBoxVorname.Name = "textBoxVorname";
            this.textBoxVorname.Size = new System.Drawing.Size(161, 20);
            this.textBoxVorname.TabIndex = 1;
            // 
            // buttonSpeichern
            // 
            this.buttonSpeichern.Location = new System.Drawing.Point(248, 415);
            this.buttonSpeichern.Name = "buttonSpeichern";
            this.buttonSpeichern.Size = new System.Drawing.Size(75, 23);
            this.buttonSpeichern.TabIndex = 5;
            this.buttonSpeichern.Text = "Speichern";
            this.buttonSpeichern.UseVisualStyleBackColor = true;
            this.buttonSpeichern.Click += new System.EventHandler(this.ButtonSpeichern_Click);
            // 
            // buttonAbbrechen
            // 
            this.buttonAbbrechen.Location = new System.Drawing.Point(13, 415);
            this.buttonAbbrechen.Name = "buttonAbbrechen";
            this.buttonAbbrechen.Size = new System.Drawing.Size(75, 23);
            this.buttonAbbrechen.TabIndex = 4;
            this.buttonAbbrechen.Text = "Abbrechen";
            this.buttonAbbrechen.UseVisualStyleBackColor = true;
            this.buttonAbbrechen.Click += new System.EventHandler(this.ButtonAbbrechen_Click);
            // 
            // pictureBoxBild
            // 
            this.pictureBoxBild.Location = new System.Drawing.Point(6, 5);
            this.pictureBoxBild.Name = "pictureBoxBild";
            this.pictureBoxBild.Size = new System.Drawing.Size(149, 129);
            this.pictureBoxBild.TabIndex = 5;
            this.pictureBoxBild.TabStop = false;
            // 
            // labelVornameText
            // 
            this.labelVornameText.AutoSize = true;
            this.labelVornameText.Location = new System.Drawing.Point(30, 252);
            this.labelVornameText.Name = "labelVornameText";
            this.labelVornameText.Size = new System.Drawing.Size(49, 13);
            this.labelVornameText.TabIndex = 6;
            this.labelVornameText.Text = "Vorname";
            this.labelVornameText.UseMnemonic = false;
            // 
            // labelNachnameText
            // 
            this.labelNachnameText.AutoSize = true;
            this.labelNachnameText.Location = new System.Drawing.Point(20, 278);
            this.labelNachnameText.Name = "labelNachnameText";
            this.labelNachnameText.Size = new System.Drawing.Size(59, 13);
            this.labelNachnameText.TabIndex = 7;
            this.labelNachnameText.Text = "Nachname";
            // 
            // labelKlasseText
            // 
            this.labelKlasseText.AutoSize = true;
            this.labelKlasseText.Location = new System.Drawing.Point(41, 305);
            this.labelKlasseText.Name = "labelKlasseText";
            this.labelKlasseText.Size = new System.Drawing.Size(38, 13);
            this.labelKlasseText.TabIndex = 8;
            this.labelKlasseText.Text = "Klasse";
            // 
            // panelBild
            // 
            this.panelBild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBild.Controls.Add(this.pictureBoxBild);
            this.panelBild.Location = new System.Drawing.Point(85, 30);
            this.panelBild.Name = "panelBild";
            this.panelBild.Size = new System.Drawing.Size(161, 139);
            this.panelBild.TabIndex = 9;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // buttonFileDialog
            // 
            this.buttonFileDialog.Location = new System.Drawing.Point(85, 175);
            this.buttonFileDialog.Name = "buttonFileDialog";
            this.buttonFileDialog.Size = new System.Drawing.Size(161, 23);
            this.buttonFileDialog.TabIndex = 0;
            this.buttonFileDialog.Text = "Lade Bild";
            this.buttonFileDialog.UseVisualStyleBackColor = true;
            this.buttonFileDialog.Click += new System.EventHandler(this.ButtonFileDialog_Click);
            // 
            // FormSchuelerHinzufuegen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 450);
            this.Controls.Add(this.buttonFileDialog);
            this.Controls.Add(this.panelBild);
            this.Controls.Add(this.labelKlasseText);
            this.Controls.Add(this.labelNachnameText);
            this.Controls.Add(this.labelVornameText);
            this.Controls.Add(this.buttonAbbrechen);
            this.Controls.Add(this.buttonSpeichern);
            this.Controls.Add(this.textBoxVorname);
            this.Controls.Add(this.textBoxNachname);
            this.Controls.Add(this.comboBoxKlasse);
            this.Name = "FormSchuelerHinzufuegen";
            this.Text = "Schueler hinzufuegen";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBild)).EndInit();
            this.panelBild.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxKlasse;
        private System.Windows.Forms.TextBox textBoxNachname;
        private System.Windows.Forms.TextBox textBoxVorname;
        private System.Windows.Forms.Button buttonSpeichern;
        private System.Windows.Forms.Button buttonAbbrechen;
        private System.Windows.Forms.PictureBox pictureBoxBild;
        private System.Windows.Forms.Label labelVornameText;
        private System.Windows.Forms.Label labelNachnameText;
        private System.Windows.Forms.Label labelKlasseText;
        private System.Windows.Forms.Panel panelBild;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonFileDialog;
    }
}