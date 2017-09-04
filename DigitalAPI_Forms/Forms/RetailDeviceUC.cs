using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalAPI_Forms
{
    public partial class RetailDeviceUC : UserControl
    {
        DigitalAPItester digitalAPI;
        Configuation config = new Configuation();
        public RetailDeviceUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void setDeviceBTN_Click(object sender, EventArgs e)
        {
            setValues();
            digitalAPI.RetailDevice(config);
        }
        

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            setValues();
            digitalAPI.RetailDeviceDelete(config);
        }

        private void getdeviceBTN_Click(object sender, EventArgs e)
        {
            setValues();
            digitalAPI.RetailDeviceGET(config);
        }
        
        private void setValues()
        {
            config.security_id = securityIdTB.Text;
            config.venue_id = venue_idTB.Text;
            config.window_id = window_idTB.Text;
        }

        public class Configuation
        {
            public string security_id;
            public string venue_id;
            public string window_id;

        }
    }
}
