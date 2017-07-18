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
    public partial class AccountStatementEnhancedUC : UserControl
    {

        DigitalAPItester digitalAPI;

        public AccountStatementEnhancedUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            string statementType = statementTypeCB.Text;
            string transFilter = transFilterCB.Text;
            string OldTime = OldTimeTB.Text;
            string NewTime = NewTimeTB.Text;
            string row = rowsCB.Text;

            int loop = int.Parse(loopTB.Text);
            digitalAPI.AccountStatementEnhanced(statementType,transFilter, OldTime, NewTime, row, loop);

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            string statementType = statementTypeCB.Text;
            string transFilter = transFilterCB.Text;
            string OldTime = OldTimeTB.Text;
            string NewTime = NewTimeTB.Text;
            string row = rowsCB.Text;

            int loop = int.Parse(loopTB.Text);
            digitalAPI.AccountStatementEnhanced(statementType, transFilter, OldTime, NewTime, row, loop);
         }

        private void AccountStatementEnhancedUC_Load(object sender, EventArgs e)
        {
            NewTimeTB.Text = System.DateTime.Now.ToString("yyyy-MM-dd"); //e.g. 2015-01-21
            OldTimeTB.Text = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"); //yesterdays day.
        }


    }
}
