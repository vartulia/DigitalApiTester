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
    public partial class AuthenticatevOOauthUC : UserControl
    {

        DigitalAPItester digitalAPI;
        public AuthenticatevOOauthUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }


        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string AccountNo = accountNumberTB.Text;
            string Password = passwordTB.Text;
            string clientId = clientIdTB.Text;
            string clientSecret = clientSecretTB.Text;
            string Operator = termOperatorTB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.AuthenticateOauthABACUS(AccountNo, Password, clientId, clientSecret, Operator,loop);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string clientId = clientTB.Text;
            string clientSecret = secretTB.Text;
            string request = "client_id=" + clientId + "&client_secret=" + clientSecret + "&grant_type=client_credentials";
            digitalAPI.AuthenticateOauth(clientId, clientSecret, request);
        }
    }
}
