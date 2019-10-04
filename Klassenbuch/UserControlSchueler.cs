using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Klassenbuch
{
    public partial class UserControlSchueler : UserControl
    {

        public string Kommentar
        {
            get { return textBoxGrund.Text; }
            set { textBoxGrund.Text = value; }
        }


        public bool Anwesend
        {
            get {return checkBoxAnwesend.Checked; }
            set { checkBoxAnwesend.Checked ^= value; }
        }

        public string Vorname
        {
            get { return labelVorname.Text; }
            set { labelVorname.Text = value; }
        }

        public string Nachname
        {
            get { return labelNachname.Text; }
            set { labelNachname.Text = value; }
        }


        //public int Location_X
        //{
        //    get { return  UserControlSchueler.  labelNachname.Text; }
        //    set { labelNachname.Text = value; }
        //}


        public UserControlSchueler()
        {
            InitializeComponent();
        }


        public UserControlSchueler(string vorname, string nachname, string bildpfad, string kommentar, bool anwesend) : this()
        {
            labelVorname.Text = vorname;
            labelNachname.Text = nachname;
            pictureBoxBild.ImageLocation = bildpfad;
            pictureBoxBild.SizeMode = PictureBoxSizeMode.StretchImage;
            checkBoxAnwesend.Checked = anwesend;
            textBoxGrund.Text = kommentar;
        }
    }
}
