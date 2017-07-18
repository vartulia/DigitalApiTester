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
    public partial class ScanRetailTicketUC : UserControl
    {
        DigitalAPItester digitalAPI;

        public ScanRetailTicketUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

//        private void EnqurieTicektBTN_Click(object sender, EventArgs e)
 //       {
  //      }

        private void payTicketBTN_Click(object sender, EventArgs e)
        {
      
            int loop = int.Parse(loopTB.Text);
            digitalAPI.scanRetailTicket_Pay(loop, tsnTB.Text, pinTB.Text);
        }

        private void EnquireTicketBTN_Click(object sender, EventArgs e)
        {
            int loop = int.Parse(loopTB.Text);
            digitalAPI.scanRetailTicket_EnquiryLoggedIn(loop, tsnTB.Text, pinTB.Text);

        }

        private void tsnTB_TextChanged(object sender, EventArgs e)
        {
            string tsnStripped = tsnTB.Text;
            tsnStripped = tsnStripped.Replace(" ", "");
            tsnTB.Text = tsnStripped;

        }

        private void EnquireTicketNOTLoggedInBTN_Click(object sender, EventArgs e)
        {
            int loop = int.Parse(loopTB.Text);
            digitalAPI.scanRetailTicket_EnquiryNotLoggedIn (loop, tsnTB.Text, pinTB.Text, jursidictionCB.Text);

        }

    }
}
