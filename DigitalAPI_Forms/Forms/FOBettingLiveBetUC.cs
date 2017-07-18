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
using System.Threading;
namespace DigitalAPI_Forms
{
    public partial class FOBettingLiveBetUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public FOBettingLiveBetUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string Stake = InvestAmtTB.Text;
            string Bettype = BetTypeCB.Text;
            string PropId = propositionIdTB.Text;
            string Odds = OddsTB.Text;
            string Outlet = outletWinTB.Text;
            int loop = int.Parse(loopTB.Text);
            string id = digitalAPI.liveBetslipEnquiry(Stake, Bettype, PropId, Odds, Outlet, loop);
            digitalAPI.liveBetslip(id, loop);
            digitalAPI.pollLiveBetslip(id, Outlet, loop);
            Thread.Sleep(8000);
            digitalAPI.liveBetslipReceipt(id, loop);
        }

        private void CallApiEW_BTN_Click(object sender, EventArgs e)
        {
            string StakeWin = WINInvestAmtTB.Text;
            string StakePlace = PLACEInvestAmtTB.Text;
            string Bettype = BetTypeEW_BTN.Text;
            string PropId = propositionIdEW_TB.Text;
            string Odds = OddsEW_TB.Text;
            string Outlet = outletEwTB.Text;
            string secondaryOdds = secondaryOddsEW_TB.Text;
            int loop = int.Parse(loopEW_TB.Text);

            string id = digitalAPI.liveBetslipEnquiryEW(StakeWin, StakePlace, Bettype, PropId, Odds, secondaryOdds, Outlet, loop);
            digitalAPI.liveBetslip(id, loop);
            digitalAPI.pollLiveBetslip(id, Outlet, loop);
            Thread.Sleep(8000);
            digitalAPI.liveBetslipReceipt(id, loop);



            //digitalAPI.betslip_EW(StakeWin, StakePlace, Bettype, PropId, Odds, secondaryOdds, loop);
        }
    }
}
