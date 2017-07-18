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
    public partial class AccountStatement : UserControl
    {
        DigitalAPItester digitalAPI;

        public AccountStatement(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
            if (!TypeCB.Items.Contains("SUMMARY"))
                TypeCB.Items.Add("SUMMARY");
            if (!TypeCB.Items.Contains("FIXED_ODDS"))
                TypeCB.Items.Add("FIXED_ODDS");
            if (!TypeCB.Items.Contains("PARIMUTUEL"))
                TypeCB.Items.Add("PARIMUTUEL");
            if (!TypeCB.Items.Contains("ALL"))
                TypeCB.Items.Add("ALL");

            if (!StatusCB.Items.Contains("ALL"))
                StatusCB.Items.Add("ALL");
            if (!StatusCB.Items.Contains("WON"))
                StatusCB.Items.Add("WON");
            if (!StatusCB.Items.Contains("OPEN"))
                StatusCB.Items.Add("OPEN");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            int rows = 0;
            rows = Convert.ToInt32(countTB.Text);
            string type = TypeCB.Text;
            string status = StatusCB.Text;
            int loop = int.Parse(loopTB.Text);
            digitalAPI.AccountStatement(rows, type, status,loop);
        }
    }
}
