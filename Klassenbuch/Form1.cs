using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Klassenbuch.DbAccess;


namespace Klassenbuch
{

    public partial class Form1 : Form
    {

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

            // Hole Daten aus der Db und aktualsiere das UI
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

                // Nach dem letzten Insert einmal refreshen
                if(i == (dtSchuelerKlasse.Rows.Count-1))
                {
                    holeDatenUndAktualisiere();
                }
            }
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

            if (!string.IsNullOrEmpty(comboBoxEinheit.Text) && !string.IsNullOrEmpty(comboBoxRaum.Text))
            {

                // Zunächst einmal das UI clearen
                bereinigeUI();

                string datum = getDatum();
                long einheitId = (long)comboBoxEinheit.SelectedValue;
                long raumId = (long)comboBoxRaum.SelectedValue;
                
                // Hole die Daten zum Unterricht anhand von Raum, Unterrichtseinheit und Datum
                DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(raumId, einheitId, datum);

                // Hole die untaetigen Klassen die in der Db existieren und füge diese zur Combobox hinzu
                DataTable dtUntaetigeKlassen = DbAccessViaSQL.GetUntaetigeKlassen(datum, einheitId);
                comboBoxKlasse.DataSource = dtUntaetigeKlassen;
                comboBoxKlasse.DisplayMember = dtUntaetigeKlassen.Columns[1].ColumnName;
                comboBoxKlasse.ValueMember = dtUntaetigeKlassen.Columns[0].ColumnName;

                // Hole die untaetigen Faecher die in der Db existieren und füge diese zur Combobox hinzu
                DataTable dtUntaetigeFaecher = DbAccessViaSQL.GetUntaetigeFaecher(datum, einheitId);
                comboBoxFach.DataSource = dtUntaetigeFaecher;
                comboBoxFach.DisplayMember = dtUntaetigeFaecher.Columns[1].ColumnName;
                comboBoxFach.ValueMember = dtUntaetigeFaecher.Columns[0].ColumnName;

                // Wenn keine Daten zum Untericht vorliegen, kann die UI nicht gefüllt werden
                if (dtUnterrichtInfo != null && dtUnterrichtInfo.Rows.Count > 0)
                {
                    aktualisiereDaten(dtUnterrichtInfo);
                    buttonUnterrichtHinzu.Enabled = false;
                }
                else
                {
                    buttonUnterrichtHinzu.Enabled = true;
                }
            }
        }


        private void aktualisiereDaten(DataTable dt)
        {
            // Fülle das Panel Unterricht mit Daten
            labelFach.Text = dt.Rows[0][3].ToString();
            labelLehrer.Text = dt.Rows[0][5].ToString();
            labelKlasse.Text = dt.Rows[0][6].ToString();

            // Fülle die Textbox Lehrstoff mit Daten
            textBoxLehrstoff.Text = dt.Rows[0][13].ToString();

            int anzahlSchueler = dt.Rows.Count;

            // Erzeuge ein Array vom Typ UserControlSchueler mit der Anzahl an Schülern, die am Unterricht teilnehmen
            UserControlSchueler[] schueler = new UserControlSchueler[anzahlSchueler];

            // Setzen der Daten für jedes UserControl Objekt, sowie das Hinzufügen des Controls zum Panel
            for (int i = 0; i < schueler.Length; i++)
            {

                string vorname = dt.Rows[i][7].ToString();
                string nachname = dt.Rows[i][8].ToString();
                string kommentar = dt.Rows[i][11].ToString();

                string bildname = vorname + nachname + ".jpg";
                string pfadZumBild = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..", "Bilder", bildname));


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


                // Erzeugen des UserControlSchueler Objektes
                schueler[i] = new UserControlSchueler(vorname, nachname, pfadZumBild, kommentar, anwesend);


                // Setzen der Location, wo das Control auf dem Panel sein soll
                schueler[i].Location = new Point((int)dt.Rows[i][9], (int)dt.Rows[i][10]);


                // Registrierung der Event Handler für das Hauptelement
                schueler[i].MouseDown += usercontrol_MouseDown;
                schueler[i].MouseMove += usercontrol_MouseMove;
                schueler[i].MouseUp += usercontrol_MouseUp;


                // Registrierung des Event Handlers für die Checkbox im Control
                foreach (Control ctrl in schueler[i].Controls)
                {
                    if (ctrl.GetType() == typeof(CheckBox))
                    {
                        CheckBox cb = ctrl as CheckBox;
                        cb.Click += usercontrol_CheckBox_Click;
                    }
                }

                // Hinzufügen des Controls zum Panel
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