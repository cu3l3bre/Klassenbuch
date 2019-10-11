using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Klassenbuch.DbAccess;


namespace Klassenbuch
{
    public partial class FormSchuelerHinzufuegen : Form
    {
        private string dateiName;

        public FormSchuelerHinzufuegen()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dateiName = "";

            // Den Desktop als Initalpfad setzten
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "JPG-Dateien (*.jpg)|*.jpg";


            // Hole die Klassen die in der DB existieren und füge diese zur Combobox hinzu
            DataTable dtKlassen = DbAccessViaSQL.GetKlassen();
            comboBoxKlasse.DataSource = dtKlassen;
            comboBoxKlasse.DisplayMember = dtKlassen.Columns[1].ColumnName;
            comboBoxKlasse.ValueMember = dtKlassen.Columns[0].ColumnName;
        }


        //**************************************************//
        //  Event Handler                                   //
        //**************************************************//

        private void ButtonFileDialog_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            dateiName = openFileDialog.FileName;
            pictureBoxBild.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBild.Load(dateiName);
        }


        private void ButtonSpeichern_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxVorname.Text)
                || string.IsNullOrWhiteSpace(textBoxVorname.Text)
                || string.IsNullOrEmpty(textBoxNachname.Text)
                || string.IsNullOrWhiteSpace(textBoxNachname.Text)
                || string.IsNullOrEmpty(dateiName))
            {
                MessageBox.Show("Bild nicht geladen oder Name ungueltig!");
            }
            else
            {
                string vorname = textBoxVorname.Text.Trim();
                string nachname = textBoxNachname.Text.Trim();

                string bildName = vorname + nachname + ".jpg";
                string pfadZumBildOrdner = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder"));
                string pfadZumBild = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder", bildName));


                if (Directory.Exists(pfadZumBildOrdner))
                {
                    if (File.Exists(dateiName))
                    {
                        if (!File.Exists(pfadZumBild))
                        {
                            // Füge den Schüler zunächst als neue Person zur Db hinzu
                            if (DbAccessViaSQL.InsertPerson(vorname, nachname))
                            {
                                long personId = 0;

                                // Hole die PersonenID vom neu angelegten Schüler
                                DataTable dtPersonID = DbAccessViaSQL.GetPersonID(vorname, nachname);
                                for (int i = 0; i < dtPersonID.Rows.Count; i++)
                                {
                                    personId = (long)(dtPersonID.Rows[i][0]);
                                }

                                // Die ID der Klasse, je nach Auswahl in der Combobox, in die der Schüler kommen soll
                                long klasseId = (long)comboBoxKlasse.SelectedValue;


                                // Den neuen Schüler zur Db hinzufuegen
                                if (DbAccessViaSQL.InsertSchueler(personId, klasseId))
                                {
                                    // Kopiere das Bild in den Bildordner, wo alle Schueler gespeichert sind
                                    File.Copy(dateiName, pfadZumBild, true);
                                }
                                else
                                {
                                    MessageBox.Show("Fehler beim Eintragen des neuen Schülers in die Schüler-Tabelle der Datenbank");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Fehler beim Eintragen des neuen Schülers in die Person-Tabelle der Datenbank");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Es existiert bereits ein Bild mit diesem Namen!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zu kopierende Datei existiert nicht!");
                    }
                }
                else
                {
                    MessageBox.Show("Order in dem kopiert werden soll existiert nicht!");
                }
            }
        }


        private void ButtonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
