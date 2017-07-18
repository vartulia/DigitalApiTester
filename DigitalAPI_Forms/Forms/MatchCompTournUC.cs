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
    public partial class MatchCompTournUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MatchCompTournUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            //tournamentNameTB
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string tournamentName = tournamentNameTB.Text;
            string matchName = MatchNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.MatchCompTourn(sportName, competitionName, tournamentName, matchName,jurisdiction, loop);
        }
    }
}
