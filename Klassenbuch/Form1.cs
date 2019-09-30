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

namespace Klassenbuch
{
    public partial class Form1 : Form
    {

        private int anzahlSchueler = 3;
        private UserControlSchueler[] schueler;
        


        public Form1()
        {
            InitializeComponent();

            comboBoxRaum.Items.Add(1);
            comboBoxRaum.Items.Add(2);
            comboBoxRaum.Items.Add(3);
            comboBoxRaum.Items.Add(4);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }


        private void ComboBoxRaum_TextChanged(object sender, EventArgs e)
        {
            zeigeSchueler();
        }


        private void zeigeSchueler()
        {
            panelSchueler.Controls.Clear();

            int.TryParse(comboBoxRaum.Text, out int anzahl);

            schueler = new UserControlSchueler[anzahl];
            string pathToImage = Path.GetFullPath(Path.Combine(
            Application.StartupPath, @"..\..", "Bilder", "HarryPotter.jpg"));

            int offset = 0;
            for (int i = 0; i < schueler.Length; i++)
            {

                schueler[i] = new UserControlSchueler("Harry", "Potter", pathToImage);

                //schueler[1].Controls. += checkbox_Click
                

                schueler[i].Kommentar = "Platz für Kommentare";
                //schueler[i].Anwesend

                schueler[i].Location = new Point(10, 50 + offset);
                panelSchueler.Controls.Add(schueler[i]);

                offset += 80;
            }

        }



    }
}
