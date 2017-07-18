using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalAPI_Forms;
using System.Runtime.Serialization;

namespace DigitalAPI_Forms
{
    public class singleLegClass
    {
        [DataContract]
        public class Position
        {
            [DataMember(Name = "selections")]
            public List<object> selections { get; set; }
        }
        [DataContract]
        public class Leg
        {
            [DataMember(Name = "positions")]
            public List<Position> positions { get; set; }
        }
        [DataContract]
        public class Bet
        {
            [DataMember(Name = "enableMultiplier")]
            public bool enableMultiplier { get; set; }
            [DataMember(Name = "stake")]
            public string stake { get; set; }
            [DataMember(Name = "type")]
            public string type { get; set; }
            [DataMember(Name = "bonusBetToken")]
            public string bonusBetToken { get; set; }
            [DataMember(Name = "meetingCode")]
            public string meetingCode { get; set; }
            [DataMember(Name = "scheduledType")]
            public string scheduledType { get; set; }
            [DataMember(Name = "raceNumber")]
            public int raceNumber { get; set; }
            [DataMember(Name = "meetingDate")]
            public string meetingDate { get; set; }
            [DataMember(Name = "betType")]
            public string betType { get; set; }
            [DataMember(Name = "flexi")]
            public bool flexi { get; set; }
            [DataMember(Name = "legs")]
            public List<Leg> legs { get; set; }
            [DataMember(Name = "secondaryStake", EmitDefaultValue = false)]
            public string secondaryStake { get; set; }
        }
        [DataContract]
        public class SingleLegBets
        {
            [DataMember(Name = "bets")]
            public List<Bet> bets { get; set; }
            [DataMember(Name = "transactionId")]
            public string transactionId { get; set; }
            [DataMember(Name = "venueId",EmitDefaultValue =true)]
            public int venueId { get; set; }
        }

    }
}
