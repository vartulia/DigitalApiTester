using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalAPI_Forms
{
    public partial class cashoutUC : UserControl
    {

        DigitalAPItester digitalAPI;
        List<CashOut> cashList = new List<CashOut>();

        public cashoutUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            CashOut cashOut = new CashOut();
            cashOut.serialNumber = serialTB.Text.Replace(" ","");
            cashOut.serialNumber = cashOut.serialNumber.TrimStart('0');
            cashOut.amount = OfferAmountTB.Text;
            cashOut.partialAmount = partialAmountTB.Text;

            if (cashOut.amount.Contains("$") || cashOut.partialAmount.Contains("$"))
            {
                //do nothing
            }
            else
            {
                cashOut.amount = "$" + OfferAmountTB.Text;
                cashOut.partialAmount = "$" + partialAmountTB.Text;
            }

          
            cashList.Add(cashOut);
            int loop = int.Parse(loopTB.Text);

            digitalAPI.cashOutAccept(cashList, loop);
            cashList.Remove(cashOut);
            OfferAmountTB.Text = digitalAPI.amount;
        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            CashOut cashOut = new CashOut();
            //cashOut.code = CashoutCodeCB.Text;
            cashOut.serialNumber = serialTB.Text;
            cashOut.amount = OfferAmountTB.Text;
            //cashOut.flags = flagsTB.Text;
            //cashOut.balance = sessionBalTB.Text;
            //cashOut.recentageReq = percentTB.Text;
            //cashOut.offerId = OfferIdTB.Text;
            cashList.Add(cashOut);

            //CashoutCodeCB.Text = "O";
            serialTB.Text = "xxxxxxxxxxxxxx901";
            //OfferAmountTB.Text = "100";
            //flagsTB.Text = "1";
            //sessionBalTB.Text = "0";
            //percentTB.Text = "10000";
            //OfferIdTB.Text ="0";
            

            if (cashList.Count > 0)
            {
                Accept.Enabled = true;
                Request_BTN.Enabled = true;
            }


        }

        public class CashOut
        {
            public string code;
            public string serialNumber;
            public string amount;
            public string partialAmount;
            public string flags;
            public string balance;
            public string recentageReq;
            public string offerId;
        }

        private void clearBTN_Click(object sender, EventArgs e)
        {
            cashList.Clear();
            if (cashList.Count < 1)
            {
                Accept.Enabled = false;
            }
        }

        private void Request_BTN_Click(object sender, EventArgs e)
        {
            CashOut cashOut = new CashOut();
            cashOut.serialNumber = serialTB.Text.Replace(" ","");
            cashOut.serialNumber = cashOut.serialNumber.TrimStart('0');
            cashOut.amount = OfferAmountTB.Text;
            cashList.Add(cashOut);
            int loop = int.Parse(loopTB.Text);

            digitalAPI.cashOutReq(cashList, loop);
            cashList.Remove(cashOut);
            OfferAmountTB.Text = digitalAPI.amount;
        }
        
        private void getOfferIdBTN_Click(object sender, EventArgs e)
        {
            CashOut cashOut = new CashOut();
            cashOut.serialNumber = serialTB.Text;
            cashOut.amount = OfferAmountTB.Text;
            cashList.Add(cashOut);
            int loop = int.Parse(loopTB.Text);

            digitalAPI.cashOutOfferId(cashList, loop);
            cashList.Remove(cashOut);
            OfferAmountTB.Text = digitalAPI.amount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int loop = int.Parse(loopTB.Text);
            digitalAPI.cashoutOffers(loop);
        }
    }
}
