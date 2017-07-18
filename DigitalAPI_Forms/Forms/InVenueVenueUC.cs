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
    public partial class InVenueVenueUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public InVenueVenueUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void getVenueListBTN_Click(object sender, EventArgs e)
        {
            digitalAPI.InVenueVenueList();
        }
        
        private void getVenueCachesBTN_Click(object sender, EventArgs e)
        {
            string id = venueIdTB.Text;
            digitalAPI.InVenueVenueCaches(id);
        }

        private void wageringTerminalsBTN_Click(object sender, EventArgs e)
        {
            string id = venueIdTB.Text;
            digitalAPI.InVenueVenueWageringTerminals(id);
        }
    }
}
