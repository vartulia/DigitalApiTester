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
    public partial class MatchesUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MatchesUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.Matches(sportName, competitionName, jurisdiction,loop);
        }

        
        private void loopLBL_Click(object sender, EventArgs e)
        {

        }

        private void loopTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void competitionNameLBL_Click(object sender, EventArgs e)
        {

        }

        private void competitionNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void SportNameLBL_Click(object sender, EventArgs e)
        {

        }

        private void SportNameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void jurisdictionCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void JurisdictionLBL_Click(object sender, EventArgs e)
        {

        }
    }
}
