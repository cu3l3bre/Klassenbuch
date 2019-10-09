using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Klassenbuch.DbAccess;

/*
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
*/


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

            // Hole die Räume die in der Db existieren füge diese zur Combobox hinzu
            DataTable dtRaumInfo = DbAccessViaSQL.GetRaeume();          
            comboBoxRaum.DataSource = dtRaumInfo;
            comboBoxRaum.DisplayMember = dtRaumInfo.Columns[1].ColumnName;
            comboBoxRaum.ValueMember = dtRaumInfo.Columns[0].ColumnName;


            // Hole die Unterrichtseinheiten (Zeiten von bis) die in der Db existieren füge diese zur Combobox hinzu
            DataTable dtEinheitInfo = DbAccessViaSQL.GetEinheiten();
            comboBoxEinheit.DataSource = dtEinheitInfo;
            comboBoxEinheit.DisplayMember = dtEinheitInfo.Columns[1].ColumnName;
            comboBoxEinheit.ValueMember = dtEinheitInfo.Columns[0].ColumnName;


            // Registrierung von Event Handlern (erst nachdem die Datenbindung der Comboboxen statt gefunden hat)
            dateTimePicker.ValueChanged += aktualisiereDaten_Changed;
            comboBoxRaum.SelectedIndexChanged += aktualisiereDaten_Changed;
            comboBoxEinheit.SelectedIndexChanged += aktualisiereDaten_Changed;

            // Setzte die aktuelle Unterrichtseinheit
            buttonJetzt.PerformClick();

            //bereinigeUI();
            holeDatenUndAktualisiere();
        }



        //**************************************************//
        //  Event Handler                                   //
        //**************************************************//

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
            if (comboBoxEinheit.Items.Count > 0)
            {
                foreach (DataRowView item in comboBoxEinheit.Items)
                {
                    long id = (long)item.Row[0];
                    string zeit = item.Row[1].ToString();

                    string[] einheitBeginnEnde = zeit.ToString().Split('-');
                    string einheitBeginn = einheitBeginnEnde[0].Trim();
                    string einheitEnde = einheitBeginnEnde[1].Trim();

                    TimeSpan zeitJetzt = DateTime.Now.TimeOfDay;
                    TimeSpan.TryParse(einheitBeginn, out TimeSpan zeitBeginn);
                    TimeSpan.TryParse(einheitEnde, out TimeSpan zeitEnde);

                    if (zeitBeginn < zeitJetzt && zeitEnde > zeitJetzt)
                    {
                        comboBoxEinheit.SelectedValue = id;
                        break;
                    }
                }
            }
        }


        private void aktualisiereDaten_Changed(object sender, EventArgs e)
        {

            holeDatenUndAktualisiere();

#if false         
            //long einheitId = -1;

            if (!string.IsNullOrEmpty(comboBoxEinheit.Text) && !string.IsNullOrEmpty(comboBoxRaum.Text))
            {
                // Datums string für SQL Abfrage
                string datum = getDatum();
                    //dateTimePicker.Value.Year.ToString() + '-' +
                    //dateTimePicker.Value.Month.ToString() + '-' +
                    //dateTimePicker.Value.Day.ToString();


                string[] einheitBeginnEnde = comboBoxEinheit.Text.Split('-');

                long einheitId = (long)comboBoxEinheit.SelectedValue;
                long raumId = (long)comboBoxRaum.SelectedValue;

               // DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(comboBoxRaum.Text, einheitId, datum);
                DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(raumId, einheitId, datum);

                bereinigeUI();


                buttonUnterrichtHinzu.Enabled = true;

                // Hole die untaetigen Klassen, die in der DB existieren und adde diese als Einträge zur Combobox
                DataTable dtUntaetigeKlassen = DbAccessViaSQL.GetUntaetigeKlassen(datum, einheitId);

                
                comboBoxKlasse.DataSource = dtUntaetigeKlassen;
                comboBoxKlasse.DisplayMember = dtUntaetigeKlassen.Columns[1].ColumnName;
                comboBoxKlasse.ValueMember = dtUntaetigeKlassen.Columns[0].ColumnName;
                
                /*
                comboBoxKlasse.Items.Clear();
                for (int i = 0; i < dtUntaetigeKlassen.Rows.Count; i++)
                {
                    comboBoxKlasse.Items.Add(dtUntaetigeKlassen.Rows[i][0].ToString());
                }
                */



                // Hole die untaetigen Faecher, die in der DB existieren und adde diese als Einträge zur Combobox
                DataTable dtUntaetigeFaecher = DbAccessViaSQL.GetUntaetigeFaecher(datum, einheitId);

                comboBoxFach.DataSource = dtUntaetigeFaecher;
                comboBoxFach.DisplayMember = dtUntaetigeFaecher.Columns[1].ColumnName;
                comboBoxFach.ValueMember = dtUntaetigeFaecher.Columns[0].ColumnName;
/*
                comboBoxFach.Items.Clear();
                for (int i = 0; i < dtUntaetigeFaecher.Rows.Count; i++)
                {
                    comboBoxFach.Items.Add(dtUntaetigeFaecher.Rows[i][0].ToString());
                }
                */



                if (dtUnterrichtInfo != null && dtUnterrichtInfo.Rows.Count > 0)
                {
                    aktualisiereDaten(dtUnterrichtInfo);
                    buttonUnterrichtHinzu.Enabled = false;
                }
            }

#endif

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

            if (aktivesUsercontrol == null || aktivesUsercontrol != sender)
            {
                return;
            }

            Point location = aktivesUsercontrol.Location;
            location.Offset(e.Location.X - vorherigeUserControlPos.X, e.Location.Y - vorherigeUserControlPos.Y);

            // Bewegen des Usercontrols auf das Panel begrenzen, sonst lässt sich das aus der Anwendung schieben
            if (location.X < 0)
            {
                location.X = 0;
            }

            if (location.Y < 0)
            {
                location.Y = 0;
            }

            if (location.X > (panelSchueler.Size.Width - aktivesUsercontrol.Size.Width))
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


        private void ButtonSpeichern_Click(object sender, EventArgs e)
        {
            string datum = getDatum();

            for (int i = 0; i < panelSchueler.Controls.Count; i++)
            {
                UserControlSchueler schueler = panelSchueler.Controls[i] as UserControlSchueler;

                long einheitId = (long)comboBoxEinheit.SelectedValue;
                long raumId = (long)comboBoxRaum.SelectedValue;

                DbAccessViaSQL.UpdateUnterricht(
                    schueler.Kommentar,
                    schueler.Anwesend,
                    schueler.Vorname,
                    schueler.Nachname,
                    datum,
                    einheitId,
                    raumId,
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


        private void ButtonUnterrichtHinzu_Click(object sender, EventArgs e)
        {
            long raumId = (long)comboBoxRaum.SelectedValue;
            long einheitId = (long)comboBoxEinheit.SelectedValue;
            long fachId = (long)comboBoxFach.SelectedValue;
            long klasseId = (long)comboBoxKlasse.SelectedValue;
            string datum = getDatum();

            DataTable dtSchuelerKlasse = DbAccessViaSQL.GetSchuelerVonKlasse(klasseId);

            for (int i = 0; i < dtSchuelerKlasse.Rows.Count; i++)
            {
                long schuelerId = (long)dtSchuelerKlasse.Rows[i][0];
                DbAccessViaSQL.InsertUnterricht(datum, einheitId, fachId, schuelerId, raumId, i * 10);
            }

            // Nachdem die Daten hinzugefügt wurden, ist einmal das Layout zu refreshen
            holeDatenUndAktualisiere();
        }


        private void ButtonSchuelerHinzu_Click(object sender, EventArgs e)
        {
            FormSchuelerHinzufuegen formSchueler = new FormSchuelerHinzufuegen();
            formSchueler.ShowDialog();
        }


        private void ButtonBeenden_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //**************************************************//
        //  Mehtoden                                        //
        //**************************************************//

        private void holeDatenUndAktualisiere()
        {




            //long einheitId = -1;

            if (!string.IsNullOrEmpty(comboBoxEinheit.Text) && !string.IsNullOrEmpty(comboBoxRaum.Text))
            {
                // Datums string für SQL Abfrage
                string datum = getDatum();
                //dateTimePicker.Value.Year.ToString() + '-' +
                //dateTimePicker.Value.Month.ToString() + '-' +
                //dateTimePicker.Value.Day.ToString();


                string[] einheitBeginnEnde = comboBoxEinheit.Text.Split('-');

                long einheitId = (long)comboBoxEinheit.SelectedValue;
                long raumId = (long)comboBoxRaum.SelectedValue;

                // DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(comboBoxRaum.Text, einheitId, datum);
                DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(raumId, einheitId, datum);

                bereinigeUI();


                buttonUnterrichtHinzu.Enabled = true;

                // Hole die untaetigen Klassen, die in der DB existieren und adde diese als Einträge zur Combobox
                DataTable dtUntaetigeKlassen = DbAccessViaSQL.GetUntaetigeKlassen(datum, einheitId);


                comboBoxKlasse.DataSource = dtUntaetigeKlassen;
                comboBoxKlasse.DisplayMember = dtUntaetigeKlassen.Columns[1].ColumnName;
                comboBoxKlasse.ValueMember = dtUntaetigeKlassen.Columns[0].ColumnName;

                /*
                comboBoxKlasse.Items.Clear();
                for (int i = 0; i < dtUntaetigeKlassen.Rows.Count; i++)
                {
                    comboBoxKlasse.Items.Add(dtUntaetigeKlassen.Rows[i][0].ToString());
                }
                */



                // Hole die untaetigen Faecher, die in der DB existieren und adde diese als Einträge zur Combobox
                DataTable dtUntaetigeFaecher = DbAccessViaSQL.GetUntaetigeFaecher(datum, einheitId);

                comboBoxFach.DataSource = dtUntaetigeFaecher;
                comboBoxFach.DisplayMember = dtUntaetigeFaecher.Columns[1].ColumnName;
                comboBoxFach.ValueMember = dtUntaetigeFaecher.Columns[0].ColumnName;
                /*
                                comboBoxFach.Items.Clear();
                                for (int i = 0; i < dtUntaetigeFaecher.Rows.Count; i++)
                                {
                                    comboBoxFach.Items.Add(dtUntaetigeFaecher.Rows[i][0].ToString());
                                }
                                */



                if (dtUnterrichtInfo != null && dtUnterrichtInfo.Rows.Count > 0)
                {
                    aktualisiereDaten(dtUnterrichtInfo);
                    buttonUnterrichtHinzu.Enabled = false;
                }
            }




        }


        private void aktualisiereDaten(DataTable dt)
        {

            labelFach.Text = dt.Rows[0][3].ToString();
            labelLehrer.Text = dt.Rows[0][5].ToString();
            labelKlasse.Text = dt.Rows[0][6].ToString();

            // TODO besser so machen überall aus Gründen
            textBoxLehrstoff.Text = dt.Rows[0][13].ToString();



            int anzahlSchueler = dt.Rows.Count;
            schueler = new UserControlSchueler[anzahlSchueler];

            for (int i = 0; i < schueler.Length; i++)
            {

                string vorname = dt.Rows[i][7].ToString();
                string nachname = dt.Rows[i][8].ToString();
                string kommentar = dt.Rows[i][11].ToString();


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


        private string getDatum()
        {
            return dateTimePicker.Value.ToString("yyyy-MM-dd");
        }


        private void bereinigeUI()
        {
            // Entferne alle Controls (in diesem Fall sind das nur die UserControls) die auf dem Panel sind
            panelSchueler.Controls.Clear();

            labelFach.Text = "-";
            labelLehrer.Text = "-";
            labelKlasse.Text = "-";
            textBoxLehrstoff.Text = "";
        }


    }
}