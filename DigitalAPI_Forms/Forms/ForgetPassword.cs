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
    public partial class ForgetPassword : UserControl
    {
        DigitalAPItester digitalAPI;

        public ForgetPassword(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string AccountNo = accountNumberTB.Text;
            int Pin = Convert.ToInt32(pinTB.Text);
            string Channel = channelCB.Text;
            string Surname = surnameTB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.ForgotPassword(AccountNo, Pin, Channel, Surname, loop);
        }

        private void callAPI_dobBTN_Click(object sender, EventArgs e)
        {
            string AccountNo = AccountNo_DOB.Text;
            string DOB = DOB_DOB.Text;
            string Channel = Channel_DOB.Text;
            string Surname = Surname_DOB.Text;
            int loop = int.Parse(loopDOB.Text);
            digitalAPI.ForgotPassword_DOB(AccountNo, DOB, Channel, Surname, loop);
        }

        private void callAPIChallBTN_Click(object sender, EventArgs e)
        {
            string AccountNo = acctNoChallTB.Text;
            string cAnswer = challengeA_TB.Text;
            string password = pwordTB.Text;
            string Channel = chanChallengeCB.Text;
            int loop = int.Parse(loopDOB.Text);
            digitalAPI.ForgotPassword_Challenge(AccountNo, cAnswer, password, Channel, loop);
        }
    }
}
