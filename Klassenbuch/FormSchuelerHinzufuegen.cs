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
            if (string.IsNullOrEmpty(textBoxVorname.Text) || string.IsNullOrEmpty(textBoxNachname.Text))
            {
                return;
            }

            Debug.WriteLine(dateiName);

            string pfadZumOrdner = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder"));
            string bildName = textBoxVorname.Text.Trim() + textBoxNachname.Text.Trim() + ".jpg";
            string pfadZumBild = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder", bildName));


            if(System.IO.Directory.Exists(pfadZumOrdner))
            {
                if(System.IO.File.Exists(dateiName))
                {

                    if (!System.IO.File.Exists(pfadZumBild))
                    {
                        System.IO.File.Copy(dateiName, pfadZumBild, true);
                        // Hier die sql dinger rein
                        // Insert Person
                        // Get ID von Person mit Namen
                        // Insert Schueler mit PErson ID und Klase ID

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
