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
    public partial class InVenueCommissionsUC : UserControl
    {
        DigitalAPItester digitalAPI;

        List<string> serialNumbers = new List<string>();
        public InVenueCommissionsUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        public class CommissionRequest
        {
            public string type;
            public string accountId;
            public string dateTime;
            public string latitude;
            public string longitude;
            public string uncertainty;
            public string blueDotFence;
            public string beaconVenueId;
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            CommissionRequest comReq = new CommissionRequest();

            comReq.type = typeCB.Text; ;
            comReq.accountId = accountIdTB.Text;
            comReq.dateTime = dateTimeTB.Text;
            comReq.latitude = latitudeTB.Text;
            comReq.longitude = longitudeTB.Text;
            comReq.uncertainty = uncertaintyTB.Text;
            comReq.blueDotFence = blueDotFenceTB.Text;
            comReq.beaconVenueId = beaconVenueIdTB.Text;

            digitalAPI.InVenueCommissionByAccountSignUp(comReq, serialNumbers);
        }

        private void typeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeCB.Text == "PLACE_BET")
            {
                betTransactionNumbersTB.Enabled = true;
                betTransactionNumbersLBL.Enabled = true;
                addBTN.Enabled = true;
            }
            else
            {
                betTransactionNumbersTB.Enabled = false;
                betTransactionNumbersLBL.Enabled = false;
                addBTN.Enabled = false;
            }

        }

        private void addBTN_Click(object sender, EventArgs e)
        {
            if (betTransactionNumbersTB.Text != "")
                serialNumbers.Add(betTransactionNumbersTB.Text);
        }

        private void clearBTN_Click(object sender, EventArgs e)
        {
            serialNumbers.Clear();
        }
    }
}

