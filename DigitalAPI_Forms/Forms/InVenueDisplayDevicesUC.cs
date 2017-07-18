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
    public partial class InVenueDisplayDevicesUC : UserControl
    {
        DigitalAPItester digitalAPI;

        public InVenueDisplayDevicesUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void getNonCommissionedBTN_Click(object sender, EventArgs e)
        {
            digitalAPI.InVenueNonCommissioned();
        }

        private void getVenueCachesBTN_Click(object sender, EventArgs e)
        {
            string serialNo = serialNoTB.Text;
            digitalAPI.InVenueFindDeviceBySerialNo(serialNo);
        }

        private void wageringTerminalsBTN_Click(object sender, EventArgs e)
        {
            string venueId = venueIdTB.Text;
            digitalAPI.InVenueListDevicebyVenue(venueId);
        }
        
        private void CommissionByVenueId_Click_1(object sender, EventArgs e)
        {
            string venueId = venueIdTB.Text;
            digitalAPI.InVenueCommissionDevicebyVenue(venueId);
        }

        private void getAllDevicesBTN_Click(object sender, EventArgs e)
        {
            digitalAPI.InVenueAllDisplayDevices();
        }

        private void filterByAssetSerialNoBTN_Click(object sender, EventArgs e)
        {
            string serialNo = serialNoTB.Text;
            digitalAPI.InVenueFilterByAssetorSerialNumber(serialNo);
        }
    }
}
