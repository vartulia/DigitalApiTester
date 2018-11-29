using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace DigitalAPI_Forms
{
    public partial class BundleBetPricingUC : UserControl
    {
        DigitalAPItester digitalAPI;
        List<Leg> EnquiryLegList = new List<Leg>();
        Logger log = new Logger(@"");
        public BundleBetPricingUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }
        

        private void bundlePriceBTN_Click(object sender, EventArgs e)
        {
            //EnquiryLegList.Clear();
            //addPropToEnqury();

            //Bet Details
            string PropId = propositionIdTB.Text;

            BundleEnquiry bundleEnquiry = new BundleEnquiry();

            Bet bet = new Bet();
            bet.type = "FIXED_ODDS";

            List<Bet> betList = new List<Bet>();
            betList.Add(bet);
            bet.legs = EnquiryLegList;

            bundleEnquiry.bets = betList;

            ClientDetails cd = new ClientDetails();
            cd.channel = "WEB";
            cd.jurisdiction = "VIC";

            bundleEnquiry.clientDetails = cd;

            string reqJsontoString = jsonRequestEnquiryToString(bundleEnquiry);
            digitalAPI.enquirybundlePrice(reqJsontoString, false, 1);

            EnquiryLegList.Clear();
            oddsCountLBL.Text = "0 Legs";

        }

        public string jsonRequestEnquiryToString(BundleEnquiry betObject)
        {
            

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BundleEnquiry));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }

        private void addLegBTN_Click(object sender, EventArgs e)
        {
            

        }

        public void addPropToEnqury()
        {
            Leg leg = new Leg();
            string[] propString = propositionIdTB.Text.Split(',');
            string[] oddsString = oddsTB.Text.Split(',');

            //leg.odds = OddsTB.Text;
            leg.type = typeCB.Text;

            Proposition legProposition = new Proposition();
            List<Proposition> legPropositionList = new List<Proposition>();

            try
            {
                for (int i = 0; i < propString.Length; i++)
                {
                    legProposition = propsEnquiry(Convert.ToInt32(propString[i]), Convert.ToDouble(oddsString[i]));
                    legPropositionList.Add(legProposition);
                }
            }
            catch(Exception error)
            {
                log.LogError("General Error: " + error.Message.ToString(), System.Diagnostics.EventLogEntryType.Error);
            }
            

            leg.propositions = legPropositionList;
            EnquiryLegList.Add(leg);
        }



        public class ClientDetails
        {
            public string channel { get; set; }
            public string jurisdiction { get; set; }
        }

        public class Proposition
        {
            public string type { get; set; }
            public int propositionId { get; set; }
            public Odds odds { get; set; }
        }

        [DataContract]
        public class Odds
        {
            [DataMember(Name = "decimal")]
            public double Decimal { get; set; }
        }

        public class Leg
        {
            public string type { get; set; }
            public List<Proposition> propositions { get; set; }
        }

        public class Bet
        {
            public string type { get; set; }
            public List<Leg> legs { get; set; }
        }

        public class BundleEnquiry
        {
            public ClientDetails clientDetails { get; set; }
            public List<Bet> bets { get; set; }
        }

        

        public Proposition propsEnquiry(int prop, double decimalvalue)
        {
            Proposition proposition = new Proposition();
            Odds odds = new Odds();

            proposition.propositionId = prop;
            //proposition.odds = OddsTB.Text;
            proposition.type = "WIN";
            odds.Decimal = decimalvalue;
            proposition.odds = odds;

            return proposition;
        }

        private void addLegBTN_Click_1(object sender, EventArgs e)
        {
            addPropToEnqury();
            propositionIdTB.Clear();
            oddsCountLBL.Text = EnquiryLegList.Count().ToString() + " Legs";
        }
    }
}
