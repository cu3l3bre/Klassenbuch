﻿namespace Klassenbuch
{
    partial class UserControlSchueler
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelVorname = new System.Windows.Forms.Label();
            this.pictureBoxBild = new System.Windows.Forms.PictureBox();
            this.checkBoxAnwesend = new System.Windows.Forms.CheckBox();
            this.textBoxGrund = new System.Windows.Forms.TextBox();
            this.labelNachname = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBild)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVorname
            // 
            this.labelVorname.AutoSize = true;
            this.labelVorname.Location = new System.Drawing.Point(67, 3);
            this.labelVorname.Name = "labelVorname";
            this.labelVorname.Size = new System.Drawing.Size(49, 13);
            this.labelVorname.TabIndex = 0;
            this.labelVorname.Text = "Vorname";
            // 
            // pictureBoxBild
            // 
            this.pictureBoxBild.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxBild.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBild.Location = new System.Drawing.Point(-1, -1);
            this.pictureBoxBild.Name = "pictureBoxBild";
            this.pictureBoxBild.Size = new System.Drawing.Size(65, 62);
            this.pictureBoxBild.TabIndex = 1;
            this.pictureBoxBild.TabStop = false;
            // 
            // checkBoxAnwesend
            // 
            this.checkBoxAnwesend.AutoSize = true;
            this.checkBoxAnwesend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAnwesend.Location = new System.Drawing.Point(70, 43);
            this.checkBoxAnwesend.MaximumSize = new System.Drawing.Size(30, 30);
            this.checkBoxAnwesend.Name = "checkBoxAnwesend";
            this.checkBoxAnwesend.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAnwesend.TabIndex = 2;
            this.checkBoxAnwesend.UseVisualStyleBackColor = true;
            // 
            // textBoxGrund
            // 
            this.textBoxGrund.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGrund.Location = new System.Drawing.Point(91, 37);
            this.textBoxGrund.Name = "textBoxGrund";
            this.textBoxGrund.Size = new System.Drawing.Size(214, 20);
            this.textBoxGrund.TabIndex = 3;
            // 
            // labelNachname
            // 
            this.labelNachname.AutoSize = true;
            this.labelNachname.Location = new System.Drawing.Point(67, 21);
            this.labelNachname.Name = "labelNachname";
            this.labelNachname.Size = new System.Drawing.Size(59, 13);
            this.labelNachname.TabIndex = 4;
            this.labelNachname.Text = "Nachname";
            // 
            // UserControlSchueler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelNachname);
            this.Controls.Add(this.textBoxGrund);
            this.Controls.Add(this.checkBoxAnwesend);
            this.Controls.Add(this.pictureBoxBild);
            this.Controls.Add(this.labelVorname);
            this.Name = "UserControlSchueler";
            this.Size = new System.Drawing.Size(310, 60);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBild)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVorname;
        private System.Windows.Forms.PictureBox pictureBoxBild;
        private System.Windows.Forms.CheckBox checkBoxAnwesend;
        private System.Windows.Forms.TextBox textBoxGrund;
        private System.Windows.Forms.Label labelNachname;
    }
}