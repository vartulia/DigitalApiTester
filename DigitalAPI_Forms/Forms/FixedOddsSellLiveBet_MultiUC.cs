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
    public partial class FixedOddsSellLiveBet_MultiUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public FixedOddsSellLiveBet_MultiUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            int No_of_legs = Convert.ToInt32(legsTB.Text);
            int loop = int.Parse(loopTB.Text);
            string InvestAmt = InvestAmtTB.Text;
            string outlet = outletTB.Text;
            List<prop> propList = new List<prop>();


            for (int i = 1; i <= No_of_legs; i++)
            {
                TextBox curText = (TextBox)this.Controls.Find("prop" + i.ToString(), true)[0];
                TextBox oddsText = (TextBox)this.Controls.Find("Odds" + i.ToString(), true)[0];
                ComboBox typeText = (ComboBox)this.Controls.Find("betType" + i.ToString(), true)[0];

                prop myProp = new prop();
                myProp.propId = curText.Text;
                myProp.Odds = oddsText.Text;
                myProp.type = typeText.Text;
                propList.Add(myProp);
            }

            string id = digitalAPI.betslip_multi_LiveBet(propList, InvestAmt, outlet, loop);
            digitalAPI.liveBetslip(id, loop);
            digitalAPI.pollLiveBetslip(id, outlet, loop);
            Thread.Sleep(8000);
            digitalAPI.liveBetslipReceipt(id, loop);
                     

        }
    }
}
