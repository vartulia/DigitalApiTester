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
    public partial class InVenueConfigurationUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public InVenueConfigurationUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            digitalAPI.InVenueConfiguration();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            digitalAPI.InVenueDistributionGroups();
        }

        private void deleteConfigBTN_Click(object sender, EventArgs e)
        {
            string id = idTB.Text;
            digitalAPI.InVenueDeleteConfig(id);

        }

        private void deleteGroupBTN_Click(object sender, EventArgs e)
        {
            string id = idGroupTB.Text;
            digitalAPI.InVenueDeleteConfigGroup(id);
        }
    }
}
