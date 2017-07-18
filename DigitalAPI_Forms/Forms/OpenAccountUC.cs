using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DigitalAPI_Forms
{
    public partial class OpenAccountUC : UserControl
    {

        DigitalAPItester digitalAPI;
        public OpenAccountUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            //Number of accounts to loop
            int noOfAccounts = Convert.ToInt16(loopTB.Text);
            bool isKeno;
            for (int i = 0; i < noOfAccounts; i++)
            {
                OpenAccount oa = new OpenAccount();
                oa.accountPassword = accountPasswordTB.Text;
                oa.accountPin = accountPinTB.Text;
                oa.challengeAnswer = challengeAnswerTB.Text;
                oa.challengeQuestion = challengeQuestionTB.Text;
                oa.channel = channelCB.Text;
                oa.maximumDepositLimit = maximumDepositLimitTB.Text;
                oa.receiveMarketingPromotions = Convert.ToBoolean(receiveMarketingPromotionsTB.Text);
                oa.regulatoryAuthority = regulatoryAuthorityCB.Text;
                oa.venueId = Convert.ToInt32(venueIdTB.Text);

                oa.customerDetails = new CustomerDetails();
                oa.customerDetails.title = TitleTB.Text;
                oa.customerDetails.firstName = firstNameTB.Text;
                oa.customerDetails.lastName = lastNameTB.Text;
                oa.customerDetails.gender = genderCB.Text;
                oa.customerDetails.dateOfBirth = dateOfBirthTB.Text;
                oa.customerDetails.email = emailTB.Text;
                oa.customerDetails.mobileNumber = mobileNumberTB.Text;

                oa.customerDetails.address = new Address();
                oa.customerDetails.address.streetNumber = streetNumberTB.Text;
                oa.customerDetails.address.street = streetTB.Text;
                oa.customerDetails.address.suburb = suburbTB.Text;
                oa.customerDetails.address.postCode = postCodeTB.Text;
                oa.customerDetails.address.state = stateCB.Text;
                oa.customerDetails.address.country = countryTB.Text;


                isKeno = KenoCkB.Checked;
                //random email or lastName so we can automatically create accounts.
                if (emailTB.Text == ("random"))
                {
                    oa.customerDetails.email = RandomString.GenerateRandomString(20) + "@tab.com.au";
                }
                if (lastNameTB.Text == ("random"))
                {
                    oa.customerDetails.lastName = RandomString.GenerateRandomString(20);
                }

                digitalAPI.OpenAccount(oa, isKeno);
            }
        }




        public class Address
        {
            public string streetNumber { get; set; }
            public string street { get; set; }
            public string suburb { get; set; }
            public string postCode { get; set; }
            public string state { get; set; }
            public string country { get; set; }
        }

        public class CustomerDetails
        {
            public string title { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string gender { get; set; }
            public string dateOfBirth { get; set; }
            public string email { get; set; }
            public string mobileNumber { get; set; }
            public Address address { get; set; }
        }

        public class OpenAccount
        {
            public string accountPassword { get; set; }
            public string accountPin { get; set; }
            public string challengeQuestion { get; set; }
            public string challengeAnswer { get; set; }
            public string regulatoryAuthority { get; set; }
            public bool receiveMarketingPromotions { get; set; }
            public string maximumDepositLimit { get; set; }
            public CustomerDetails customerDetails { get; set; }
            public string channel { get; set; }
            public int venueId { get; set; }
        }


        static class RandomString
        {
            /// <summary>
            /// Get random string of 11 characters - includes only char in the string.
            /// </summary>
            /// <returns>Random string.</returns>
            /// 

            static Random rd = new Random();
            internal static string GenerateRandomString(int stringLength)
            {
                const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ'.-";
                char[] chars = new char[stringLength];

                for (int i = 0; i < stringLength; i++)
                {
                    chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
                }

                return new string(chars);
            }


        }


    }
}
