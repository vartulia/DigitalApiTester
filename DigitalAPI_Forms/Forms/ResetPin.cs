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
    public partial class ResetPin : UserControl
    {
        DigitalAPItester digitalAPI;
        public ResetPin(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string password = passwordTB.Text;
            string pin = pinTB.Text;
            int loop = int.Parse(loopTB.Text);  
            digitalAPI.ResetPin(password, pin,loop); 
        }
    }
}
