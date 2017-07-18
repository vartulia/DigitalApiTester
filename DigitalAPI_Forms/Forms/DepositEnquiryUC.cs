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
    public partial class DepositEnquiryUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public DepositEnquiryUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string amount = amountTB.Text;
            string cardNumb = maskCreditCardTB.Text;
            string token = creditCardTokenTB.Text;
            int loop = int.Parse(loopTB.Text);

            digitalAPI.depositEnquiry(amount, cardNumb, token, loop);
        }

        private void creditCardTokenTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskCreditCardTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void loopLBL_Click(object sender, EventArgs e)
        {

        }

        private void loopTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void StatusStatementLBL_Click(object sender, EventArgs e)
        {

        }

        private void maskCreditCardLBL_Click(object sender, EventArgs e)
        {

        }

        private void amountLBL_Click(object sender, EventArgs e)
        {

        }

        private void amountTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
