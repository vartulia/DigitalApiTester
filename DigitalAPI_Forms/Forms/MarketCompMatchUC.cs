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
    public partial class MarketCompMatchUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public MarketCompMatchUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            
            string sportName = SportNameTB.Text;
            string competitionName = competitionNameTB.Text;
            string matchName = MatchNameTB.Text;
            string jurisdiction = jurisdictionCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.MarketsCompMatch(sportName, competitionName, matchName, jurisdiction, loop);
        }
    }
}
