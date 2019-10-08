using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Klassenbuch.DbAccess;
using System.IO;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Klassenbuch
{
    public partial class FormSchuelerHinzufuegen : Form
    {

        private string dateiName;
        //private string pathToImage;

        public FormSchuelerHinzufuegen()
        {
            InitializeComponent();
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            dateiName = "";

            // Initalpfad setzten, hier mal auf den Desktop

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "JPG-Dateien (*.jpg)|*.jpg";





            // Hole die Räume die in der DB existieren und adde diese als Einträge zur Combobox
            DataTable dtKlassen = DbAccessViaSQL.GetKlassen();


            comboBoxKlasse.DataSource = dtKlassen;
            comboBoxKlasse.DisplayMember = dtKlassen.Columns[1].ColumnName;
            comboBoxKlasse.ValueMember = dtKlassen.Columns[0].ColumnName;



            //for (int i = 0; i < dtRaumInfo.Rows.Count; i++)
            //{
            //    comboBoxRaum.Items.Add(dtRaumInfo.Rows[i][0]);
            //}



            // Event Handler erst registrieren, nachdem die Datenbindung der Comboboxen statt gefunden haben
            //dateTimePicker.ValueChanged += aktualisiereDaten_Changed;
            //comboBoxRaum.SelectedIndexChanged += aktualisiereDaten_Changed;
            //comboBoxEinheit.SelectedIndexChanged += aktualisiereDaten_Changed;

        }







        private void ButtonAbbrechen_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonSpeichern_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("Daqteiname " + dateiName);


            if (string.IsNullOrEmpty(textBoxVorname.Text)
                || string.IsNullOrWhiteSpace(textBoxVorname.Text)
                || string.IsNullOrEmpty(textBoxNachname.Text)
                || string.IsNullOrWhiteSpace(textBoxNachname.Text)
                || string.IsNullOrEmpty(dateiName))
            {
                MessageBox.Show("Bild nicht geladen oder Name ungueltig");
            }
            else
            {



                Debug.WriteLine(dateiName);

                string vorname = textBoxVorname.Text.Trim();
                string nachname = textBoxNachname.Text.Trim();

                string pfadZumOrdner = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder"));
                string bildName = vorname + nachname + ".jpg";
                string pfadZumBild = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder", bildName));


                if (System.IO.Directory.Exists(pfadZumOrdner))
                {
                    if (System.IO.File.Exists(dateiName))
                    {

                        if (!System.IO.File.Exists(pfadZumBild))
                        {
                            // Insert Schüler zunächst als neue Person
                            DbAccessViaSQL.InsertPerson(vorname, nachname);

                            long personId = 0;

                            // Hole die PersonenID vom neuen Schüler
                            DataTable dtPersonID = DbAccessViaSQL.GetPersonID(vorname, nachname);
                            for (int i = 0; i < dtPersonID.Rows.Count; i++)
                            {
                                //comboBoxRaum.Items.Add(dtPersonID.Rows[i][0]);
                                // Debug.WriteLine(dtPersonID.Rows[i][0].ToString());
                                personId = (long)(dtPersonID.Rows[i][0]);
                            }

                            // Die ID der Klasse, in die der Schüler kommt
                            long klasseId = (long)comboBoxKlasse.SelectedValue;

                            
                            // Neuen Schüler anlegen mit der Klasse
                            DbAccessViaSQL.InsertSchueler(personId, klasseId);


                            // Kopiere Bild in den Bildordner, wo alle Schueler "liegen"
                            System.IO.File.Copy(dateiName, pfadZumBild, true);

                        }
                        else
                        {
                            MessageBox.Show("Es existiert bereits ein Bild mit diesem Namen");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Zu kopierende Datei existiert nicht");
                    }
                }
                else
                {
                    MessageBox.Show("Order in dem kopiert werden soll existiert nicht");
                }
            }

  

        }


        private void ButtonFileDialog_Click(object sender, EventArgs e)
        {

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }


            dateiName = openFileDialog.FileName;

            pictureBoxBild.Load(dateiName);
            pictureBoxBild.SizeMode = PictureBoxSizeMode.StretchImage;


            

        }
    }
}
