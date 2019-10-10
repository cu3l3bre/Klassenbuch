using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Klassenbuch
{

    public partial class UserControlSchueler : UserControl
    {

        private bool formExpandieren;

        public bool UcExpandieren
        {
            get { return formExpandieren; }
            set { formExpandieren = value; }
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
        

        public string Kommentar
        {
            get { return textBoxGrund.Text; }
            set { textBoxGrund.Text = value; }
        }


        public UserControlSchueler()
        {
            InitializeComponent();
        }


        public UserControlSchueler(string vorname, string nachname, string bildpfad, string kommentar, CheckState anwesend) : this()
        {
            formExpandieren = false;

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

            buttonMehrInfo.Click += new EventHandler(button_Click);
            timer.Tick += new EventHandler(timer_Tick);
            checkBoxAnwesend.Click += new EventHandler(checkBox_Click);
        }


        //**************************************************//
        //  Event Handler                                   //
        //**************************************************//

        private void button_Click(object sender, EventArgs e)
        {
            this.formExpandieren ^= true;
            timer.Start();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            int defaultBreite = 340;
            int expBreite = defaultBreite + 100;

            if (this.Width < expBreite && formExpandieren)
            {
                buttonMehrInfo.Text = "<";
                this.Width += 5;
            }
            else if (this.Width > defaultBreite && !formExpandieren)
            {
                buttonMehrInfo.Text = ">";
                this.Width -= 5;
            }
            else
            {
                timer.Stop();
            }
        }


        private void checkBox_Click(object sender, EventArgs e)
        {
            if (checkBoxAnwesend.CheckState == CheckState.Checked)
            {
                this.BackColor = Color.Green;
            }
            else if (checkBoxAnwesend.CheckState == CheckState.Unchecked)
            {
                this.BackColor = Color.Red;
            }
        }


    }
}
