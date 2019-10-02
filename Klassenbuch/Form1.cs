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

    public partial class Form1 : Form
    {

        private UserControlSchueler[] schueler;
        


        public Form1()
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

            bereinigeUI();
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

                //panelSchueler.Controls.Clear();

                //labelFach.Text = "-";
                //labelLehrer.Text = "-";
                //labelKlasse.Text = "-";

                bereinigeUI();


                if (dtUnterrichtInfo != null && dtUnterrichtInfo.Rows.Count > 0)
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
                string kommentar = dt.Rows[i].ItemArray[11].ToString();
                //bool anwesend =

                bool.TryParse(dt.Rows[i].ItemArray[12].ToString(), out bool anwesend);

                int.TryParse(dt.Rows[i].ItemArray[9].ToString(), out int X);
                int.TryParse(dt.Rows[i].ItemArray[10].ToString(), out int Y);
                Point ucLocation = new Point(X, Y);


                string bildname = vorname + nachname + ".jpg";

                string pathToImage = Path.GetFullPath(Path.Combine(
                Application.StartupPath, @"..\..", "Bilder", bildname));

                
                schueler[i] = new UserControlSchueler(vorname, nachname, pathToImage, kommentar, anwesend);               

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
            for(int i = 0; i < comboBoxEinheit.Items.Count; i++)
            {

                string[] einheitBeginnEnde = comboBoxEinheit.Items[i].ToString().Split('-');
                string einheitBeginn = einheitBeginnEnde[0].Trim();
                string einheitEnde = einheitBeginnEnde[1].Trim();

                TimeSpan zeitJetzt = DateTime.Now.TimeOfDay;

                TimeSpan.TryParse(einheitBeginn, out TimeSpan zeitBeginn);
                TimeSpan.TryParse(einheitEnde, out TimeSpan zeitEnde);
                //TimeSpan zeitBeginn = DateTime.Parse(einheitBeginn).TimeOfDay;
                //TimeSpan zeitEnde = DateTime.Parse(einheitEnde).TimeOfDay;


                if (zeitBeginn < zeitJetzt &&  zeitEnde > zeitJetzt)
                {
                    comboBoxEinheit.Text = comboBoxEinheit.Items[i].ToString();
                    break;
                }
                //else if(zeitJetzt < zeitBeginn)
                //{
                //    comboBoxEinheit.Text = comboBoxEinheit.Items[0].ToString();
                //}
                //else
                //{
                //    comboBoxEinheit.Text = comboBoxEinheit.Items[comboBoxEinheit.Items.Count-1].ToString();
                //}
            }
        }


        private void bereinigeUI()
        {

            panelSchueler.Controls.Clear();

            labelFach.Text = "-";
            labelLehrer.Text = "-";
            labelKlasse.Text = "-";

        }

        private void ButtonSpeichern_Click(object sender, EventArgs e)
        {

            string datum = dateTimePicker.Value.ToString("yyyy-MM-dd");

            string[] einheitBeginnEnde = comboBoxEinheit.Text.Split('-');
            string einheitBeginn = einheitBeginnEnde[0].Trim();

            for (int i = 0; i < panelSchueler.Controls.Count; i++)
            {
                UserControlSchueler schueler = panelSchueler.Controls[i] as UserControlSchueler;
                
                DbAccessViaSQL.UpdateUnterricht(
                    schueler.Kommentar,
                    schueler.Anwesend,
                    schueler.Vorname,
                    schueler.Nachname,
                    datum,
                    einheitBeginn,
                    comboBoxRaum.Text);
            }
        }

    }
}
