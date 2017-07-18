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
    public partial class MarketsCompTournUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MarketsCompTournUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string tournament = tournamentNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);

            digitalAPI.MarketsCompTourn(sportName, competitionName, tournament,jurisdiction, loop);
        }
    }
}
