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

    /*public enum RaumNr
    {
        A101 = 1,
        A102,
        A103,
        A201,
        A202,
        A203
    }*/



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


            DataTable dtRaumInfo = DbAccessViaSQL.GetRaeume();
            for (int i = 0; i < dtRaumInfo.Rows.Count; i++)
            {
               comboBoxRaum.Items.Add(dtRaumInfo.Rows[i].ItemArray[0].ToString());
            }



            DataTable dtEinheitInfo = DbAccessViaSQL.GetEinheiten();
            for (int i = 0; i < dtEinheitInfo.Rows.Count; i++)
            {
                Debug.WriteLine(dtEinheitInfo.Rows[i].ItemArray[0].ToString() + " "
                                + dtEinheitInfo.Rows[i].ItemArray[1].ToString());


                comboBoxEinheit.Items.Add(dtEinheitInfo.Rows[i].ItemArray[0].ToString() + " - " + dtEinheitInfo.Rows[i].ItemArray[1].ToString());

            }

        }



        private void aktualisiereDaten_TextChanged(object sender, EventArgs e)
        {

            int.TryParse(comboBoxRaum.Text, out int raumId);

            DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(comboBoxRaum.Text);
            /*
            Debug.WriteLine(dtUnterrichtInfo.Rows[0].ItemArray[0]);
            Debug.WriteLine(dtUnterrichtInfo.Rows[0].ItemArray[1]);
            Debug.WriteLine(dtUnterrichtInfo.Rows[1].ItemArray[0]);
            Debug.WriteLine(dtUnterrichtInfo.Rows[1].ItemArray[1]);
            */

            //Debug.WriteLine(dtUnterrichtInfo.Rows[0].ItemArray[0]);

            if (dtUnterrichtInfo.Rows.Count > 0)
            {
                zeigeSchueler(dtUnterrichtInfo);
            }
        }


        //private void ComboBoxRaum_TextChanged(object sender, EventArgs e)
        //{

        //    int.TryParse(comboBoxRaum.Text, out int raumId);

        //    DataTable dtUnterrichtInfo = DbAccessViaSQL.GetUntertichtInfo(comboBoxRaum.Text);
        //    /*
        //    Debug.WriteLine(dtUnterrichtInfo.Rows[0].ItemArray[0]);
        //    Debug.WriteLine(dtUnterrichtInfo.Rows[0].ItemArray[1]);
        //    Debug.WriteLine(dtUnterrichtInfo.Rows[1].ItemArray[0]);
        //    Debug.WriteLine(dtUnterrichtInfo.Rows[1].ItemArray[1]);
        //    */


        //    //Debug.WriteLine(dtUnterrichtInfo.Rows[0].ItemArray[0]);

        //    if (dtUnterrichtInfo.Rows.Count > 0)
        //    {
        //        zeigeSchueler(dtUnterrichtInfo);
        //    }
            
        //}


        private void zeigeSchueler(DataTable dt)
        {
            panelSchueler.Controls.Clear();


            labelFach.Text = dt.Rows[0].ItemArray[3].ToString();
            labelLehrer.Text = dt.Rows[0].ItemArray[5].ToString();
            labelKlasse.Text = dt.Rows[0].ItemArray[6].ToString();

            int anzahlSchueler = dt.Rows.Count;

            //int.TryParse(comboBoxRaum.Text, out int anzahl);

            schueler = new UserControlSchueler[anzahlSchueler];


            //int offset = 0;
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
                //schueler[i].Kommentar = "Platz für Kommentare";

                //schueler[i].Location = new Point(10, 50 + offset);
                schueler[i].Location = ucLocation;
                panelSchueler.Controls.Add(schueler[i]);

                //offset += 80;
            }

        }



    }
}
