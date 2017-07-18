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
    public partial class CardOrdering : UserControl
    {
        DigitalAPItester digitalAPI;
        public CardOrdering(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string Password = passwordTB.Text;
            string Channel = channelCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.CardOrdering(Password, Channel, loop);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ChannelLB_Click(object sender, EventArgs e)
        {

        }

        private void passwordLBL_Click(object sender, EventArgs e)
        {

        }

        private void passwordTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void channelCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loopLBL_Click(object sender, EventArgs e)
        {

        }

        private void loopTB_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
