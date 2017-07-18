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
    public partial class ActivateAccountUC : UserControl
    {
        DigitalAPItester digitalAPI;

        public ActivateAccountUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            AccountActivateClass.account aa = new AccountActivateClass.account();

            aa.accountNumber = accountNumberTB.Text;
            aa.channel = channelCB.Text;
            aa.pin = Convert.ToInt32(pinTB.Text);
            aa.password = passwordTB.Text;
            aa.email = emailTB.Text;
            aa.surname = surnameTB.Text;
            aa.challengeQuestion = challengeQuestionTB.Text;
            aa.challengeAnswer = challengeAnswerTB.Text;

            

            digitalAPI.ActivateAccount(aa);

        }
        
        
    }
}
