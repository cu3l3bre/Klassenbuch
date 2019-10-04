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
        private UserControlSchueler aktivesUsercontrol;
        private Point vorherigeUserControlPos;


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
                comboBoxRaum.Items.Add(dtRaumInfo.Rows[i][0]);
            }

            // Hole die Unterrichtseinheiten (Zeiten von bis) die in der DB existieren und adde diese als Einträge zur Combobox
            DataTable dtEinheitInfo = DbAccessViaSQL.GetEinheiten();
            for (int i = 0; i < dtEinheitInfo.Rows.Count; i++)
            {
                comboBoxEinheit.Items.Add(dtEinheitInfo.Rows[i][0].ToString() + " - "
                   + dtEinheitInfo.Rows[i][1].ToString());
            }

            bereinigeUI();
        }


        private void aktualisiereDaten_TextChanged(object sender, EventArgs e)
        {

            string einheitBeginn = "";
            string einheitEnde = "";

            if (!string.IsNullOrEmpty(comboBoxEinheit.Text) && !string.IsNullOrEmpty(comboBoxRaum.Text))
            {
                // Datums string für SQL Abfrage
                string datum =
                    dateTimePicker.Value.Year.ToString() + '-' +
                    dateTimePicker.Value.Month.ToString() + '-' +
                    dateTimePicker.Value.Day.ToString();


                string[] einheitBeginnEnde = comboBoxEinheit.Text.Split('-');
                einheitBeginn = einheitBeginnEnde[0].Trim();
                einheitEnde = einheitBeginnEnde[1].Trim();

                DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(comboBoxRaum.Text, einheitBeginn, datum);

                bereinigeUI();


                if (dtUnterrichtInfo != null && dtUnterrichtInfo.Rows.Count > 0)
                {
                    aktualisiereDaten(dtUnterrichtInfo);
                }
            }
        }


        private void aktualisiereDaten(DataTable dt)
        {

            labelFach.Text = (string)dt.Rows[0][3];
            labelLehrer.Text = (string)dt.Rows[0][5];
            labelKlasse.Text = (string)dt.Rows[0][6];
            textBoxLehrstoff.Text = (string)dt.Rows[0][13];




            int anzahlSchueler = dt.Rows.Count;
            schueler = new UserControlSchueler[anzahlSchueler];

            for (int i = 0; i < schueler.Length; i++)
            {

                string vorname = (string)dt.Rows[i][7];
                string nachname = (string)dt.Rows[i][8];
                string kommentar = (string)dt.Rows[i][11];


                CheckState anwesend = CheckState.Indeterminate;

                if (dt.Rows[i][12] == DBNull.Value)
                {
                    anwesend = CheckState.Indeterminate;
                }
                else if ((bool)dt.Rows[i][12] == true)
                {
                    anwesend = CheckState.Checked;
                }
                else if ((bool)dt.Rows[i][12] == false)
                {
                    anwesend = CheckState.Unchecked;
                }


                Point ucLocation = new Point((int)dt.Rows[i][9], (int)dt.Rows[i][10]);

                string bildname = vorname + nachname + ".jpg";

                string pathToImage = Path.GetFullPath(Path.Combine(
                Application.StartupPath, @"..\..", "Bilder", bildname));

                schueler[i] = new UserControlSchueler(vorname, nachname, pathToImage, kommentar, anwesend);

                // Event Handler registrieren
                schueler[i].MouseDown += usercontrol_MouseDown;
                schueler[i].MouseMove += usercontrol_MouseMove;
                schueler[i].MouseUp += usercontrol_MouseUp;


                foreach (Control ctrl in schueler[i].Controls)
                {
                    if (ctrl.GetType() == typeof(CheckBox))
                    {
                        CheckBox cb = ctrl as CheckBox;
                        cb.Click += usercontrol_CheckBox_Click;
                    }
                }

                schueler[i].Location = ucLocation;
                panelSchueler.Controls.Add(schueler[i]);

            }

        }

        private void usercontrol_CheckBox_Click(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.CheckState == CheckState.Checked)
            {
                cb.Parent.BackColor = Color.Green;
            }
            else if (cb.CheckState == CheckState.Unchecked)
            {
                cb.Parent.BackColor = Color.Red;
            }
        }



        // https://stackoverflow.com/questions/3868941/how-to-allow-user-to-drag-a-dynamically-created-control-at-the-location-of-his-c

        private void usercontrol_MouseDown(object sender, MouseEventArgs e)
        {
            aktivesUsercontrol = sender as UserControlSchueler;
            vorherigeUserControlPos = e.Location;
            Cursor = Cursors.Hand;
        }

        private void usercontrol_MouseMove(object sender, MouseEventArgs e)
        {

            if(aktivesUsercontrol == null || aktivesUsercontrol != sender)
            {
                return;
            }

            Point location = aktivesUsercontrol.Location;
            location.Offset(e.Location.X - vorherigeUserControlPos.X, e.Location.Y - vorherigeUserControlPos.Y);

            // Bewegen des Usercontrols auf das Panel begrenzen, sonst fliegts aus der Anwendung
            if (location.X < 0)
            {
                location.X = 0;
            }

            if (location.Y < 0)
            {
                location.Y = 0;
            }

            if(location.X > (panelSchueler.Size.Width-aktivesUsercontrol.Size.Width))
            {
                location.X = panelSchueler.Size.Width - aktivesUsercontrol.Size.Width;
            }

            if (location.Y > (panelSchueler.Size.Height - aktivesUsercontrol.Size.Height))
            {
                location.Y = panelSchueler.Size.Height - aktivesUsercontrol.Size.Height;
            }

            aktivesUsercontrol.Location = location;
        }


        private void usercontrol_MouseUp(object sender, MouseEventArgs e)
        {
            aktivesUsercontrol = null;
            Cursor = Cursors.Default;
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
            }
        }


        private void bereinigeUI()
        {
            panelSchueler.Controls.Clear();

            labelFach.Text = "-";
            labelLehrer.Text = "-";
            labelKlasse.Text = "-";
            textBoxLehrstoff.Text = "";
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
                    comboBoxRaum.Text,
                    schueler.Location.X,
                    schueler.Location.Y,
                    textBoxLehrstoff.Text);


                foreach (Control ctrl in schueler.Controls)
                {
                    if (ctrl.GetType() == typeof(CheckBox))
                    {
                        CheckBox cb = ctrl as CheckBox;
            
                        if (cb.CheckState == CheckState.Checked)
                        {
                            cb.Parent.BackColor = Color.LightGreen;
                        }
                        else if (cb.CheckState == CheckState.Unchecked)
                        {
                            cb.Parent.BackColor = Color.PeachPuff;
                        }
                    }
                }
            }
        }
    }
}
