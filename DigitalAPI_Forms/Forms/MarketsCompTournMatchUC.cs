using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DigitalAPI_Forms
{
    public partial class MarketsCompTournMatchUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MarketsCompTournMatchUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string tournament = tournamentNameTB.Text;
            string matchName = MatchNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.MarketsCompTournMatch(sportName, competitionName, tournament, matchName, jurisdiction, loop);
        }
    }
}
