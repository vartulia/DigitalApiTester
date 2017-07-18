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
    public partial class CancelBetUC : UserControl
    {

        DigitalAPItester digitalAPI;
        public CancelBetUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();

        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string tsn = ticketSerialNumberTB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.CancelBet(tsn, loop);
        }
    }
}
