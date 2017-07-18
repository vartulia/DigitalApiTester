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
    public partial class EFT_Registration : UserControl
    {
        DigitalAPItester digitalAPI;
        public EFT_Registration(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string bsb = bsbTB.Text;
            string acctNo = bankAccountNoTB.Text;
            string acctName = bankAccountNameTB.Text;
            int loop = int.Parse(loopTB.Text);

            digitalAPI.EFT_Reg(bsb, acctNo, acctName, loop);

        }
    }
}
