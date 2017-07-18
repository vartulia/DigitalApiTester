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
    public partial class MatchTournamentUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MatchTournamentUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            string tournamentName = tournamentNameTB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.MatchTournament(sportName, competitionName, tournamentName, jurisdiction, loop);
        }
    }
}
