using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalAPI_Forms;
using System.Runtime.Serialization;

namespace DigitalAPI_Forms
{
    public class AccountActivateClass
    {
        [DataContract]
        public class account
        {
            //[DataMember(Name = "accountNumber", )]
            public string accountNumber { get; set; }
            [DataMember(Name = "channel")]
            public string channel { get; set; }
            [DataMember(Name = "pin")]
            public long pin { get; set; }
            [DataMember(Name = "password")]
            public string password { get; set; }
            [DataMember(Name = "email")]
            public string email { get; set; }
            [DataMember(Name = "surname")]
            public string surname { get; set; }
            [DataMember(Name = "challengeQuestion")]
            public string challengeQuestion { get; set; }
            [DataMember(Name = "challengeAnswer")]
            public string challengeAnswer { get; set; }
        }
    }
}
