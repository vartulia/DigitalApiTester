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
    public partial class MatchCompetitionUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MatchCompetitionUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            string matchName = MatchNameTB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.MatchCompetition(sportName, competitionName, matchName, jurisdiction, loop);
        }
    }
}
