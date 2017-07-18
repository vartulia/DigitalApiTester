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

    public partial class AuthenticateUC : UserControl
    {
        DigitalAPItester digitalAPI; // = new DigitalAPItester();
        
        public AuthenticateUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
            this.ActiveControl = accountNumberTB;
        }

        
        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string AccountNo = accountNumberTB.Text;
            string Password = passwordTB.Text;
            string Channel = channelCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.Authenticate(AccountNo, Password, Channel, loop);
        }


       

       
    }
}
