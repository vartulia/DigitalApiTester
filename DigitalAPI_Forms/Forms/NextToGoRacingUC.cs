using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DigitalAPI_Forms;

namespace DigitalAPI_Forms
{
    public partial class NextToGoRacingTC : UserControl
    {
        DigitalAPItester digitalAPI;
        public NextToGoRacingTC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string jurisdiction = jurisdictionCB.Text;
            string maxRaces = MaxRacesTB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.NextToGoRacing(jurisdiction,maxRaces, loop);
        }
    }
}
