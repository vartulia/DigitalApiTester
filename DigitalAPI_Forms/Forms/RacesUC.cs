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
    public partial class RacesUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public RacesUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string meetingDate = MeetingDateCB.Text;
            string RealType = RealTypeCB.Text;
            string venueMnemonic = VenueMmcTB.Text;
            string raceNumber = raceNumerTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.races(meetingDate, RealType, venueMnemonic, raceNumber, jurisdiction,loop);
        }
    }
}
