using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalAPI_Forms;

namespace DigitalAPI_Forms
{
    public partial class FOBettingUC : UserControl
    {
        DigitalAPItester digitalAPI;
        string tsn = "";
        public FOBettingUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string Stake = InvestAmtTB.Text;
            string  multiplier = MultiplierCB.Text;
            string Bettype = BetTypeCB.Text;
            string PropId = propositionIdTB.Text;
            string Odds = OddsTB.Text;
            bool isCostEnquiry = costEnquiryCKBox.Checked;
            string BonusBetToken = BonusBetTokenTB.Text;
            int loop = int.Parse(loopTB.Text);
            tsn = digitalAPI.betslip(Stake, multiplier, Bettype, PropId, Odds, isCostEnquiry, BonusBetToken, loop);
        }
        

        private void CallApiEW_BTN_Click(object sender, EventArgs e)
        {
            string StakeWin = WINInvestAmtTB.Text;
            string StakePlace = PLACEInvestAmtTB.Text;
            string multiplier = EachWayMultiplierCB.Text;
            string Bettype = BetTypeEW_BTN.Text;
            string PropId = propositionIdEW_TB.Text;
            string Odds = OddsEW_TB.Text;
            string secondaryOdds = secondaryOddsEW_TB.Text;
            bool isCostEnquiry = costEnquiryCKBox.Checked;
            string BonusBetToken = BonusBetTokenTB.Text;
            int loop = int.Parse(loopEW_TB.Text);
            tsn = digitalAPI.betslip_EW(StakeWin, StakePlace, multiplier, Bettype, PropId, Odds, secondaryOdds, isCostEnquiry, loop);
        }

        private void getBonusBetTokensCmd_Click(object sender, EventArgs e)
        {
            digitalAPI.getBonusBetTokens();
        }

        private void copyTSNBTN_Click(object sender, EventArgs e)
        {
            if (tsn.Length > 0)
                Clipboard.SetText(tsn);
            else
                tsn = "";

        }
    }
}
