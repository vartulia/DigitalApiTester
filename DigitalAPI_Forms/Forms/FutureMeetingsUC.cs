﻿using System;
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
    public partial class FutureMeetingsUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public FutureMeetingsUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string meetingDate = MeetingDateCB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.futureMeetings(meetingDate, jurisdiction, loop);
        }
    }
}
