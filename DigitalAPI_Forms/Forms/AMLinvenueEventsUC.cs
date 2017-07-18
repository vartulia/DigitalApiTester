using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;

namespace DigitalAPI_Forms
{
    public partial class AMLinvenueEventsUC : UserControl
    {
        DigitalAPItester digitalAPI;
        public AMLinvenueEventsUC(DigitalAPItester mainForm)
        {
            digitalAPI = mainForm;
            InitializeComponent();
        }

        private void CallApiBTN_Click(object sender, EventArgs e)
        {
            ALMevent events = new ALMevent();

            events.hostTypeId = Convert.ToInt32(hostTypeIdCB.Text);
            events.outletId = outletIdTB.Text;
            events.terminalId = terminalIdTB.Text;
            events.operatorId = operatorIdTB.Text;
            events.terminalTypeId = Convert.ToInt32(terminalTypeIdCB.Text);
            events.sessionId = sessionIdTB.Text;
            events.accountId = accountIdTB.Text;
            events.description = descriptionTB.Text;
            events.operatorName = operatorNameTB.Text;

            events.createdTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            events.businessDate = DateTime.UtcNow.ToString("yyyy-MM-dd");

            string reqJsontoString = jsonRequestToString(events);
            digitalAPI.AMLevent(reqJsontoString, 1);
        }

        public string jsonRequestToString(ALMevent betObject)
        {

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ALMevent));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }

        public string jsonRleaseRequestToString(release betObject)
        {

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(release));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }
        public string jsonFinaliseRequestToString(finalise betObject)
        {

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(finalise));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }
        public string jsonReleaseHostToString(HostRelease betObject)
        {

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(HostRelease));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }
        public string setSSCavailbilityToString(SSCavailable betObject)
        {

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(SSCavailable));

            ser.WriteObject(stream1, betObject);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            string postData = sr.ReadToEnd();

            return postData;
        }
        public class ALMevent
        {
            public int hostTypeId { get; set; }
            public string outletId { get; set; }
            public string terminalId { get; set; }
            public string operatorId { get; set; }
            public int terminalTypeId { get; set; }
            public string sessionId { get; set; }
            public string accountId { get; set; }
            public string description { get; set; }
            public string operatorName { get; set; }
            public string createdTime { get; set; }
            public string businessDate { get; set; }
            
        }



        //release class
        public class release
        {
            public string referenceNumber { get; set; }
            public string operatorId { get; set; }
            public string resolution { get; set; }
            public string referenceType { get; set; }
        }

        //finalise class
        public class finalise
        {
            public string WTRId { get; set; }
            public string SMRId { get; set; }
            public string TTRId { get; set; }
            public string operatorId { get; set; }
            public string comment { get; set; }
        }

        //HostRelease class
        public class HostRelease
        {
            public string resolution { get; set; }
        }

        //SSC Available
        public class SSCavailable
        {
            public bool SSC_AVAILABLE { get; set; }
        }

        private void getAllEventsBTN_Click(object sender, EventArgs e)
        {
            digitalAPI.getAllEvents(1);

        }

        private void ReleaseBTN_Click(object sender, EventArgs e)
        {
            release rel = new release();
            int eventId = Convert.ToInt32(eventIdTB.Text);
            rel.operatorId = operatorReleaseIdTB.Text;
            rel.referenceNumber = referenceNumberTB.Text;
            rel.resolution = resolutionReleaseCB.Text;
            rel.referenceType = referenceTypeCB.Text;

            string reqJsontoString = jsonRleaseRequestToString(rel);
            digitalAPI.AMLrelease(reqJsontoString, eventId, 1);
        }

        private void finaliseTB_Click(object sender, EventArgs e)
        {
            int eventId = Convert.ToInt32(eventIdFinaliseTB.Text);            

            finalise fin = new finalise();
            fin.operatorId = operatorIdFinaliseTB.Text;
            fin.SMRId = SMRIdTB.Text;
            fin.TTRId = TTRIdTB.Text;
            fin.WTRId = WTRIdTB.Text;
            fin.comment = commentTB.Text;
            string reqJsontoString = jsonFinaliseRequestToString(fin);
            digitalAPI.AMLfinalise(reqJsontoString, eventId, 1);

        }
        

        private void hostReleaseBTN_Click_1(object sender, EventArgs e)
        {
            int eventId = Convert.ToInt32(eventIdHostReleaseTB.Text);

            HostRelease hr = new HostRelease();
            hr.resolution = resolutionHostReleaseCB.Text;

            string reqJsontoString = jsonReleaseHostToString(hr);
            digitalAPI.AMLHostrelease(reqJsontoString, eventId, 1);

        }

        private void SSCunavailableBTN_Click(object sender, EventArgs e)
        {
            digitalAPI.getSSCavailability(1);
        }

        private void availableBTN_Click(object sender, EventArgs e)
        {
            SSCavailable SSCavail = new SSCavailable();
            SSCavail.SSC_AVAILABLE = true;

            string reqJsontoString = setSSCavailbilityToString(SSCavail);
            digitalAPI.setSSCavailability(reqJsontoString, 1);
        }

        private void unavailableBTN_Click(object sender, EventArgs e)
        {
            SSCavailable SSCavail = new SSCavailable();
            SSCavail.SSC_AVAILABLE = false;

            string reqJsontoString = setSSCavailbilityToString(SSCavail);
            digitalAPI.setSSCavailability(reqJsontoString, 1);
        }

        private void pollBTN_Click(object sender, EventArgs e)
        {
            int poll = Convert.ToInt32(pollTB.Text);
            digitalAPI.SSCavailabilityPoll(poll);
        }

        private void AMLinvenueEventsUC_Load(object sender, EventArgs e)
        {
            string clientId = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
            string clientSecret = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
            string request = "client_id=" + clientId + "&client_secret=" + clientSecret + "&grant_type=client_credentials&claims[user.surname]=Vartuli&claims[user.givenName]=Anthony&claims[user.fullName]=Anthony%20Vartuli&claims[user.id]=Anthony.Vartuli%40example.com&claims[ssc-aml.permissions][read][unprocessedEvents]=true&claims[ssc-aml.permissions][write][unprocessedEvents]=true&claims[ssc-aml.permissions][read][processedEvents]=true&claims[ssc-aml.permissions][write][processedEvents]=true&claims[ssc-aml.permissions][read][config]=true&claims[ssc-aml.permissions][write][config]=true";
            digitalAPI.AuthenticateOauth(clientId, clientSecret, request);
        }
    }
}
