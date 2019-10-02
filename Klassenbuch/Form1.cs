using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Klassenbuch.DbAccess;


namespace Klassenbuch
{

    public partial class FormMain : Form
    {

        private UserControlSchueler[] schueler;
        


        public FormMain()
        {
            InitializeComponent();
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Hole die Räume die in der DB existieren und adde diese als Einträge zur Combobox
            DataTable dtRaumInfo = DbAccessViaSQL.GetRaeume();
            for (int i = 0; i < dtRaumInfo.Rows.Count; i++)
            {
               comboBoxRaum.Items.Add(dtRaumInfo.Rows[i].ItemArray[0].ToString());
            }

            // Hole die Unterrichtseinheiten (Zeiten von bis) die in der DB existieren und adde diese als Einträge zur Combobox
            DataTable dtEinheitInfo = DbAccessViaSQL.GetEinheiten();
            for (int i = 0; i < dtEinheitInfo.Rows.Count; i++)
            {
                comboBoxEinheit.Items.Add(dtEinheitInfo.Rows[i].ItemArray[0].ToString() + " - "
                    + dtEinheitInfo.Rows[i].ItemArray[1].ToString());
            }

        }


        private void aktualisiereDaten_TextChanged(object sender, EventArgs e)
        {

            string einheitBeginn = "";
            string einheitEnde = "";

            if (!string.IsNullOrEmpty(comboBoxEinheit.Text) && !string.IsNullOrEmpty(comboBoxRaum.Text))
            {

                string datum =
                    dateTimePicker.Value.Year.ToString() + '-' +
                    dateTimePicker.Value.Month.ToString() + '-' +
                    dateTimePicker.Value.Day.ToString();

                //Debug.WriteLine(datum);

                string[] einheitBeginnEnde = comboBoxEinheit.Text.Split('-');
                einheitBeginn = einheitBeginnEnde[0].Trim();
                einheitEnde = einheitBeginnEnde[1].Trim();

                DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(comboBoxRaum.Text, einheitBeginn, datum);

                panelSchueler.Controls.Clear();

                if(dtUnterrichtInfo.Rows.Count > 0)
                {
                    aktualisiereDaten(dtUnterrichtInfo);
                }
            }
        }


        private void aktualisiereDaten(DataTable dt)
        {

            labelFach.Text = dt.Rows[0].ItemArray[3].ToString();
            labelLehrer.Text = dt.Rows[0].ItemArray[5].ToString();
            labelKlasse.Text = dt.Rows[0].ItemArray[6].ToString();

            int anzahlSchueler = dt.Rows.Count;
            schueler = new UserControlSchueler[anzahlSchueler];

            for (int i = 0; i < schueler.Length; i++)
            {

                string vorname = dt.Rows[i].ItemArray[7].ToString();
                string nachname = dt.Rows[i].ItemArray[8].ToString();

                int.TryParse(dt.Rows[i].ItemArray[9].ToString(), out int X);
                int.TryParse(dt.Rows[i].ItemArray[10].ToString(), out int Y);
                Point ucLocation = new Point(X, Y);


                string bildname = vorname + nachname + ".jpg";

                string pathToImage = Path.GetFullPath(Path.Combine(
                Application.StartupPath, @"..\..", "Bilder", bildname));

                
                schueler[i] = new UserControlSchueler(vorname, nachname, pathToImage);               

                schueler[i].Location = ucLocation;
                panelSchueler.Controls.Add(schueler[i]);

            }

        }

        private void ButtonDatumHeute_Click(object sender, EventArgs e)
        {
            dateTimePicker.Value = DateTime.Now;
        }

        private void ButtonTagVor_Click(object sender, EventArgs e)
        {
            DateTime datum = dateTimePicker.Value;
            dateTimePicker.Value = datum.AddDays(1);
        }

        private void ButtonTagZurueck_Click(object sender, EventArgs e)
        {
            DateTime datum = dateTimePicker.Value;
            dateTimePicker.Value = datum.AddDays(-1);
        }

        private void ButtonJetzt_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
            string aktuelleZeit = DateTime.Now.ToString("HH:mm:ss");

            Debug.WriteLine(comboBoxEinheit.Items.Count);





            for(int i = 0; i < comboBoxEinheit.Items.Count; i++)
            {

                string[] einheitBeginnEnde = comboBoxEinheit.Items[i].ToString().Split('-');
                string einheitBeginn = einheitBeginnEnde[0].Trim();
                string einheitEnde = einheitBeginnEnde[1].Trim();


                //if(aktuelleZeit < einheitBeginn)
                //{

                //}
                

            }

         
            comboBoxEinheit.Text = comboBoxEinheit.Items[5].ToString();


        }
    }
}
