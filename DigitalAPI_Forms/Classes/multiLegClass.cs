using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalAPI_Forms;
using System.Runtime.Serialization;

namespace DigitalAPI_Forms
{
    class multiLegClass
    {
        public class Position
        {
            [DataMember(Name = "selections")]
            public List<int> selections { get; set; }
        }

        public class Leg
        {
            [DataMember(Name = "positions")]
            public List<Position> positions { get; set; }
        }

        public class Bet
        {
            [DataMember(Name = "stake")]
            public string stake { get; set; }
            [DataMember(Name = "type")]
            public string type { get; set; }
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
        }

        public class RootObject
        {
            [DataMember(Name = "bets")]
            public List<Bet> bets { get; set; }
            [DataMember(Name = "transactionId")]
            public string transactionId { get; set; }
        }

    }
}
