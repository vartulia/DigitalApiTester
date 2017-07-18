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
    public partial class InVenueTerminalsUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public InVenueTerminalsUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void connectBTN_Click(object sender, EventArgs e)
        {
           
            terminal term = new terminal();

            term.venue = venueIdTB.Text;
            term.hardware = hardwareVerTB.Text;
            term.memory = memoryTB.Text;
            term.os = osTB.Text;
            term.terminalVer = termVersionTB.Text;

            digitalAPI.InVenueConnect(term);
        }

        public class terminal
        {
            public string venue;
            public string hardware;
            public string memory;
            public string os;
            public string terminalVer;
            public string terminalNo;        }

        private void connectBTN_Click_1(object sender, EventArgs e)
        {

            int loop = Convert.ToInt32(loopTB.Text);

            for (int i =0; i < loop; i++)
            { 
            terminal term = new terminal();

            term.venue = venueIdTB.Text;
            term.hardware = hardwareVerTB.Text;
            term.memory = memoryTB.Text;
            term.os = osTB.Text;
            term.terminalVer = termVersionTB.Text;
            term.terminalNo = terminalNoTB.Text;

            digitalAPI.InVenueConnect(term);
            }
        }

        private void cacheBTN_Click(object sender, EventArgs e)
        {
            int loop = Convert.ToInt32(loopTB.Text);

            for (int i = 0; i < loop; i++)
            {
                terminal term = new terminal();

                term.venue = venueIdTB.Text;
                term.hardware = hardwareVerTB.Text;
                term.memory = memoryTB.Text;
                term.os = osTB.Text;
                term.terminalVer = termVersionTB.Text;
                term.terminalNo = terminalNoTB.Text;

                digitalAPI.InVenueCache(term);
            }
        }

        private void pollBTN_Click(object sender, EventArgs e)
        {
            int loop = Convert.ToInt32(loopTB.Text);

            for (int i = 0; i < loop; i++)
            {
                terminal term = new terminal();

                term.venue = venueIdTB.Text;
                term.hardware = hardwareVerTB.Text;
                term.memory = memoryTB.Text;
                term.os = osTB.Text;
                term.terminalVer = termVersionTB.Text;
                term.terminalNo = terminalNoTB.Text;

                digitalAPI.InVenueCachePoll(term);
            }
        }
    }
}
