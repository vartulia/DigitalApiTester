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
    

    public partial class FixedOddsBettingMultiUC : UserControl
    {
        DigitalAPItester digitalAPI;
        string tsn = "";
        public FixedOddsBettingMultiUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }


        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            int No_of_legs = Convert.ToInt32(legsTB.Text);
            int loop = int.Parse(loopTB.Text);
            string combinedPrice = combinedPriceTB.Text;
            string InvestAmt = InvestAmtTB.Text;
            string multiplier = MultiplierCB.Text;
            string Systems = systemMultiTB.Text;
            string Flexi = FlexiTB.Text;
            bool isCostEnquiry = costEnquiryCKBox.Checked;
            Boolean isSystem = isSuperMultiCKB.Checked;
            List<prop> propList = new List<prop>();


            for (int i = 1; i <= No_of_legs; i++)
            {
                TextBox curText = (TextBox)this.Controls.Find("prop" + i.ToString(), true)[0];
                TextBox oddsText = (TextBox)this.Controls.Find("Odds" + i.ToString(), true)[0];
                ComboBox typeText = (ComboBox)this.Controls.Find("betType" + i.ToString(), true)[0];

                prop myProp = new prop();
                myProp.propId = curText.Text;
                myProp.Odds = oddsText.Text;
                myProp.type = typeText.Text;
                propList.Add(myProp);
            }
            tsn = digitalAPI.betslip_multi(propList, multiplier, InvestAmt, isSystem, Systems, Flexi, combinedPrice, isCostEnquiry, loop);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (isSuperMultiCKB.Checked == true)
            {
                systemMultiTB.Enabled = true;
                FlexiTB.Enabled = true;
            }
        }

        private void copyTSNBTN_Click(object sender, EventArgs e)
        {
            if (tsn.Length > 0)
                Clipboard.SetText(tsn);
            else
                tsn = "";
        }
    }
    public class prop
    {
        public string type;
        public string propId;
        public string Odds;

    }
}
