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
using System.Text.RegularExpressions;


namespace DigitalAPI_Forms
{
    public partial class PariSellUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public string tsn = "";
        public PariSellUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }
        
        private void PariSellUC_Load(object sender, EventArgs e)
        {
            meetingDateTB.Text = System.DateTime.Now.ToString("yyyy-MM-dd"); //e.g. 2015-01-21
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            int loop = int.Parse(loopTB.Text);
            dynamic jsonResponse = "";
            for (int i = 0; i < loop; i++)
            {
                if (BetTypeCB.Text == "RUNNING_DOUBLE" || BetTypeCB.Text == "DAILY_DOUBLE")
                {
                    jsonResponse = BetSlipDoubles();
                }

                else if (BetTypeCB.Text == "BIG6")
                {
                    jsonResponse = BetSlipBIG6();
                }

                else if (BetTypeCB.Text == "QUADDIE" || BetTypeCB.Text == "EARLY_QUADDIE")
                {
                    jsonResponse = BetSlipQuaddies();
                }
                else
                {
                    jsonResponse = BetSlipSinglePosition();
                }

                //this is used to try to copy the TSN to memory so we can paste it on other screens e.g. cancel screen
                try
                {
                    tsn = jsonResponse["bets"][0]["ticketSerialNumber"];

                }
                catch (Exception)
                {

                }
            }
        }


        public dynamic BetSlipDoubles()
        {
            //a bit of a hack i know, it's late at night and need to get this thing to work...
            dynamic jsonResponse = "";
            string selectionStr1 = selections1CB.Text;
            string[] select1 = (selectionStr1.Split(','));
            List<object> selectionsList1 = new List<object>();

            selectionsList1 = getSelections(select1);

            string selectionStr2 = selections2CB.Text;
            string[] select2 = (selectionStr2.Split(','));
            List<object> selectionsList2 = new List<object>();

            selectionsList2 = getSelections(select2);

            List<singleLegClass.Bet> singleBetDbl = new List<singleLegClass.Bet>();
            List<singleLegClass.Leg> singleLegDbl = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb2 = new List<singleLegClass.Leg>();
            List<singleLegClass.Position> singlePositionDb1 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb2 = new List<singleLegClass.Position>();


            singlePositionDb1.Add(new singleLegClass.Position
            {
                selections = selectionsList1
            });

            singlePositionDb2.Add(new singleLegClass.Position
            {
                selections = selectionsList2
            });



            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb1
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb2
            });



            singleBetDbl.Add(new singleLegClass.Bet
            {
                betType = BetTypeCB.Text,
                enableMultiplier = Convert.ToBoolean(MultiplierCB.Text),
                stake = stakeTB.Text,
                meetingCode = meetingCodeTB.Text,
                scheduledType = scheduledTypeTB.Text,
                flexi = Convert.ToBoolean(flexiCB.Text),
                meetingDate = meetingDateTB.Text,
                raceNumber = Convert.ToInt32(raceNumberTB.Text),
                type = "PARIMUTUEL",
                legs = singleLegDbl,
                bonusBetToken = bonusBetTokenTB.Text
            });

            singleLegClass.SingleLegBets bet = new singleLegClass.SingleLegBets();

            string request = bet.ToString();
            bet.bets = singleBetDbl;
            bet.transactionId = digitalAPI.returnGUID();
            if (outletTB.Text != "")
                bet.venueId = Convert.ToInt32(outletTB.Text);

            jsonResponse = digitalAPI.pariSingleBet(bet);

            return jsonResponse;
        }

        public dynamic BetSlipBIG6()
        {
            //a bit of a hack i know, it's late at night and need to get this thing to work...
            dynamic jsonResponse = "";
            string selectionStr1 = selections1CB.Text;
            string[] select1 = (selectionStr1.Split(','));
            List<object> selectionsList1 = new List<object>();
            
            selectionsList1 = getSelections(select1);

            string selectionStr2 = selections2CB.Text;
            string[] select2 = (selectionStr2.Split(','));
            List<object> selectionsList2 = new List<object>();

            selectionsList2 = getSelections(select2);

            string selectionStr3 = selections3CB.Text;
            string[] select3 = (selectionStr3.Split(','));
            List<object> selectionsList3 = new List<object>();

            selectionsList3 = getSelections(select3);

            string selectionStr4 = selections4CB.Text;
            string[] select4 = (selectionStr4.Split(','));
            List<object> selectionsList4 = new List<object>();

            selectionsList4 = getSelections(select4);

            string selectionStr5 = selections5CB.Text;
            string[] select5 = (selectionStr5.Split(','));
            List<object> selectionsList5 = new List<object>();


            selectionsList5 = getSelections(select5);

            string selectionStr6 = selections5CB.Text;
            string[] select6 = (selectionStr6.Split(','));
            List<object> selectionsList6 = new List<object>();
            
            selectionsList6 = getSelections(select6);

            List<singleLegClass.Bet> singleBetDbl = new List<singleLegClass.Bet>();
            List<singleLegClass.Leg> singleLegDbl = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb2 = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb3 = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb4 = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb5 = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb6 = new List<singleLegClass.Leg>();
            List<singleLegClass.Position> singlePositionDb1 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb2 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb3 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb4 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb5 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb6 = new List<singleLegClass.Position>();


            singlePositionDb1.Add(new singleLegClass.Position
            {
                selections = selectionsList1
            });

            singlePositionDb2.Add(new singleLegClass.Position
            {
                selections = selectionsList2
            });
            singlePositionDb3.Add(new singleLegClass.Position
            {
                selections = selectionsList3
            });
            singlePositionDb4.Add(new singleLegClass.Position
            {
                selections = selectionsList4
            });
            singlePositionDb5.Add(new singleLegClass.Position
            {
                selections = selectionsList5
            });
            singlePositionDb6.Add(new singleLegClass.Position
            {
                selections = selectionsList6
            });


            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb1
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb2
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb3
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb4
            });
            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb5
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb6
            });

            singleBetDbl.Add(new singleLegClass.Bet
            {
                betType = BetTypeCB.Text,
                enableMultiplier = Convert.ToBoolean(MultiplierCB.Text),
                stake = stakeTB.Text,
                meetingCode = meetingCodeTB.Text,
                scheduledType = scheduledTypeTB.Text,
                flexi = Convert.ToBoolean(flexiCB.Text),
                meetingDate = meetingDateTB.Text,
                raceNumber = Convert.ToInt32(raceNumberTB.Text),
                type = "PARIMUTUEL",
                legs = singleLegDbl,
                bonusBetToken = bonusBetTokenTB.Text
            });

            singleLegClass.SingleLegBets bet = new singleLegClass.SingleLegBets();

            string request = bet.ToString();
            bet.bets = singleBetDbl;
            bet.transactionId = digitalAPI.returnGUID();
            if (outletTB.Text != "")
                bet.venueId = Convert.ToInt32(outletTB.Text);

            jsonResponse = digitalAPI.pariSingleBet(bet);

            return jsonResponse;
        }

        public dynamic BetSlipQuaddies()
        {
            //a bit of a hack i know, it's late at night and need to get this thing to work...
            dynamic jsonResponse = "";
            string selectionStr1 = selections1CB.Text;
            string[] select1 = (selectionStr1.Split(','));
            List<object> selectionsList1 = new List<object>();

            selectionsList1 = getSelections(select1);

            string selectionStr2 = selections2CB.Text;
            string[] select2 = (selectionStr2.Split(','));
            List<object> selectionsList2 = new List<object>();

            selectionsList2 = getSelections(select2);

            string selectionStr3 = selections3CB.Text;
            string[] select3 = (selectionStr3.Split(','));
            List<object> selectionsList3 = new List<object>();

            selectionsList3 = getSelections(select3);

            string selectionStr4 = selections4CB.Text;
            string[] select4 = (selectionStr4.Split(','));
            List<object> selectionsList4 = new List<object>();

            selectionsList4 = getSelections(select4);


            List<singleLegClass.Bet> singleBetDbl = new List<singleLegClass.Bet>();
            List<singleLegClass.Leg> singleLegDbl = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb2 = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb3 = new List<singleLegClass.Leg>();
            List<singleLegClass.Leg> singleLegDb4 = new List<singleLegClass.Leg>();
            List<singleLegClass.Position> singlePositionDb1 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb2 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb3 = new List<singleLegClass.Position>();
            List<singleLegClass.Position> singlePositionDb4 = new List<singleLegClass.Position>();


            singlePositionDb1.Add(new singleLegClass.Position
            {
                selections = selectionsList1
            });

            singlePositionDb2.Add(new singleLegClass.Position
            {
                selections = selectionsList2
            });
            singlePositionDb3.Add(new singleLegClass.Position
            {
                selections = selectionsList3
            });
            singlePositionDb4.Add(new singleLegClass.Position
            {
                selections = selectionsList4
            });



            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb1
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb2
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb3
            });

            singleLegDbl.Add(new singleLegClass.Leg
            {
                positions = singlePositionDb4
            });


            singleBetDbl.Add(new singleLegClass.Bet
            {
                betType = BetTypeCB.Text,
                enableMultiplier = Convert.ToBoolean(MultiplierCB.Text),
                stake = stakeTB.Text,
                meetingCode = meetingCodeTB.Text,
                scheduledType = scheduledTypeTB.Text,
                flexi = Convert.ToBoolean(flexiCB.Text),
                meetingDate = meetingDateTB.Text,
                raceNumber = Convert.ToInt32(raceNumberTB.Text),
                type = "PARIMUTUEL",
                legs = singleLegDbl,
                bonusBetToken = bonusBetTokenTB.Text
            });

            singleLegClass.SingleLegBets bet = new singleLegClass.SingleLegBets();

            string request = bet.ToString();
            bet.bets = singleBetDbl;
            bet.transactionId = digitalAPI.returnGUID();
            if (outletTB.Text != "")
                bet.venueId = Convert.ToInt32(outletTB.Text);


            jsonResponse = digitalAPI.pariSingleBet(bet);

            return jsonResponse;
        }

        public dynamic BetSlipSinglePosition()
        {
            //a bit of a hack i know, it's late at night and need to get this thing to work...
            dynamic jsonResponse = "";
            string selectionStr = selectionsCB.Text;
            string[] select = (selectionStr.Split(','));
            List<object> selectionsList = new List<object>();

            List<singleLegClass.Bet> singleBet = new List<singleLegClass.Bet>();
            List<singleLegClass.Leg> singleLeg = new List<singleLegClass.Leg>();
            List<singleLegClass.Position> singlePosition = new List<singleLegClass.Position>();

            selectionsList = getSelections(select);

            singlePosition.Add(new singleLegClass.Position
            {
                selections = selectionsList
            });


            singleLeg.Add(new singleLegClass.Leg
            {
                positions = singlePosition

            });

            //include secondaryStake in the request only if bet type = EACH_WAY.
            if (BetTypeCB.Text == "EACH_WAY")
            {
                singleBet.Add(new singleLegClass.Bet
                {
                    betType = BetTypeCB.Text,
                    stake = stakeTB.Text,
                    enableMultiplier = Convert.ToBoolean(MultiplierCB.Text),
                    meetingCode = meetingCodeTB.Text,
                    scheduledType = scheduledTypeTB.Text,
                    flexi = Convert.ToBoolean(flexiCB.Text),
                    meetingDate = meetingDateTB.Text,
                    raceNumber = Convert.ToInt32(raceNumberTB.Text),
                    type = "PARIMUTUEL",
                    secondaryStake = secondaryStakeTB.Text,
                    legs = singleLeg,
                    bonusBetToken = bonusBetTokenTB.Text
                });
            }
            else
            {
                singleBet.Add(new singleLegClass.Bet
                {
                    betType = BetTypeCB.Text,
                    stake = stakeTB.Text,
                    enableMultiplier = Convert.ToBoolean(MultiplierCB.Text),
                    meetingCode = meetingCodeTB.Text,
                    scheduledType = scheduledTypeTB.Text,
                    flexi = Convert.ToBoolean(flexiCB.Text),
                    meetingDate = meetingDateTB.Text,
                    raceNumber = Convert.ToInt32(raceNumberTB.Text),
                    type = "PARIMUTUEL",
                    legs = singleLeg,
                    bonusBetToken = bonusBetTokenTB.Text
                });
            }


            singleLegClass.SingleLegBets bet = new singleLegClass.SingleLegBets();

            string request = bet.ToString();
            bet.bets = singleBet;
            bet.transactionId = digitalAPI.returnGUID();
            if (outletTB.Text != "")
                bet.venueId = Convert.ToInt32(outletTB.Text);


            if (bet.bets[0].bonusBetToken == "")
            {
                bet.bets[0].bonusBetToken = null;
            }


            jsonResponse = digitalAPI.pariSingleBet(bet);

            return jsonResponse;
        }
  

        public List<object> getSelections(Array sl)
        {
            List<object> selectionsList = new List<object>();
            foreach (string Sel in sl)
            {
                if (Regex.IsMatch(Sel, @"^[a-zA-Z]+$"))
                {
                    selectionsList.Add(Sel);
                }
                else
                { 
                     selectionsList.Add(Convert.ToInt32(Sel));
                }
            }

            return selectionsList;
        }
        private void BetTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BetTypeCB.Text == "EACH_WAY")
            {
                secondaryStakeTB.Enabled = true;
            }
            else
            {
                secondaryStakeTB.Enabled = false;
            }

            if (BetTypeCB.Text == "QUADDIE" || BetTypeCB.Text == "EARLY_QUADDIE")
            {
                raceNumberTB.Text = "0";
            }           



            if (BetTypeCB.Text == "RUNNING_DOUBLE" || BetTypeCB.Text == "DAILY_DOUBLE")
            {
                selections1CB.Enabled = true;
                selections2CB.Enabled = true;
            }
            else if (BetTypeCB.Text == "QUADDIE" || BetTypeCB.Text == "EARLY_QUADDIE")
            {
                selections1CB.Enabled = true;
                selections2CB.Enabled = true;
                selections3CB.Enabled = true;
                selections4CB.Enabled = true;
            }
            else if (BetTypeCB.Text == "BIG6")
            {
                selections1CB.Enabled = true;
                selections2CB.Enabled = true;
                selections3CB.Enabled = true;
                selections4CB.Enabled = true;
                selections5CB.Enabled = true;
                selections6CB.Enabled = true;
            }
            else
            {
                selections1CB.Enabled = false;
                selections2CB.Enabled = false;
                selections3CB.Enabled = false;
                selections4CB.Enabled = false;
                selections5CB.Enabled = false;
                selections6CB.Enabled = false;
            }
        }

        private void getBonusBetTokensCmd_Click(object sender, EventArgs e)
        {
            digitalAPI.getBonusBetTokens();
        }

        private void copyTSNBTN_Click(object sender, EventArgs e)
        {
            if (tsn.Length > 0)
                Clipboard.SetText(tsn);
            else
                tsn = "";
        }
    }
}
