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


        public bool? Anwesend
        {
            get
            {
                if(checkBoxAnwesend.CheckState == CheckState.Checked)
                {
                    return true;
                }
                else if(checkBoxAnwesend.CheckState == CheckState.Unchecked)
                {
                    return false;
                }
                else
                {
                    return null;
                }
            }

            set
            {
                if (value.HasValue)
                {
                    if (value == true)
                    {
                        checkBoxAnwesend.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        checkBoxAnwesend.CheckState = CheckState.Unchecked;
                    }
                }
                else
                {
                    checkBoxAnwesend.CheckState = CheckState.Indeterminate;
                }
            }
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


        public UserControlSchueler()
        {
            InitializeComponent();
        }


        public UserControlSchueler(string vorname, string nachname, string bildpfad, string kommentar, CheckState anwesend) : this()
        {
            labelVorname.Text = vorname;
            labelNachname.Text = nachname;
            pictureBoxBild.ImageLocation = bildpfad;
            pictureBoxBild.SizeMode = PictureBoxSizeMode.StretchImage;
            textBoxGrund.Text = kommentar;

            if (anwesend == CheckState.Checked)
            {   
                checkBoxAnwesend.CheckState = CheckState.Checked;
                this.BackColor = Color.LightGreen;
            }
            else if (anwesend == CheckState.Unchecked)
            {
                checkBoxAnwesend.CheckState = CheckState.Unchecked;
                this.BackColor = Color.PeachPuff;
            }
            else
            {
                checkBoxAnwesend.CheckState = CheckState.Indeterminate;
            }
        }
    }
}
