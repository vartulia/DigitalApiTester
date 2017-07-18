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
    public partial class AccountUnlockUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public AccountUnlockUC(DigitalAPItester mainForm)
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
            string cAnswer = challengeAnswer1TB.Text;
            string password = password1TB.Text;
            digitalAPI.UnlockAccountChallengeAnswer(AccountNo, Pin, Channel, Surname, cAnswer, password, loop);
        }

        private void callAPI_dobBTN_Click(object sender, EventArgs e)
        {
            string AccountNo = AccountNo_DOB.Text;
            string dob = DOB_DOB.Text;
            string Channel = Channel_DOB.Text;
            string Surname = Surname_DOB.Text;
            int loop = int.Parse(loopTB.Text);
            string cAnswer = challengeAnswer2TB.Text;
            string password = password2TB.Text;
            digitalAPI.UnlockAccountDOB(AccountNo, dob, Channel, Surname, cAnswer, password, loop);
        }
    }
}
