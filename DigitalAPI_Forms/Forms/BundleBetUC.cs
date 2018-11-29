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
    public partial class BundleBetUC : UserControl
    {
        DigitalAPItester digitalAPI;
        List<Leg> legList = new List<Leg>();


        public BundleBetUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void SellBetBTN_Click(object sender, EventArgs e)
        {
            //Bet Details
            string Stake = StakeTB.Text;
            bool enableMultiplier = Convert.ToBoolean(MultiplierCB.Text);
            string Bettype = BetTypeCB.Text;
            string PropId = propositionIdTB.Text;
            string Odds = OddsTB.Text;
            //Get a New generated UUID
            string guild = returnGUID();


            BundleBets bundlebets = new BundleBets();

            Bet bet = new Bet();
            if (BetTypeCB.Text == "BUNDLE_MULTI")
            {
                bet.combinedPrice = combinedPriceTB.Text;
            }
            bet.stake = StakeTB.Text;
            if (BetTypeCB.Text != "SAME_GAME_MULTI")
            {
                bet.enableMultiplier = enableMultiplier;
            }

            bet.type = "FIXED_ODDS";

            List<Bet> betList = new List<Bet>();
            betList.Add(bet);
            bet.legs = legList;

            bundlebets.bets = betList;
            bundlebets.transactionId = guild;
            string reqJsontoString = jsonRequestToString(bundlebets);

            digitalAPI.bundleBet(reqJsontoString, false, 1);


            if (retainBetCKB.Checked != true)
            {
                legList.Clear();
                propCountLBL.Text = "0 Legs.";
            }
        }



        public string jsonRequestToString(BundleBets betObject)
        {

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BundleBets));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }

        public string returnGUID()
        {
            Guid g;
            // Create and display the value of two GUIDs.
            g = Guid.NewGuid();
            string guild = System.Guid.NewGuid().ToString();
            return guild;
        }

        public Proposition props(int prop)
        {
            Proposition proposition = new Proposition();


            if (BetTypeCB.Text == "SAME_GAME_MULTI")
            {
                proposition.propositionId = prop;
                proposition.type = "WIN";
            }
            else
            {
                proposition.propositionId = prop;
                proposition.odds = OddsTB.Text;
                proposition.type = "WIN";
            }

            return proposition;
        }


        private void addLegBTN_Click(object sender, EventArgs e)
        {

            Leg leg = new Leg();
            string[] propString = propositionIdTB.Text.Split(',');
            if (BetTypeCB.Text == "BUNDLE")
            {
                leg.odds = OddsTB.Text;
                leg.type = "BUNDLE";

                Proposition legProposition = new Proposition();
                List<Proposition> legPropositionList = new List<Proposition>();

                foreach (var prop in propString)
                {
                    legProposition = props(Convert.ToInt32(prop));
                    legPropositionList.Add(legProposition);

                }
                leg.propositions = legPropositionList;
                legList.Add(leg);
            }
            if (BetTypeCB.Text == "SAME_GAME_MULTI")
            {
                leg.odds = OddsTB.Text;
                leg.type = "SAME_GAME_MULTI";

                Proposition legProposition = new Proposition();
                List<Proposition> legPropositionList = new List<Proposition>();

                foreach (var prop in propString)
                {
                    legProposition = props(Convert.ToInt32(prop));
                    legPropositionList.Add(legProposition);

                }
                leg.propositions = legPropositionList;
                legList.Add(leg);
            }



            else if (BetTypeCB.Text == "BUNDLE_MULTI")
            {
                leg.odds = OddsTB.Text;
                if (propString.Length > 1)
                {
                    leg.type = "BUNDLE";
                    Proposition legProposition = new Proposition();
                    List<Proposition> legPropositionList = new List<Proposition>();

                    foreach (var prop in propString)
                    {
                        legProposition = props(Convert.ToInt32(prop));
                        legPropositionList.Add(legProposition);

                    }
                    leg.propositions = legPropositionList;
                    legList.Add(leg);
                }

                else
                {
                    leg.propositionId = Convert.ToInt32(propositionIdTB.Text);
                    leg.type = "WIN";
                    legList.Add(leg);

                }
            }

            propCountLBL.Text = legList.Count().ToString() + " Props."; // add leg count to screen 
            propositionIdTB.Text = "";
        }

        private void BetTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BetTypeCB.Text == "SAME_GAME_MULTI")
            {
                MultiplierCB.Visible = false;
                label10.Visible = false;
                combinedPriceTB.Visible = false;
                label7.Visible = false;

            }
            else
            {
                    MultiplierCB.Visible = true;
                    label10.Visible = true;
                    combinedPriceTB.Visible = true;
                    label7.Visible = true;
            }
        }


        [DataContract]
        public class Proposition
        {

            [DataMember]
            public string type { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public int propositionId { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string odds { get; set; }
        }


        public class Leg
        {
            public string type { get; set; }
            public int propositionId { get; set; }
            public string odds { get; set; }
            public List<Proposition> propositions { get; set; }
        }


        [DataContract]
        public class Bet
        {
            [DataMember]
            public string type { get; set; }
            [DataMember]
            public string stake { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public bool enableMultiplier { get; set; }
            [DataMember(EmitDefaultValue = false)]
            public string combinedPrice { get; set; }
            [DataMember]
            public List<Leg> legs { get; set; }
        }


        public class BundleBets
        {
            public List<Bet> bets { get; set; }
            public string transactionId { get; set; }

        }


    }
}

