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
    public partial class AccountStatementRecent : UserControl
    {
        DigitalAPItester digitalAPI;
        public AccountStatementRecent(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            int rows = 0;
            rows = Convert.ToInt32(countTB.Text);
            int loop = int.Parse(loopTB.Text);
            digitalAPI.GetRecentTransactions(rows,loop);
        }
    }
}
