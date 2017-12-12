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

namespace DigitalAPI_Forms
{
    public partial class DigitalAPItester : Form
    {

        static string token;
        //static string AMLtoken = "5065157db002f1d9f70cbf8f1489fb8806748308";
        static string AMLtoken = "e60a776ce4abb0525744986edd002c4acba829ea";
        static string accountNo;
        static bool oAuthMode;

        public string clientId = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
        public string clientSecret = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
        

        Logger log = new Logger(@"");

        public string amount;
        public int major;
        public int minor;
        public string cacheURL;


        public DigitalAPItester()
        {
            InitializeComponent();
        }
        private void DigitalAPItester_Load(object sender, EventArgs e)
        {
            populateMSGbox();
            ActManCallsCB.Text = "Authenticate";

            if (ActManCallsCB.Text == "Authenticate")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AuthenticateUC usr1 = new AuthenticateUC(this);
                usr1.Show();
                panel1.Controls.Add(usr1);
            }

        }
        private void populateMSGbox()
        {
            ActManCallsCB.Items.Add("Authenticate");
            ActManCallsCB.Items.Add("AuthenticateOAuth");
            ActManCallsCB.Items.Add("AccountBalance");
            ActManCallsCB.Items.Add("AccountPreferences");
            ActManCallsCB.Items.Add("AccountStatement");
            ActManCallsCB.Items.Add("AccountStatementEnhanced");
            ActManCallsCB.Items.Add("AccountStatementRecent");
            ActManCallsCB.Items.Add("AccountCreation");
            ActManCallsCB.Items.Add("ForgotPassword");
            ActManCallsCB.Items.Add("ResetPin");
            ActManCallsCB.Items.Add("Eft-registration");
            ActManCallsCB.Items.Add("CardOrdering");
            ActManCallsCB.Items.Add("EmailVerification");
            ActManCallsCB.Items.Add("GetAccountDetails");
            ActManCallsCB.Items.Add("ActivateAccount");
            ActManCallsCB.Items.Add("UnlockAccount");
            //ActManCallsCB.Items.Add("DepositEnquiry");
        }
        public static string FormatJson(string str)
        {
            const string INDENT_STRING = "    ";
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            var els = Enumerable.Range(0, ++indent);
                            foreach (var el in els)
                                sb.Append(INDENT_STRING);
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            var els = Enumerable.Range(0, --indent);
                            foreach (var el in els)
                                sb.Append(INDENT_STRING);
                            //(item => sb.Append(INDENT_STRING));
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && str[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            var els = Enumerable.Range(0, indent);
                            foreach (var el in els)
                                sb.Append(INDENT_STRING);
                            //.ForEach(item => sb.Append(INDENT_STRING));
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(" ");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
        public string returnGUID()
        {
            Guid g;
            // Create and display the value of two GUIDs.
            g = Guid.NewGuid();
            string guild = System.Guid.NewGuid().ToString();
            return guild;
        }

        public void Authenticate(string AccountNo, string Password, string Channel, int loop)
        {
            accountNo = AccountNo;
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/authenticate");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues. using System.Net.Security;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        string postData = "{" +
                                              "\"accountNumber\":" + AccountNo + "," +
                                              "\"password\": \"" + Password + "\"," +
                                              "\"channel\":\"" + Channel + "\"" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        try
                        {

                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                requestWriter.Write(postData);
                            }
                            requestWriter.Close();
                        }

                        catch (Exception e)
                        {
                            log.LogError("Authenticate call: Response: \r\n" + e, System.Diagnostics.EventLogEntryType.Error);
                            ResponseTB.Text = "An error has occured, REASON: " + e.Message.ToString();
                            break;
                        }


                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Authenticate call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Authenticate call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Authenticate call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);

                        try
                        {
                            token = response["authentication"]["token"];
                            oAuthMode = false;

                            ResponseTB.Text = FormatJson(ret.ToString());
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                            resStream.Close();
                            reader.Close();
                        }
                        catch (Exception e)
                        {
                            log.LogError("Authenticate call: Response: \r\n" + e, System.Diagnostics.EventLogEntryType.Error);
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                            resStream.Close();
                            reader.Close();
                        }
                    }
                }
                catch (WebException error)
                {
                    int statusCode = PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("Authenticate call: Details of reason: [] {0}" + error.Status, System.Diagnostics.EventLogEntryType.Error);
                }
                catch (Exception error)
                {
                    ResponseTB.Text = error.Message.ToString();
                }
            }
        }
        public void AuthenticateOauthABACUS(string AccountNo, string Password, string clientId, string clientSecret, string operatorNo,  int loop)
        {
            accountNo = AccountNo;
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/oauth/token");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                webRequest.Credentials = CredentialCache.DefaultCredentials;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/x-www-form-urlencoded";
                        string Request = "client_id="+ clientId +"&client_secret=" +clientSecret +"&grant_type=password&claims[operator.terminal]="+operatorNo+"&username="+ AccountNo+"&password="+ Password +"&pin_authentication=true";
                        byte[] byteArray = Encoding.ASCII.GetBytes(Request);


                        requestTB.Text = "Method: " + webRequest.Method + "\r\n" + 
                                         "URI: "+   uri.ToString() + "\r\n" + //print request to screen
                                          "ContentType: " + webRequest.ContentType + "\r\n" +
                                         "\r\n" +
                                         "Request: " + Request + "\r\n";
                           
                        Stream dataStream = webRequest.GetRequestStream();
                        dataStream.Write(byteArray, 0, byteArray.Length);

                        dataStream.Close();

                        //WebResponse response = webRequest.GetResponse();
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        ResponseTB.Text = FormatJson(ret);


                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        token = response["access_token"];
                        oAuthMode = true;

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    if (error.Response !=null)
                    {
                        var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                        ResponseTB.Text = FormatJson(resp.ToString());
                        ResponseTB.Refresh();
                        log.LogError("AuthenticateOauth call: Details of reason: [] {0}" + error.Status, System.Diagnostics.EventLogEntryType.Error);
                    }
                    else
                    {
                        ResponseTB.Text = error.Message.ToString();
                    }
                    
                }
            }
        }
        public void AuthenticateOauth(string clientId, string clientSecret, string request)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/oauth/token");

            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            // authentication
            var cache = new CredentialCache();
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    byte[] byteArray = Encoding.ASCII.GetBytes(request);


                    requestTB.Text = "Method: " + webRequest.Method + "\r\n" +
                                     "URI: " + uri.ToString() + "\r\n" + //print request to screen
                                      "ContentType: " + webRequest.ContentType + "\r\n" +
                                     "\r\n" +
                                     "Request: " + request + "\r\n";

                    Stream dataStream = webRequest.GetRequestStream();
                    dataStream.Write(byteArray, 0, byteArray.Length);

                    dataStream.Close();

                    //WebResponse response = webRequest.GetResponse();
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    ResponseTB.Text = FormatJson(ret);


                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    token = response["access_token"];
                    oAuthMode = true;

                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                if (error.Response != null)
                {
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("AuthenticateOauth call: Details of reason: [] {0}" + error.Status, System.Diagnostics.EventLogEntryType.Error);
                }
                else
                {
                    ResponseTB.Text = error.Message;
                }

            }
        }
       
        public void accountBalance(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/balance");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AccountBalance call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AccountBalance call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AccountBalance call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("accountBalance call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void scanRetailTicket_EnquiryLoggedIn(int loop, string tsn, string pin)
        {
            requestTB.Text = "";
            requestTB.Refresh();
            ResponseTB.Text = "";
            ResponseTB.Refresh();

            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/ticket-enquiry/");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string longitudeST = "40";
                        string latitudeST = "45";
                        string undertaintyST = "20";

                        string postData = "{" +
                                 "\"ticketSerialNumber\":\"" + tsn + "\"," +
                                  "\"location\":" +
                                  "{" +
                                      "\"longitude\":" + longitudeST + "," +
                                      "\"latitude\":" + latitudeST + "," +
                                      "\"uncertainty\":" + undertaintyST +
                                        "}" +
                                    "}";


                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("scanRetailTicket_Enquiry call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("scanRetailTicket_Enquiry call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("scanRetailTicket_Enquiry call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());

                        //eToken = response["emailVerificationToken"];
                        //ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    if (error.Response != null)
                    {
                        var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                        ResponseTB.Text = FormatJson(resp.ToString());
                        ResponseTB.Refresh();
                        log.LogError("scanRetailTicket_Enquiry call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);

                    }
                }
            }
        }

        public void scanRetailTicket_EnquiryNotLoggedIn(int loop, string tsn, string pin, string jurisdiction)
        {
            requestTB.Text = "";
            requestTB.Refresh();
            ResponseTB.Text = "";
            ResponseTB.Refresh();

            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/" + jurisdiction + "/ticket-enquiry/");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string longitudeST = "40";
                        string latitudeST = "45";
                        string undertaintyST = "20";

                        string postData = "{" +
                                 "\"ticketSerialNumber\":\"" + tsn + "\"," +
                                  "\"location\":" +
                                  "{" +
                                      "\"longitude\":" + longitudeST + "," +
                                      "\"latitude\":" + latitudeST + "," +
                                      "\"uncertainty\":" + undertaintyST +
                                        "}" +
                                    "}";


                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("scanRetailTicket_Enquiry call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("scanRetailTicket_Enquiry call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("scanRetailTicket_Enquiry call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());

                        //eToken = response["emailVerificationToken"];
                        //ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    if (error.Response != null)
                    {
                        var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                        ResponseTB.Text = FormatJson(resp.ToString());
                        ResponseTB.Refresh();
                        log.LogError("scanRetailTicket_Enquiry call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);

                    }
                }
            }
        }


        public string scanRetailTicket_Pay(int loop, string tsn, string pin)
        {
            {
                requestTB.Text = "";
                requestTB.Refresh();
                ResponseTB.Text = "";
                ResponseTB.Refresh();

                string eToken = "";

                for (int i = 0; i < loop; i++)
                {

                    string ret = string.Empty;
                    StreamWriter requestWriter;
                    WebClient webClient = new WebClient();
                    Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/ticket-redeem/");

                    var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                    // authentication
                    var cache = new CredentialCache();
                    cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                    webRequest.Credentials = cache;
                    //This will ignore certificate type issues.
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                    try
                    {
                        if (webRequest != null)
                        {
                            webRequest.Method = "POST";
                            webRequest.ServicePoint.Expect100Continue = false;
                            webRequest.Timeout = 20000;
                            webRequest.ContentType = "application/json";
                            if (oAuthMode == true)
                            {
                                webRequest.Headers.Add("Authorization", "Bearer " + token);
                            }
                            else
                            {
                                webRequest.Headers["tabcorpauth"] = token;
                            }

                            string longitudeST = "40";
                            string latitudeST = "45";
                            string undertaintyST = "20";

                            string postData = "{" +
                                     "\"ticketSerialNumber\":\"" + tsn + "\"," +
                                      "\"location\":" + 
                                      "{" +
                                          "\"longitude\":" + longitudeST + "," +
                                          "\"latitude\":" + latitudeST + "," +
                                          "\"uncertainty\":" + undertaintyST +
                                            "}" +
                                        "}";


                            requestTB.Text = FormatJson(postData);
                            //POST the data.
                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                requestWriter.Write(postData);
                            }
                            requestWriter.Close();

                            DateTime start = DateTime.Now;
                            if (LogMsgCKB.Checked)
                            {
                                log.LogError("scanRetailTicket_Pay call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                            }
                            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                            //print the response status code
                            int statusCode = getResponseCode(resp);
                            PrintStatusCode(resp, statusCode);

                            TimeSpan timeItTook = DateTime.Now - start;

                            Stream resStream = resp.GetResponseStream();
                            StreamReader reader = new StreamReader(resStream);
                            ret = reader.ReadToEnd();
                            requestWriter.Close();
                            if (LogMsgCKB.Checked)
                            {
                                log.LogError("scanRetailTicket_Pay call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                                log.LogError("scanRetailTicket_Pay call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                            }

                            var jss = new JavaScriptSerializer();
                            dynamic response = jss.DeserializeObject(ret);
                            ResponseTB.Text = FormatJson(ret.ToString());

                            //eToken = response["emailVerificationToken"];
                            //ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                        }
                    }
                    catch (WebException error)
                    {
                        PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                        if (error.Response != null)
                        {
                            var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                            ResponseTB.Text = FormatJson(resp.ToString());
                            ResponseTB.Refresh();
                            log.LogError("scanRetailTicket_Pay call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);

                        }
                    }
                }
                return eToken;
            }
        }


        public void getAccountPreferences(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/preferences");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);
                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getAccountPreferences call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getAccountPreferences call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("getAccountPreferences call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("getAccountPreferences call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void AccountStatement(int rows, string type, string status, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/statement?count=" + rows + "&type=" + type + "&status=" + status);
                //api/accounts/statement?count=2&type=ALL&status=ALL
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AccountStatement call: Request: " + uri, System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AccountStatement call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AccountStatement call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());

                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("AccountStatement call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
                catch (Exception unknownError)
                {
                    ResponseTB.Text = unknownError.Message.ToString();
                }
            }
        }
        public void AccountStatementEnhanced(string statementType, string transFilter, string OldTime, string NewTime, string countRow, int loop)
        {
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/enhanced-statement?fromDate=" + OldTime + "&toDate=" + NewTime + "&count=" + countRow + "&type=" + statementType + "&status=" + transFilter);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AccountStatementEnhanced call: Request: " + uri, System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AccountStatementEnhanced call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AccountStatementEnhanced call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());

                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("AccountStatementEnhanced call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
                catch (Exception unknownError)
                {
                    ResponseTB.Text = unknownError.Message.ToString();
                }
            }
        }
        public void GetRecentTransactions(int noOfTrans, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/transactions?count=" + noOfTrans);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getRecentTransactions call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getRecentTransactions call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("getRecentTransactions call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("getRecentTransactions call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void GetAccountDetails(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getAccountDetails call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        //requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getAccountDetails call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("getAccountDetails call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        //ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : ""); + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("getAccountDetails call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void OpenAccount(OpenAccountUC.OpenAccount oa, bool isKeno)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = null;
            if (isKeno == true)
            {
                uri = new Uri(AddressCB.Text + "/v1/account-service/keno/accounts");
            }
            else
            {
                uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts");
            }

            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
            StreamWriter requestWriter;

            // authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(OpenAccountUC.OpenAccount));

            ser.WriteObject(stream1, oa);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    string postData = sr.ReadToEnd();
                    requestTB.Text = FormatJson(postData);

                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("OpenAccount call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    TimeSpan timeItTook = DateTime.Now - start;

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    requestWriter.Close();

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("OpenAccount call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("OpenAccount call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    log.LogError("OpenAccount call: " + "AccountId:" + response["accountId"] + " " + "Jurisdiction:" + response["jurisdiction"] + " PIN:" + response["accountPin"] + " Password:" + oa.accountPassword, System.Diagnostics.EventLogEntryType.SuccessAudit);
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("OpenAccount call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void ForgotPassword(string AccountNo, int Pin, string Channel, string Surname, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + AccountNo + "/challenge-question?channel=" + Channel + "&pin=" + Pin + "&surname=" + Surname);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ForgotPassword call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        //requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ForgotPassword call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("ForgotPassword call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        //ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : ""); + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("ForgotPassword call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void ForgotPassword_DOB(string AccountNo, string Dob, string Channel, string Surname, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + AccountNo + "/challenge-question?channel=" + Channel + "&dateOfBirth=" + Dob + "&surname=" + Surname);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ForgotPassword_DOB call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        //requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ForgotPassword_DOB call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("ForgotPassword_DOB call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        //ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : ""); + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("ForgotPassword_DOB call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void ForgotPassword_Challenge(string AccountNo, string cAnswer, string password, string Channel, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + AccountNo + "/password");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "PUT";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        string postData = "{" +
                                      "\"channel\":\"" + Channel + "\"," +
                                      "\"challengeAnswer\":\"" + cAnswer + "\"," +
                                      "\"password\":\"" + password + "\"" +
                                        "}";


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ForgotPassword_Challenge call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ForgotPassword_Challenge call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("ForgotPassword_Challenge call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("ForgotPassword_Challenge call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void ResetPin(string password, string Pin, int loop)
        {

            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/pin");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "PUT";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        string channel = "WEB";
                        string postData = "{" +
                                      "\"password\":\"" + password + "\"," +
                                      "\"channel\":\"" + channel + "\"," +
                                      "\"pin\":" + Pin + "" +

                                        "}";


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("ResetPin call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("ResetPin call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("ResetPin call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void EFT_Reg(string bsb, string acctNo, string acctName, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/eft-registration");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        string postData = "{" +
                                      "\"bsb\":\"" + bsb + "\"," +
                                      "\"bankAccountNumber\":\"" + acctNo + "\"," +
                                      "\"bankAccountName\":\"" + acctName + "\"," +
                                      "\"transactionId\":\"" + guild + "\"" +
                                        "}";


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("EFT_Reg call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("EFT_Reg call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("EFT_Reg call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        //ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("EFT_Reg call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void CardOrdering(string Password, string Channel, int loop)
        {
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/card");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }


                        string postData = "{" +
                                              "\"password\": \"" + Password + "\"," +
                                              "\"channel\":\"" + Channel + "\"" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("CardOrdering call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("CardOrdering call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("CardOrdering call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }


                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("CardOrdering call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public string SendVerificationEmail(int loop)
        {
            string eToken = "";
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/email-verification");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }


                        string postData = "{" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("SendVerificationEmail call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("SendVerificationEmail call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("SendVerificationEmail call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }


                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());

                        //eToken = response["emailVerificationToken"];
                        //ResponseTB.Text = "Status: " + resp.StatusCode.ToString();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("SendVerificationEmail call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return eToken;
        }
        public void VerifyEmailAddress(string Channel, string emailToken, int loop)
        {
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + accountNo + "/verify-email");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "PUT";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "{" +
                                              "\"channel\":\"" + Channel + "\"," +
                                              "\"emailVerificationToken\":\"" + emailToken + "\"" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("VerifyEmailAddress call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("VerifyEmailAddress call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("VerifyEmailAddress call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }


                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Text = "Status: " + resp.StatusCode.ToString();

                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("VerifyEmailAddress call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void UnlockAccountChallengeAnswer(string AccountNo, int Pin, string Channel, string Surname, string cAnswer, string password, int loop)
        {
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + AccountNo + "/unlock");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        //if (oAuthMode == true)
                        //{
                        //    webRequest.Headers.Add("Authorization", "Bearer " + token);
                        //}
                        //else
                        //{
                        //    webRequest.Headers["tabcorpauth"] = token;
                        //}

                        string postData = "{" +
                                              "\"channel\":\"" + Channel + "\"," +
                                              "\"pin\":\"" + Pin + "\"," +
                                              "\"surname\":\"" + Surname + "\"," +
                                              "\"password\":\"" + password + "\"," +
                                              "\"challengeAnswer\":\"" + cAnswer + "\"" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("UnlockAccount call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("UnlockAccount call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("UnlockAccount call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }


                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Text = "Status: " + resp.StatusCode.ToString();

                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("UnlockAccount call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void UnlockAccountDOB(string AccountNo, string dob, string Channel, string Surname, string cAnswer, string password, int loop)
        {
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + AccountNo + "/unlock");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        //if (oAuthMode == true)
                        //{
                        //    webRequest.Headers.Add("Authorization", "Bearer " + token);
                        //}
                        //else
                        //{
                        //    webRequest.Headers["tabcorpauth"] = token;
                        //}

                        string postData = "{" +
                                              "\"channel\":\"" + Channel + "\"," +
                                              "\"dateOfBirth\":\"" + dob + "\"," +
                                              "\"surname\":\"" + Surname + "\"," +
                                              "\"password\":\"" + password + "\"," +
                                              "\"challengeAnswer\":\"" + cAnswer + "\"" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("UnlockAccount call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("UnlockAccount call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("UnlockAccount call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }


                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Text = "Status: " + resp.StatusCode.ToString();

                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("UnlockAccount call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }


        public void ActivateAccount(AccountActivateClass.account req)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();

            Uri uri = new Uri(AddressCB.Text + "/v1/account-service/tab/accounts/" + req.accountNumber + "/internet-betting");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
            StreamWriter requestWriter;

            // authentication
            var cache = new CredentialCache(); ;
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
            

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AccountActivateClass.account));

            ser.WriteObject(stream1, req);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);

            
            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }


                    string postData = sr.ReadToEnd();

                    requestTB.Text = FormatJson(postData);

                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("ActivateAccount call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);


                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    requestWriter.Close();
                    Console.WriteLine(ret);
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("ActivateAccount call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("ActivateAccount call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    //amount = "";
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("ActivateAccount call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public void batch(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/"+accountNo +"/batch");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                //read contents with a text file with a list of bet strings
                if (File.Exists("Betfile.txt"))
                {

                    string BetStrings = System.IO.File.ReadAllText(@"Betfile.txt");

                    try
                    {

                        if (webRequest != null)
                        {
                            webRequest.Method = "POST";
                            webRequest.ServicePoint.Expect100Continue = false;
                            webRequest.Timeout = 20000;
                            webRequest.ContentType = "application/json";
                            if (oAuthMode == true)
                            {
                                webRequest.Headers.Add("Authorization", "Bearer " + token);
                            }
                            else
                            {
                                webRequest.Headers["tabcorpauth"] = token;
                            }


                            string postData = "{" +
                                        "\"betStrings\":[" + BetStrings + "" +
                                      "]," +
                                    "\"transactionId\":\"" + guild + "\"" +
                                //"\"submitTime\":\"20140424110000\"" +
                                "}";

                            requestTB.Text = FormatJson(postData);

                            //POST the data.
                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                requestWriter.Write(postData);
                            }

                            DateTime start = DateTime.Now;
                            if (LogMsgCKB.Checked)
                            {
                                log.LogError("batch call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                            }
                            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                            //print the response status code
                            int statusCode = getResponseCode(resp);
                            PrintStatusCode(resp, statusCode);

                            TimeSpan timeItTook = DateTime.Now - start;


                            Stream resStream = resp.GetResponseStream();
                            StreamReader reader = new StreamReader(resStream);
                            ret = reader.ReadToEnd();
                            requestWriter.Close();
                            Console.WriteLine(ret);
                            if (LogMsgCKB.Checked)
                            {
                                log.LogError("batch call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                                log.LogError("batch call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                            }
                            var jss = new JavaScriptSerializer();
                            dynamic response = jss.DeserializeObject(ret);
                            ResponseTB.Text = FormatJson(ret.ToString());
                            //ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        }
                    }

                    catch (WebException error)
                    {
                        PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                        var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                        ResponseTB.Text = resp;
                        ResponseTB.Refresh();
                        log.LogError("batch call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                    }
                }
                else
                {
                    log.LogError("Batch call: Betfile.txt does not exist!", System.Diagnostics.EventLogEntryType.Error);
                    ResTimeLBL.Text = "Betfile.txt does not exist! ";
                }
            }
        }
        public string betslip(string Stake, string multiplier, string Bettype, string PropId, string Odds, bool isCostEnquiry, string BonusBetToken, int loop)
        {
            string TSN = "";
            string interceptURL = "";

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                if (isCostEnquiry == true)
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip-enquiry");
                }
                else
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/"+accountNo +"/betslip");

                }
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "";
                        if (BonusBetToken == "")
                        {
                            postData = "{" +
                                "\"bets\":[{" +
                                  "\"stake\":\"$" + Stake + "\"," +
                                   "\"enableMultiplier\":" + multiplier + "," +
                                  "\"type\":\"FIXED_ODDS\"," +
                                  "\"propositions\":[{" +
                                      "\"type\":\"" + Bettype + "\"," +
                                      "\"propositionId\":" + PropId + "," +
                                      "\"odds\":\"" + Odds + "\"" +
                                   "}]" +
                                "}]," +
                                "\"transactionId\":\"" + guild + "\"" +
                            "}";
                        }
                        else
                        {
                            postData = "{" +
                                "\"bets\":[{" +
                                    "\"stake\":\"$" + Stake + "\"," +
                                    "\"enableMultiplier\":" + multiplier + "," +
                                    "\"type\":\"FIXED_ODDS\"," +
                                    "\"propositions\":[{" +
                                        "\"type\":\"" + Bettype + "\"," +
                                        "\"propositionId\":" + PropId + "," +
                                        "\"odds\":\"" + Odds + "\"" +
                                    "}]," +
                                    "\"bonusBetToken\":\"" + BonusBetToken + "\"" +
                                "}]," +
                                "\"transactionId\":\"" + guild + "\"" +
                            "}";
                        }

                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Betslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh(); 
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                        try
                        {
                            TSN = response["bets"][0]["ticketSerialNumber"];
                            
                        }
                        catch (Exception)
                        {

                        }

                        try
                        {
                            //interceptURL = response["bets"][0]["_links"]["resolvedIntercept"];
                            interceptURL = response["bets"][0]["_links"]["changed"];
                            if (interceptURL.Length > 0)
                            {
                                TSN = GetInterceptStatus(interceptURL);

                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Betslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return TSN;
        }


        public string  GetInterceptStatus(string url)
        {
            string TSN = "";
            ResTimeLBL.Text = "Your bet is being intercepted.. please wait... ";
            ResTimeLBL.Refresh();
            string ret = string.Empty;   
            WebClient webClient = new WebClient();
            Uri uri = new Uri(url);
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 140000;
                    webRequest.ContentType = "application/json";

                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    requestTB.Text = FormatJson(uri.ToString());


                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("pollIntercept call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("pollIntercept call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("pollIntercept call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");


                    try
                    {
                        TSN = response["bet"]["ticketSerialNumber"];

                    }
                    catch (Exception)
                    {

                    }
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("pollIntercept call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }

            return TSN;

        }
        
        public string betslip_EW(string StakeWin, string StakePlace, string multiplier, string Bettype, string PropId, string Odds, string SecondaryOdds, bool isCostEnquiry, int loop)
        {
            string interceptURL = "";

            requestTB.Text = "";
            ResponseTB.Text = "";

            string TSN = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                if (isCostEnquiry == true)
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip-enquiry");

                }
                else
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip");
                }
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "{" +
                                "\"bets\":[{" +
                                  "\"stake\":\"$" + StakeWin + "\"," +
                                  "\"enableMultiplier\":" + multiplier + "," +
                                  "\"type\":\"FIXED_ODDS\"," +
                                  "\"propositions\":[{" +
                                      "\"type\":\"" + Bettype + "\"," +
                                      "\"propositionId\":" + PropId + "," +
                                      "\"odds\":\"" + Odds + "\"" + "," +
                                      "\"secondaryOdds\":\"" + SecondaryOdds + "\"" +
                                   "}]" + "," +
                                    "\"secondaryStake\":\"" + StakePlace + "\"" +
                                "}]," +
                                "\"transactionId\":\"" + guild + "\"" +
                            "}";


                        requestTB.Text = FormatJson(postData);
                        requestTB.Refresh();

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        requestTB.Text = FormatJson(postData);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");                        

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Betslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh(); 
                        requestTB.Refresh();

                        try
                        {
                            TSN = response["bets"][0]["ticketSerialNumber"];

                        }
                        catch (Exception)
                        {

                        }

                        try
                        {
                            //interceptURL = response["bets"][0]["_links"]["resolvedIntercept"];
                            interceptURL = response["bets"][0]["_links"]["changed"];
                            if (interceptURL.Length > 0)
                            {
                                TSN = GetInterceptStatus(interceptURL);

                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Betslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return TSN;
        }
        public string betslip_multi(List<prop> propList, string multiplier, string InvestAmt, Boolean isSystem, string Systems, string Flexi, string combinedPrice, bool isCostEnquiry, int loop)
        {

            string TSN = "";
            string interceptURL = "";

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                if (isCostEnquiry == true)
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip-enquiry");
                }
                else
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip");
                }
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string propJson = "";
                        for (int j = 0; j < propList.Count; j++)
                        {
                            prop myProp = propList[j];
                            propJson += "{" +
                              "\"type\":\"" + myProp.type + "\"," +
                              "\"propositionId\":" + myProp.propId + "," +
                              "\"odds\":\"" + myProp.Odds + "\"" +
                            "}";
                            if (j < propList.Count - 1)
                            {
                                propJson += ",";
                            }
                        }

                        string postData = "";
                        if (isSystem == false)
                        {
                            postData = "{" +
                                    "\"bets\":[{" +
                                      "\"stake\":\"$" + InvestAmt + "\"," +
                                      "\"enableMultiplier\":" + multiplier + "," +
                                      "\"type\":\"FIXED_ODDS\"," +
                                      "\"propositions\":[" + propJson + "]," +
                                    "\"combinedPrice\":\""+ combinedPrice +"\"" +
                                    "}]," +
                                    "\"transactionId\":\"" + guild + "\"" +
                                "}";
                        }
                        else
                        {
                            postData = "{" +
                                    "\"bets\":[{" +
                                      "\"stake\":\"$" + InvestAmt + "\"," +
                                      "\"enableMultiplier\":" + multiplier + "," +
                                      "\"type\":\"FIXED_ODDS\"," +
                                      "\"propositions\":[" + propJson + "]," +
                                      "\"combinedPrice\":\"" + combinedPrice + "\"," +
                                      "\"systemMultis\":[{\"system\":" + Systems + "}]," +
                                      "\"flexi\":" + Flexi + "" +
                                    "}]," +
                                    "\"transactionId\":\"" + guild + "\"" +
                                "}";
                        }
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        requestTB.Text = FormatJson(postData);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Betslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();

                        try
                        {
                            TSN = response["bets"][0]["ticketSerialNumber"];
                        }
                        catch
                        {

                        }

                        try
                        {
                            //interceptURL = response["bets"][0]["_links"]["resolvedIntercept"];
                            interceptURL = response["bets"][0]["_links"]["changed"];
                            if (interceptURL.Length > 0)
                            {
                                TSN = GetInterceptStatus(interceptURL);

                            }
                        }
                        catch (Exception)
                        {

                        }


                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Betslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return TSN;
        }
        public string betslip_multi_LiveBet(List<prop> propList, string InvestAmt, string Outlet, int loop)
        {
            string id = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/" + accountNo + "/live-betslip-enquiry");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string propJson = "";
                        for (int j = 0; j < propList.Count; j++)
                        {
                            prop myProp = propList[j];
                            propJson += "{" +
                              "\"type\":\"" + myProp.type + "\"," +
                              "\"propositionId\":" + myProp.propId + "," +
                              "\"odds\":\"" + myProp.Odds + "\"" +
                            "}";
                            if (j < propList.Count - 1)
                            {
                                propJson += ",";
                            }
                        }

                        string postData = "{" +
                            "\"venueId\": " + Outlet + "," +
                                "\"bets\":[{" +
                                  "\"stake\":\"$" + InvestAmt + "\"," +
                                  "\"type\":\"FIXED_ODDS\"," +
                                  "\"propositions\":[" + propJson + "]" +
                                "}]," +
                                "\"transactionId\":\"" + guild + "\"" +
                            "}";

                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Betslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Betslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        try
                        {
                            id = response["id"];
                        }
                        catch
                        {

                        }



                        requestTB.Text = FormatJson(postData);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        //ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Betslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return id;
        }
        public void cashOutAccept(List<cashoutUC.CashOut> cashList, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();

                cashList[0].serialNumber.Replace(" ", "");
                cashList[0].serialNumber = cashList[0].serialNumber.TrimStart('0');
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/" + accountNo + "/cashout/" + cashList[0].serialNumber);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache(); ;
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string cashoutJson = "";
                        string cashoutAmountJson = "";

                        
                        for (int j = 0; j < cashList.Count; j++)
                        {

                            if (cashList[j].partialAmount != "")
                            {
                                cashoutAmountJson = "\"amount\":\"" + cashList[j].amount + "\"," +
                                  "\"partialAmount\":\"" + cashList[j].partialAmount + "\"" +
                            "";
                            }
                            else
                            {
                                cashoutAmountJson = "\"amount\":\"" + cashList[j].amount + "\"" +
                               "";
                            }




                            cashoutUC.CashOut myCashOut = cashList[j];
                            cashoutJson += "" + cashoutAmountJson +
                            "";
                            if (j < cashList.Count - 1)
                            {
                                cashoutJson += ",";
                            }
                        }


                        string postData = "{" +
                                "\"cashOut\":{" + cashoutJson +
                                "}," +
                                 "\"transactionId\":\"" + guild + "\"" +
                            "}";


                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("cashOut call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("cashOut call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("cashOut call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        amount = "";
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("cashOut call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void cashOutReq(List<cashoutUC.CashOut> cashList, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/cashout-offers/" + cashList[0].serialNumber);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("CashOut Request call: Request:", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("CashOut Request call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("CashOut Request call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        try
                        {
                            dynamic response = jss.DeserializeObject(ret);
                            ResponseTB.Text = FormatJson(ret.ToString());
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                            //get this amount so it can populate the "amount" textbox cashoutUC.cs
                            if (response.Count != 0)
                            {
                                //amount = response["cashOutOffers"][0]["amount"];
                                amount = response["amount"];
                            }
                        }

                        catch
                        {
                            ResponseTB.Text = "****** No JSON Response from API: check API endpoint ****** ";
                        }

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("CashOut Request call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                    amount = "";
                }
            }
        }
        public void cashOutOfferId(List<cashoutUC.CashOut> cashList, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/cashout-offers/" + cashList[0].serialNumber + "/offer-id");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                /////v1/tab-betting-service/accounts/:accountNumber/cashout-offers/:ticketSerialNumber
                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("CashOut Request call: Request:", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("CashOut Request call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("CashOut Request call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        try
                        {
                            dynamic response = jss.DeserializeObject(ret);
                            ResponseTB.Text = FormatJson(ret.ToString());
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        }

                        catch
                        {
                            ResponseTB.Text = "****** No JSON Response from API: check API endpoint ****** ";
                        }

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("CashOut Request call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void cashoutOffers(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/cashout-offers");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                
                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("cashoutOffers call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("cashoutOffers call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("cashoutOffers call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("cashoutOffers call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        
        public string bundleBet(string jsonString, bool isCostEnquiry, int loop)
        {
            string TSN = "";
            string interceptURL = "";

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                if (isCostEnquiry == true)
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip-enquiry");
                }
                else
                {
                    uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip");

                }
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = jsonString;
                        //if (BonusBetToken == "")
                        //{
                        //    postData = "{" +
                        //        "\"bets\":[{" +
                        //          "\"stake\":\"$" + Stake + "\"," +
                        //          "\"type\":\"FIXED_ODDS\"," +
                        //          "\"combinedPrice\":\"$" + Odds + "\"," +
                        //          "\"legs\":[{" +
                        //              "\"type\":\"" + Bettype + "\"," +
                        //              "\"propositionId\":" + PropId + "," +
                        //              "\"odds\":\"" + Odds + "\"" +
                        //           "}]" +
                        //        "}]," +
                        //        "\"transactionId\":\"" + guild + "\"" +
                        //    "}";
                        //}
                        //else
                        //{
                        //    postData = "{" +
                        //        "\"bets\":[{" +
                        //            "\"stake\":\"$" + Stake + "\"," +
                        //            "\"type\":\"FIXED_ODDS\"," +
                        //            "\"propositions\":[{" +
                        //                "\"type\":\"" + Bettype + "\"," +
                        //                "\"propositionId\":" + PropId + "," +
                        //                "\"odds\":\"" + Odds + "\"" +
                        //            "}]," +
                        //            "\"bonusBetToken\":\"" + BonusBetToken + "\"" +
                        //        "}]," +
                        //        "\"transactionId\":\"" + guild + "\"" +
                        //    "}";
                        //}

                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("BundleBet call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("BundleBet call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("BundleBet call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                        try
                        {
                            TSN = response["bets"][0]["ticketSerialNumber"];

                        }
                        catch (Exception)
                        {

                        }

                        try
                        {
                            //interceptURL = response["bets"][0]["_links"]["resolvedIntercept"];
                            interceptURL = response["bets"][0]["_links"]["changed"];
                            if (interceptURL.Length > 0)
                            {
                                TSN = GetInterceptStatus(interceptURL);

                            }
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Betslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return TSN;
        }

        public string enquirybundlePrice(string jsonString, bool isCostEnquiry, int loop)
        {
            string TSN = "";

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                if (isCostEnquiry == true)
                {
                    uri = new Uri(AddressCB.Text + "/v1/pricing-service/enquiry");
                }
                else
                {
                    uri = new Uri(AddressCB.Text + "/v1/pricing-service/enquiry");

                }
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = jsonString;
                       

                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("enquirybundlePrice call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("enquirybundlePrice call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("enquirybundlePrice call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("enquirybundlePrice call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return TSN;
        }

        public void CancelBet(string tsn, int loop)
        {
            for (int i = 0; i < loop; i++)
            {

                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/cancel/" + tsn);

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "{" +
                                              "\"transactionId\":\"" + returnGUID() + "\"" +
                                          "}";
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        try
                        {

                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                requestWriter.Write(postData);
                            }
                            requestWriter.Close();
                        }

                        catch (Exception e)
                        {
                            log.LogError("Authenticate call: Response: \r\n" + e, System.Diagnostics.EventLogEntryType.Error);
                            ResponseTB.Text = "An error has occured, REASON: " + e.Message.ToString();
                            break;
                        }


                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Authenticate call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Authenticate call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Authenticate call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);

                        try
                        {
                            //token = response["authentication"]["token"];
                            //oAuthMode = false;

                            ResponseTB.Text = FormatJson(ret.ToString());
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                            resStream.Close();
                            reader.Close();
                        }
                        catch (Exception e)
                        {
                            log.LogError("Authenticate call: Response: \r\n" + e, System.Diagnostics.EventLogEntryType.Error);
                            ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                            resStream.Close();
                            reader.Close();
                        }
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("Authenticate call: Details of reason: [] {0}" + error.Status, System.Diagnostics.EventLogEntryType.Error);
                }
                catch (Exception)
                {

                }
            }
        }

        public void AMLevent(string jsonString, int loop)
        {

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/events");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers.Add("Authorization", "Bearer " + AMLtoken);
                        
                        string postData = jsonString;
                        

                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLevent call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLevent call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AMLevent call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                       

                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("AMLevent call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }


        public void getAllEvents(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/events");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers.Add("Authorization", "Bearer " + AMLtoken);
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getAllEvents call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getAllEvents call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("getAllEvents call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        //dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        
                        if (ResponseTB.Visible) //scroll downt to the bottom of page given the order of the events are always down the bloody bottom.
                        {
                            ResponseTB.SelectionStart = ResponseTB.TextLength;
                            ResponseTB.ScrollToCaret();
                        }

                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("getAllEvents call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void AMLrelease(string jsonString, int eventId, int loop)
        {

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/events/" + eventId + "/ssc-release");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }

                        string postData = jsonString;


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLrelease call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLrelease call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AMLrelease call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("AMLrelease call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void AMLfinalise(string jsonString, int eventId, int loop)
        {

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/events/" + eventId + "/finalise");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }

                        string postData = jsonString;


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLfinalise call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLfinalise call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AMLfinalise call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("AMLfinalise call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void AMLHostrelease(string jsonString, int eventId, int loop)
        {

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/events/" + eventId + "/host-release");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers.Add("Authorization", "Bearer " + AMLtoken);

                        string postData = jsonString;


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLHostrelease call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("AMLHostrelease call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("AMLHostrelease call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");



                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("AMLrelease call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void getSSCavailability(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/configs?keys=SSC_AVAILABLE");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers.Add("Authorization", "Bearer " + AMLtoken);
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getSSCavailability call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("getSSCavailability call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("getSSCavailability call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("getSSCavailability call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void setSSCavailability(string jsonString, int loop)
        {

            requestTB.Text = "";
            ResponseTB.Text = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = null;
                uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/configs");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;
                
                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }

                        string postData = jsonString;


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("setSSCavailability call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("setSSCavailability call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("setSSCavailability call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResponseTB.Refresh();
                        requestTB.Refresh();
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");



                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("setSSCavailability call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void SSCavailabilityPoll(int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/service-invenue-aml/status/heart-beat");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers.Add("Authorization", "Bearer " + AMLtoken);
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;

                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("SSCavailabilityPoll call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("SSCavailabilityPoll call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("SSCavailabilityPoll call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("SSCavailabilityPoll call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }

        public void Meetings(string meetingDate, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/racing/dates/" + meetingDate + "/meetings?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers.Add("Origin", "tab.com.au");

                        requestTB.Text = FormatJson(uri.ToString());


                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Meetings call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Meetings call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Meetings call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Meetings call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MeetingRaces(string meetingDate, string RealType, string venueMnemonic, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/racing/dates/" + meetingDate + "/meetings/" + RealType + "/" + venueMnemonic + "/races?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MeetingRaces call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MeetingRaces call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MeetingRaces call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MeetingRaces call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void futureMeetings(string meetingDate, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/racing/dates/" + meetingDate + "/meetings?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("FutureMeetings call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("FutureMeetings call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("FutureMeetings call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("FutureMeetings call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void futureRaces(string meetingDate, string RealType, string venueMnemonic, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/racing/dates/" + meetingDate + "/meetings/" + RealType + "/" + venueMnemonic + "/races/" + "?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("FutureRaces call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("FutureRaces call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("FutureRaces call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("FutureRaces call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void races(string meetingDate, string RealType, string venueMnemonic, string raceNumber, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/racing/dates/" + meetingDate + "/meetings/" + RealType + "/" + venueMnemonic + "/races/" + raceNumber + "?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Races call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Races call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Races call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Races call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void Sports(string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Sports call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Sports call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Sports call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Sports call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void Competitions(string sportName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Competitions call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Competitions call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Competitions call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Competitions call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void Tournaments(string sportName, string competitionName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/tournaments?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";


                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Tournaments call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Tournaments call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Tournaments call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Tournaments call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void Matches(string sportName, string competitionName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/matches?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Matches call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Matches call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Matches call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Matches call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MatchCompetition(string sportName, string competitionName, string matchName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/matches/" + matchName + "?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MatchMarkets call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MatchMarkets call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MatchMarkets call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MatchMarkets call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MatchTournament(string sportName, string competitionName, string tournament, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/tournaments/" + tournament + "/matches?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MatchTournament call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MatchTournament call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MatchTournament call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MatchTournament call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MatchCompTourn(string sportName, string competitionName, string tournament, string matchName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/tournaments/" + tournament + "/matches/" + matchName + "?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MatchCompTourn call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MatchCompTourn call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MatchCompTourn call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MatchCompTourn call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MarketsCompetition(string sportName, string competitionName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/markets?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Markets call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("Markets call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("Markets call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("Markets call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MarketsCompTourn(string sportName, string competitionName, string tournament, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/tournaments/" + tournament + "/markets?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MarketsCompTourn call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MarketsCompTourn call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MarketsCompTourn call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MarketsCompTourn call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }


        public void MarketsCompMatch(string sportName, string competitionName, string matchName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                String newMatchName = Uri.EscapeDataString(matchName);

                String newUri = AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + Uri.EscapeDataString(competitionName) + "/matches/" + newMatchName + "/markets/?jurisdiction=" + jurisdiction;

                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + Uri.EscapeDataString(competitionName) + "/matches/" + newMatchName + "/markets/?jurisdiction=" + jurisdiction);

                var webRequest = System.Net.WebRequest.Create(newUri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;

                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MarketsCompMatch call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MarketsCompMatch call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MarketsCompMatch call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MarketsCompMatch call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void MarketsCompTournMatch(string sportName, string competitionName, string tournament, string matchName, string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/" + sportName + "/competitions/" + competitionName + "/tournaments/" + tournament + "/matches/" + matchName + "/markets/?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MarketsCompTournMatch call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("MarketsCompTournMatch call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("MarketsCompTournMatch call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("MarketsCompTournMatch call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void NextToGo(string jurisdiction, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/sports/nextToGo?jurisdiction=" + jurisdiction);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers.Add("Origin", "tab.com.au");

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("NextToGo call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("NextToGo call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("NextToGo call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("NextToGo call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void NextToGoRacing(string jurisdiction, string maxRaces, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/v1/tab-info-service/racing/next-to-go/races?jurisdiction=" + jurisdiction + "&maxRaces=" + maxRaces);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                //cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.Headers["tabcorpauth"] = token;
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        webRequest.Headers.Add("Origin", "tab.com.au");

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("NextToGoRacing call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }
                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("NextToGoRacing call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("NextToGoRacing call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("NextToGoRacing call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void depositEnquiry(string amount, string cardNumb, string CreditToken, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                StreamWriter requestWriter;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text + "/api/accounts/deposit/enquiry");

                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                // authentication
                var cache = new CredentialCache();
                //cache.Add(uri, "Basic", new NetworkCredential("Tabtablet1", "Pilot20!3a"));
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Frontfoot20!3"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ContentType = "application/json";


                        string postData = "{" +
                                              "\"amount\":" + amount + "," +
                                              "\"masked_credit_card_number\": \"" + cardNumb + "\"," +
                                              "\"credit_card_token_id\":\"" + CreditToken + "\"" +
                                          "}";

                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }
                        requestWriter.Close();

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("DepositEnquiry call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("DepositEnquiry call: Response: \r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("DepositEnquiry call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);

                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        resStream.Close();
                        reader.Close();
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("DepositEnquiry call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }


        private void msgboxCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            RacingInfoCB.Text = "";
            BettingCB.Text = "";
            SportsInfoCB.Text = "";
            InVenueCB.Text = "";

            if (ActManCallsCB.Text == "Authenticate")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AuthenticateUC usr1 = new AuthenticateUC(this);
                usr1.Show();
                panel1.Controls.Add(usr1);
            }
            else if (ActManCallsCB.Text == "AccountBalance")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AccountBlanceUC usr2 = new AccountBlanceUC(this);
                usr2.Show();
                panel1.Controls.Add(usr2);
            }
            else if (ActManCallsCB.Text == "AccountPreferences")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                preferencesUC usr3 = new preferencesUC(this);
                usr3.Show();
                panel1.Controls.Add(usr3);
            }
            else if (ActManCallsCB.Text == "AccountStatement")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AccountStatement usr4 = new AccountStatement(this);
                usr4.Show();
                panel1.Controls.Add(usr4);
            }
            if (ActManCallsCB.Text == "GetAccountDetails")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                getAccountDetailsUC usr5 = new getAccountDetailsUC(this);
                usr5.Show();
                panel1.Controls.Add(usr5);
            }
            if (ActManCallsCB.Text == "DepositEnquiry")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                DepositEnquiryUC usr18 = new DepositEnquiryUC(this);
                usr18.Show();
                panel1.Controls.Add(usr18);
            }
            if (ActManCallsCB.Text == "AccountStatementEnhanced")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AccountStatementEnhancedUC usr30 = new AccountStatementEnhancedUC(this);
                usr30.Show();
                panel1.Controls.Add(usr30);
            }
            if (ActManCallsCB.Text == "AccountCreation")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                OpenAccountUC usr31 = new OpenAccountUC(this);
                usr31.Show();
                panel1.Controls.Add(usr31);
            }
            if (ActManCallsCB.Text == "AccountStatementRecent")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AccountStatementRecent usr32 = new AccountStatementRecent(this);
                usr32.Show();
                panel1.Controls.Add(usr32);
            }
            if (ActManCallsCB.Text == "ForgotPassword")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                ForgetPassword usr33 = new ForgetPassword(this);
                usr33.Show();
                panel1.Controls.Add(usr33);
            }
            if (ActManCallsCB.Text == "ResetPin")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                ResetPin usr34 = new ResetPin(this);
                usr34.Show();
                panel1.Controls.Add(usr34);
            }
            if (ActManCallsCB.Text == "Eft-registration")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                EFT_Registration usr35 = new EFT_Registration(this);
                usr35.Show();
                panel1.Controls.Add(usr35);
            }
            if (ActManCallsCB.Text == "CardOrdering")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                CardOrdering usr36 = new CardOrdering(this);
                usr36.Show();
                panel1.Controls.Add(usr36);
            }
            if (ActManCallsCB.Text == "EmailVerification")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                EmailVerification usr37 = new EmailVerification(this);
                usr37.Show();
                panel1.Controls.Add(usr37);
            }
            if (ActManCallsCB.Text == "AuthenticateOAuth")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AuthenticatevOOauthUC usr38 = new AuthenticatevOOauthUC(this);
                usr38.Show();
                panel1.Controls.Add(usr38);
            }
            if (ActManCallsCB.Text == "ActivateAccount")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                ActivateAccountUC usr39 = new ActivateAccountUC(this);
                usr39.Show();
                panel1.Controls.Add(usr39);
            }
            if (ActManCallsCB.Text == "UnlockAccount")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AccountUnlockUC usr40 = new AccountUnlockUC(this);
                usr40.Show();
                panel1.Controls.Add(usr40);
            }

        }
        private void RacingInfoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActManCallsCB.Text = "";
            BettingCB.Text = "";
            SportsInfoCB.Text = "";
            InVenueCB.Text = "";

            if (RacingInfoCB.Text == "Meetings")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MeetingUC usr8 = new MeetingUC(this);
                usr8.Show();
                panel1.Controls.Add(usr8);
            }
            if (RacingInfoCB.Text == "MeetingRaces")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MeetingRacesUC usr9 = new MeetingRacesUC(this);
                usr9.Show();
                panel1.Controls.Add(usr9);
            }
            if (RacingInfoCB.Text == "FutureRaces")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                FutureRacesUC usr10 = new FutureRacesUC(this);
                usr10.Show();
                panel1.Controls.Add(usr10);
            }
            if (RacingInfoCB.Text == "Races")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                RacesUC usr11 = new RacesUC(this);
                usr11.Show();
                panel1.Controls.Add(usr11);
            }
            if (RacingInfoCB.Text == "FutureMeetings")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                FutureMeetingsUC usr12 = new FutureMeetingsUC(this);
                usr12.Show();
                panel1.Controls.Add(usr12);
            }
            if (RacingInfoCB.Text == "NextToGo")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                NextToGoRacingTC usr13 = new NextToGoRacingTC(this);
                usr13.Show();
                panel1.Controls.Add(usr13);
            }
        }
        private void BettingCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActManCallsCB.Text = "";
            SportsInfoCB.Text = "";
            RacingInfoCB.Text = "";
            InVenueCB.Text = "";

            if (BettingCB.Text == "BatchBetting")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                BatchBettingUC usr6 = new BatchBettingUC(this);
                usr6.Show();
                panel1.Controls.Add(usr6);
            }
            if (BettingCB.Text == "FixedOddsSell")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                FOBettingUC usr7 = new FOBettingUC(this);
                usr7.Show();
                panel1.Controls.Add(usr7);
            }
            if (BettingCB.Text == "FixedOddsSell_Multi")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                FixedOddsBettingMultiUC usr32 = new FixedOddsBettingMultiUC(this);
                usr32.Show();
                panel1.Controls.Add(usr32);
            }
            if (BettingCB.Text == "CashOut")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                cashoutUC usr31 = new cashoutUC(this);
                usr31.Show();
                panel1.Controls.Add(usr31);
            }
            if (BettingCB.Text == "FixedOddsSellLiveBet")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                FOBettingLiveBetUC usr33 = new FOBettingLiveBetUC(this);
                usr33.Show();
                panel1.Controls.Add(usr33);
            }
            if (BettingCB.Text == "FixedOddsSellLiveBet_Multi")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                FixedOddsSellLiveBet_MultiUC usr34 = new FixedOddsSellLiveBet_MultiUC(this);
                usr34.Show();
                panel1.Controls.Add(usr34);
            }
            if (BettingCB.Text == "PariSell")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                PariSellUC usr35 = new PariSellUC(this);
                usr35.Show();
                panel1.Controls.Add(usr35);
            }
            if (BettingCB.Text == "CancelBet")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                CancelBetUC usr36 = new CancelBetUC(this);
                usr36.Show();
                panel1.Controls.Add(usr36);
            }
            if (BettingCB.Text == "ScanRetailTicket")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                ScanRetailTicketUC usr37 = new ScanRetailTicketUC(this);
                usr37.Show();
                panel1.Controls.Add(usr37);
            }
            if (BettingCB.Text == "BundleBet")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                BundleBetUC usr38 = new BundleBetUC(this);
                usr38.Show();
                panel1.Controls.Add(usr38);
            }
            if (BettingCB.Text == "BundleBetPricing")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                BundleBetPricingUC usr39 = new BundleBetPricingUC(this);
                usr39.Show();
                panel1.Controls.Add(usr39);
            }


            

        }
        private void SportsInfoCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActManCallsCB.Text = "";
            BettingCB.Text = "";
            RacingInfoCB.Text = "";
            InVenueCB.Text = "";

            if (SportsInfoCB.Text == "Sports")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                SportsUC usr13 = new SportsUC(this);
                usr13.Show();
                panel1.Controls.Add(usr13);
            }
            if (SportsInfoCB.Text == "Competitions")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                CompetitionsUC usr13 = new CompetitionsUC(this);
                usr13.Show();
                panel1.Controls.Add(usr13);
            }
            if (SportsInfoCB.Text == "Tournaments")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                TournamentsUC usr14 = new TournamentsUC(this);
                usr14.Show();
                panel1.Controls.Add(usr14);
            }
            if (SportsInfoCB.Text == "Matches")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MatchesUC usr15 = new MatchesUC(this);
                usr15.Show();
                panel1.Controls.Add(usr15);
            }
            if (SportsInfoCB.Text == "MarketsCompetition")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MarketsCompetitionUC usr16 = new MarketsCompetitionUC(this);
                usr16.Show();
                panel1.Controls.Add(usr16);
            }
            if (SportsInfoCB.Text == "MatchTournament")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MatchTournamentUC usr18 = new MatchTournamentUC(this);
                usr18.Show();
                panel1.Controls.Add(usr18);
            }
            if (SportsInfoCB.Text == "MarketsCompTourn")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MarketCompTournUC usr21 = new MarketCompTournUC(this);
                usr21.Show();
                panel1.Controls.Add(usr21);
            }
            if (SportsInfoCB.Text == "MarketsCompMatch")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MarketCompMatchUC usr22 = new MarketCompMatchUC(this);
                usr22.Show();
                panel1.Controls.Add(usr22);
            }
            if (SportsInfoCB.Text == "MatchCompTourn")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MatchCompTournUC usr20 = new MatchCompTournUC(this);
                usr20.Show();
                panel1.Controls.Add(usr20);
            }
            if (SportsInfoCB.Text == "MarketsCompTournMatch")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                MarketsCompTournMatchUC usr23 = new MarketsCompTournMatchUC(this);
                usr23.Show();
                panel1.Controls.Add(usr23);
            }
            if (SportsInfoCB.Text == "NextToGo")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                NextToGoUC usr17 = new NextToGoUC(this);
                usr17.Show();
                panel1.Controls.Add(usr17);
            }
        }

        public string liveBetslipEnquiry(string Stake, string Bettype, string PropId, string Odds, string Outlet, int loop)
        {
            string id = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/" + accountNo + "/live-betslip-enquiry");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "{" +
                            "\"venueId\": " + Outlet + "," +
                                "\"bets\":[{" +
                                  "\"stake\":\"$" + Stake + "\"," +
                                  "\"type\":\"FIXED_ODDS\"," +
                                  "\"propositions\":[{" +
                                      "\"type\":\"" + Bettype + "\"," +
                                      "\"propositionId\":" + PropId + "," +
                                      "\"odds\":\"" + Odds + "\"" +
                                   "}]" +
                                "}]," +
                                "\"transactionId\":\"" + guild + "\"" +
                            "}";


                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslipEnquiry call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslipEnquiry call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("liveBetslipEnquiry call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        try
                        {
                            id = response["id"];
                        }
                        catch
                        {

                        }


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("liveBetslipEnquiry call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return id;
        }
        public string liveBetslipEnquiryEW(string StakeWin, string StakePlace, string Bettype, string PropId, string Odds, string secondaryOdds, string Outlet, int loop)
        {
            string id = "";
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/" + accountNo + "/live-betslip-enquiry");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "{" +
                            "\"venueId\":" + Outlet + "," +
                                "\"bets\":[{" +
                                    "\"stake\":\"$" + StakeWin + "\"," +
                                    "\"type\":\"FIXED_ODDS\"," +
                                    "\"propositions\":[{" +
                                        "\"type\":\"" + Bettype + "\"," +
                                        "\"propositionId\":" + PropId + "," +
                                        "\"odds\":\"" + Odds + "\"" + "," +
                                        "\"secondaryOdds\":\"" + secondaryOdds + "\"" +
                                     "}]" + "," +
                                      "\"secondaryStake\":\"" + StakePlace + "\"" +
                                  "}]," +
                                  "\"transactionId\":\"" + guild + "\"" +
                              "}";
                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslipEnquiryEW call: Request: " + FormatJson(postData), System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslipEnquiryEW call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("liveBetslipEnquiryEW call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        try
                        {
                            id = response["id"];
                        }
                        catch
                        {

                        }


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("liveBetslipEnquiryEW call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
            return id;
        }
        public void liveBetslip(string id, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/" + accountNo + "/live-betslip/" + id);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "";

                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("liveBetslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);

                        try
                        {
                            major = response["beacon"]["major"];
                            minor = response["beacon"]["minor"];
                        }
                        catch (Exception)
                        {

                        }

                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("liveBetslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void pollLiveBetslip(string id, string Outlet, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/venues/" + Outlet + "/live-betslip/" + id + "/" + major + "/" + minor + "/confirm");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "";

                        requestTB.Text = FormatJson(postData);

                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("pollLiveBetslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("pollLiveBetslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("pollLiveBetslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);

                        try
                        {
                            //major = response["beacon"]["major"];
                            //minor = response["beacon"]["minor"];
                        }
                        catch (Exception)
                        {

                        }

                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("pollLiveBetslip call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void liveBetslipReceipt(string id, int loop)
        {
            for (int i = 0; i < loop; i++)
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();
                Uri uri = new Uri(AddressCB.Text.Replace("8183", "8184") + "/v1/tab-betting-service/accounts/" + accountNo + "/live-betslip/" + id);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        requestTB.Text = FormatJson(uri.ToString());

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslip call: Request: " + requestTB.Text, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        //requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("liveBetslipReceipt call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("liveBetslipReceipt call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);


                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = FormatJson(resp.ToString());
                    ResponseTB.Refresh();
                    log.LogError("liveBetslipReceipt call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public dynamic pariSingleBet(singleLegClass.SingleLegBets bet)
        {
            dynamic response = null;
            string ret = "";
            WebClient webClient = new WebClient();
            HttpWebResponse resp = null;

            Uri uri = new Uri(AddressCB.Text + "/v1/tab-betting-service/accounts/" + accountNo + "/betslip");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;


            // authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            if (bet.bets[0].bonusBetToken == "")
            {
                bet.bets[0].bonusBetToken = null;
            }

            StreamWriter requestWriter;

            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(singleLegClass.SingleLegBets));

            ser.WriteObject(stream1, bet);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);


            try
            {
                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }


                    string postData = sr.ReadToEnd();

                    requestTB.Text = FormatJson(postData);

                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("Betslip call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }

                    resp = (HttpWebResponse)webRequest.GetResponse();
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    TimeSpan timeItTook = DateTime.Now - start;
                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    ResponseTB.Text = FormatJson(ret.ToString());
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("Betslip call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("Betslip call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }


                    var jss = new JavaScriptSerializer();
                    response = jss.DeserializeObject(ret);


                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var respError = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();

                ResponseTB.Text = FormatJson(respError);
                ResponseTB.Refresh();
                log.LogError("Betslip call: Details of reason: [] {0}" + respError, System.Diagnostics.EventLogEntryType.Error);
            }

            catch (Exception e)
            {
                ResponseTB.Text = e.Message;
            }

            return response;
        }

        public void InVenueCommissionByAccountSignUp (InVenueCommissionsUC.CommissionRequest req, List<string> serial)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
                        
            Uri uri = new Uri(AddressCB.Text.Replace("webapi","beta") + "/v1/invenue-service/commissions/add");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
            StreamWriter requestWriter;

            //Get a New generated UUID
            string guild = returnGUID();

            // authentication
            var cache = new CredentialCache(); ;
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    string postData = "";

                    if (req.type == "ACCOUNT_SIGNUP")
                    { 
                    postData = "{" +
                            "\"type\":\"" + req.type + "\"," +
                            "\"accountId\":\"" + req.accountId + "\"," +
                            "\"dateTime\":\"" + req.dateTime + "\"," +
                            "\"geoLocation\":{" + 
                                 "\"latitude\":" + req.latitude + "," +
                                 "\"longitude\":" + req.longitude + "," +
                                 "\"uncertainty\":" + req.uncertainty + 
                            "}," +
                              "\"blueDotFence\":\"" + req.blueDotFence + "\"," +
                               "\"beaconVenueId\":" + req.beaconVenueId + 
                        "}";
                    }
                    else
                    {

                        string jsonBetTransNumber = "";
                        foreach (var tsn in serial)
                        {
                            jsonBetTransNumber = jsonBetTransNumber  + "\"" + tsn + "\",";
                        }

                        jsonBetTransNumber = jsonBetTransNumber.TrimEnd(',');


                        postData = "{" +
                                "\"type\":\"" + req.type + "\"," +
                                "\"accountId\":\"" + req.accountId + "\"," +
                                "\"dateTime\":\"" + req.dateTime + "\"," +
                                "\"transactionId\":\"" + guild + "\"," +
                                "\"geoLocation\":{" +
                                     "\"latitude\":" + req.latitude + "," +
                                     "\"longitude\":" + req.longitude + "," +
                                     "\"uncertainty\":" + req.uncertainty +
                                "}," +
                                "\"betTransactionNumbers\":[" + jsonBetTransNumber +
                                "]," +
                                  "\"blueDotFence\":\"" + req.blueDotFence + "\"," +
                                   "\"beaconVenueId\":" + req.beaconVenueId +
                            "}";


                    }

                    requestTB.Text = FormatJson(postData);
                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCommissionByAccountSignUp call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);


                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    requestWriter.Close();
                    Console.WriteLine(ret);
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCommissionByAccountSignUp call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueCommissionByAccountSignUp call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    amount = "";
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueCommissionByAccountSignUp call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }

        }
        public void InVenueConfiguration()
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/configuration");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueConfiguration call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueConfiguration call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueConfiguration call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueConfiguration call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueDistributionGroups()
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/distribution-groups");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("DistributionGroups call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("DistributionGroups call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("DistributionGroups call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("DistributionGroups call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueDeleteConfig(string id)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/configuration/" + id);
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "DELETE";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueDeleteConfig call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueDeleteConfig call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueDeleteConfig call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueDeleteConfig call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueDeleteConfigGroup(string id)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();

            Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/distribution-groups/" +id);
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
            StreamWriter requestWriter;

            //Get a New generated UUID
            string guild = returnGUID();

            // authentication
            var cache = new CredentialCache(); ;
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "PATCH";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    string postData = "";

                    
                        postData = "{\"configuration\":{}}";
                    //  "\"type\":\"FIXED_ODDS\"," +

                    requestTB.Text = FormatJson(postData);
                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueDeleteConfigGroup call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);


                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    requestWriter.Close();
                    Console.WriteLine(ret);
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueDeleteConfigGroup call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueCommissionByAccountSignUp call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    amount = "";
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueDeleteConfigGroup call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }

        }
        public void InVenueVenueList()
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/venue-list");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueVenueList call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueVenueList call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueVenueList call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueVenueList call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueVenueCaches(string venueId)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/venues/"+ venueId + "/caches");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueVenueCaches call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueVenueCaches call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueVenueCaches call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                if (error.Response != null)
                {
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("InVenueVenueCaches call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
                else
                {
                    ResponseTB.Text = error.Message;
                    ResponseTB.Refresh();
                    log.LogError("InVenueVenueCaches call: Details of reason: [] {0}" + error.Message, System.Diagnostics.EventLogEntryType.Error);
                }
                
                
            }
        }
        public void InVenueVenueWageringTerminals(string venueId)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/venues/" + venueId + "/wagering-terminals ");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueVenueWageringTerminals call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueVenueWageringTerminals call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueVenueWageringTerminals call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueVenueWageringTerminals call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueNonCommissioned()
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/display-devices/non-commissioned");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueNonCommissioned call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueNonCommissioned call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueNonCommissioned call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueNonCommissioned call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueAllDisplayDevices()
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/display-devices");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueAllDisplayDevices call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueAllDisplayDevices call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueAllDisplayDevices call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueAllDisplayDevices call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueFindDeviceBySerialNo(string serialNo)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/display-devices/" + serialNo);
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueFindDeviceBySerialNo call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueFindDeviceBySerialNo call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueFindDeviceBySerialNo call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueFindDeviceBySerialNo call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueFilterByAssetorSerialNumber(string serialNo)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/display-devices?filter=" + serialNo);
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueFilterByAssetorSerialNumber call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueFilterByAssetorSerialNumber call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueFilterByAssetorSerialNumber call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueFilterByAssetorSerialNumber call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueListDevicebyVenue(string venueId)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/venues/"+venueId +"/display-devices");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueListDevicebyVenue call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueListDevicebyVenue call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueListDevicebyVenue call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueListDevicebyVenue call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueCommissionDevicebyVenue(string venueId)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/venues/"+ venueId + "/closest-non-commissioned");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCommissionDevicebyVenue call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCommissionDevicebyVenue call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueCommissionDevicebyVenue call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.

                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueCommissionDevicebyVenue call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueConnect(InVenueTerminalsUC.terminal term)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();

            Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/wagering-terminals/" + term.venue + "/EBT/" + term.terminalNo + "/connect");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
            StreamWriter requestWriter;

            //Get a New generated UUID
            string guild = returnGUID();

            // authentication
            var cache = new CredentialCache(); ;
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    string postData = "";


                    //postData = "{\"details\":{}}";



                    //postData= {"details":{"hardwareVersion":"41","memory":"8098MB","operatingSystem":"Microsoft Windows 6.1 Service Pack 1","terminalVersion":"00.00"}}
                    postData = "{" +
                                  "\"details\":{" +
                                    "\"hardwareVersion\":\"" + term.hardware + "\"," +
                                    "\"memory\":\"" + term.memory + "\"," +
                                    "\"operatingSystem\":\"" + term.os + "\"," +
                                    "\"terminalVersion\":\"" + term.terminalVer + "\"" +
                                  "}" +
                              "}";
                    requestTB.Text = FormatJson(postData);

                    requestTB.Text = FormatJson(postData);
                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueConnect call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);


                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    requestWriter.Close();
                    Console.WriteLine(ret);
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueConnect call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueConnect call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    amount = "";
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueConnect call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }

        }
        public void InVenueCache(InVenueTerminalsUC.terminal term)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/venues/" + term.venue + "/caches");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCache call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCache call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueCache call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");

                    cacheURL = response["cacheURL"];
                    
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueCache call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueCachePollxxxx(InVenueTerminalsUC.terminal term)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text + "/v1/invenue-service/caches/" + term.venue + "/cache");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";

                    requestTB.Text = FormatJson(uri.ToString());
                    DateTime start = DateTime.Now;
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);

                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCachePoll call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                    }

                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueCachePoll call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueCachePoll call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }

                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueCachePoll call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public void InVenueCachePoll(InVenueTerminalsUC.terminal term)
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();

            Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/wagering-terminals/" + term.venue + "/EBT/" + term.terminalNo + "/poll");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
            StreamWriter requestWriter;

            //Get a New generated UUID
            string guild = returnGUID();

            // authentication
            var cache = new CredentialCache(); ;
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "POST";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    string postData = "";
                    
                    //postData= {"details":{"hardwareVersion":"41","memory":"8098MB","operatingSystem":"Microsoft Windows 6.1 Service Pack 1","terminalVersion":"00.00"}}
                    postData = "{" +
                                  "\"details\":{" +
                                    "\"digitalApiURL\":\"" + cacheURL + "\"" +
                                  "}" +
                              "}";
                    requestTB.Text = FormatJson(postData);

                    requestTB.Text = FormatJson(postData);
                    //POST the data.
                    using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                    {
                        requestWriter.Write(postData);
                    }

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueConnect call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);


                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    requestWriter.Close();
                    Console.WriteLine(ret);
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("InVenueConnect call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("InVenueConnect call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);
                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    amount = "";
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = resp;
                ResponseTB.Refresh();
                log.LogError("InVenueConnect call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }

        }
        public void RetailDevice(RetailDeviceUC.Configuation conf)
        {
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();

                Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/configuration/devices/" + conf.security_id);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache(); ;
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "";
                        postData = "{" +
                                        "\"venue_id\":\"" + conf.venue_id + "\"," +
                                        "\"window_id\":\"" + conf.window_id + "\"" +
                                  "}";
                        requestTB.Text = FormatJson(postData);

                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("RetailDevice call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("RetailDevice call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("RetailDevice call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        amount = "";
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("RetailDevice call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void RetailDeviceDelete(RetailDeviceUC.Configuation conf)
        {
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();

                Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/configuration/devices/" + conf.security_id);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache(); ;
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "DELETE";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }

                        string postData = "{}";
                        
                        requestTB.Text = FormatJson(postData);
                        requestTB.Text = FormatJson(postData);
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            requestWriter.Write(postData);
                        }

                        DateTime start = DateTime.Now;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("RetailDeviceDelete call: Request: " + postData, System.Diagnostics.EventLogEntryType.Information);
                        }
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        TimeSpan timeItTook = DateTime.Now - start;
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);


                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        requestWriter.Close();
                        Console.WriteLine(ret);
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("RetailDeviceDelete call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("RetailDeviceDelete call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }
                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                        amount = "";
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("RetailDeviceDelete call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void RetailDeviceGET(RetailDeviceUC.Configuation conf)
        {
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();

                Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/configuration/devices/" + conf.security_id);
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache(); ;
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("RetailDeviceGET call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("RetailDeviceGET call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("RetailDeviceGET call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("RetailDeviceGET call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }
        public void LocationWindowsGET(string location)
        {
            {
                string ret = string.Empty;
                WebClient webClient = new WebClient();

                Uri uri = new Uri(AddressCB.Text.Replace("webapi", "beta") + "/v1/invenue-service/locations/"+ location +"/windows");
                var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;
                StreamWriter requestWriter;

                //Get a New generated UUID
                string guild = returnGUID();

                // authentication
                var cache = new CredentialCache(); ;
                cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
                webRequest.Credentials = cache;
                //This will ignore certificate type issues.
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

                try
                {

                    if (webRequest != null)
                    {
                        webRequest.Method = "GET";
                        if (oAuthMode == true)
                        {
                            webRequest.Headers.Add("Authorization", "Bearer " + token);
                        }
                        else
                        {
                            webRequest.Headers["tabcorpauth"] = token;
                        }
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 20000;
                        webRequest.ContentType = "application/json";

                        requestTB.Text = FormatJson(uri.ToString());
                        DateTime start = DateTime.Now;
                        HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                        //print the response status code
                        int statusCode = getResponseCode(resp);
                        PrintStatusCode(resp, statusCode);

                        TimeSpan timeItTook = DateTime.Now - start;
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("LocationWindowsGET call: Request: ", System.Diagnostics.EventLogEntryType.Information);
                        }

                        Stream resStream = resp.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        ret = reader.ReadToEnd();
                        if (LogMsgCKB.Checked)
                        {
                            log.LogError("LocationWindowsGET call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                            log.LogError("LocationWindowsGET call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                        }

                        var jss = new JavaScriptSerializer();
                        dynamic response = jss.DeserializeObject(ret);
                        ResponseTB.Text = FormatJson(ret.ToString());
                        ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                    }
                }
                catch (WebException error)
                {
                    PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                    var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                    ResponseTB.Text = resp;
                    ResponseTB.Refresh();
                    log.LogError("LocationWindowsGET call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
                }
            }
        }




        public void getBonusBetTokens()
        {
            string ret = string.Empty;
            WebClient webClient = new WebClient();
            Uri uri = new Uri(AddressCB.Text.Replace("webapi","beta") + "/v1/tab-promotions-service/accounts/" + accountNo + "/bonus-bets");
            var webRequest = System.Net.WebRequest.Create(uri) as HttpWebRequest;

            //Get a New generated UUID
            string guild = returnGUID();

            // authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential("tablet", "Tabc0rp2014"));
            webRequest.Credentials = cache;
            //This will ignore certificate type issues.
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });

            try
            {

                if (webRequest != null)
                {
                    webRequest.Method = "GET";
                    webRequest.ServicePoint.Expect100Continue = false;
                    webRequest.Timeout = 20000;
                    webRequest.ContentType = "application/json";
                    if (oAuthMode == true)
                    {
                        webRequest.Headers.Add("Authorization", "Bearer " + token);
                    }
                    else
                    {
                        webRequest.Headers["tabcorpauth"] = token;
                    }

                    requestTB.Text = FormatJson(uri.ToString());

                    DateTime start = DateTime.Now;
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("getBonusBetTokens call: Request: " + requestTB.Text, System.Diagnostics.EventLogEntryType.Information);
                    }
                    HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                    TimeSpan timeItTook = DateTime.Now - start;
                    //print the response status code
                    int statusCode = getResponseCode(resp);
                    PrintStatusCode(resp, statusCode);


                    Stream resStream = resp.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    ret = reader.ReadToEnd();
                    //requestWriter.Close();
                    //Console.WriteLine(ret);
                    if (LogMsgCKB.Checked)
                    {
                        log.LogError("getBonusBetTokens call: Response:\r\n" + FormatJson(ret.ToString()), System.Diagnostics.EventLogEntryType.SuccessAudit);
                        log.LogError("getBonusBetTokens call: Time taken " + timeItTook, System.Diagnostics.EventLogEntryType.Information);
                    }
                    var jss = new JavaScriptSerializer();
                    dynamic response = jss.DeserializeObject(ret);


                    ResponseTB.Text = FormatJson(ret.ToString());
                    ResTimeLBL.Text = "Response Time: " + ((timeItTook < TimeSpan.Zero) ? "-" : "") + timeItTook.ToString(@"hh\:mm\:ss\:ff");
                }
            }
            catch (WebException error)
            {
                PrintExceptionCode(error); //Print Error code e.g. 504 Service Unavailable on bottom of screen.
                var resp = new StreamReader(error.Response.GetResponseStream()).ReadToEnd();
                ResponseTB.Text = FormatJson(resp.ToString());
                ResponseTB.Refresh();
                log.LogError("getBonusBetTokens call: Details of reason: [] {0}" + resp, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        private void InVenueCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActManCallsCB.Text = "";
            BettingCB.Text = "";
            RacingInfoCB.Text = "";
            SportsInfoCB.Text = "";

            if (InVenueCB.Text == "Commissions")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                InVenueCommissionsUC usr1 = new InVenueCommissionsUC(this);
                usr1.Show();
                panel1.Controls.Add(usr1);
            }
            if (InVenueCB.Text == "Configuration")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                InVenueConfigurationUC usr2 = new InVenueConfigurationUC(this);
                usr2.Show();
                panel1.Controls.Add(usr2);
            }
            if (InVenueCB.Text == "Venues")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                InVenueVenueUC usr3 = new InVenueVenueUC(this);
                usr3.Show();
                panel1.Controls.Add(usr3);
            }
            if (InVenueCB.Text == "Display-Devices")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                InVenueDisplayDevicesUC usr4 = new InVenueDisplayDevicesUC(this);
                usr4.Show();
                panel1.Controls.Add(usr4);
            }
            if (InVenueCB.Text == "Terminals")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                InVenueTerminalsUC usr5 = new InVenueTerminalsUC(this);
                usr5.Show();
                panel1.Controls.Add(usr5);
            }
            if (InVenueCB.Text == "AML Event")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                AMLinvenueEventsUC usr6 = new AMLinvenueEventsUC(this);
                usr6.Show();
                panel1.Controls.Add(usr6);
            }
            if (InVenueCB.Text == "Retail-Device")
            {
                panel1.Controls.Clear();
                panel1.Visible = true;
                RetailDeviceUC usr7 = new RetailDeviceUC(this);
                usr7.Show();
                panel1.Controls.Add(usr7);
            }
        }

        public int PrintExceptionCode(WebException e)
        {
            int statusCode = 0;
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse sc = ((HttpWebResponse)e.Response);
                statusCode = getResponseCode(sc);
                PrintStatusCode(sc, statusCode);
            }

            return statusCode;
        }
        public int getResponseCode(HttpWebResponse response)
        {
            HttpStatusCode statusCode;
            statusCode = response.StatusCode;
            int code = (int)statusCode;

            return code;
        }
        public void PrintStatusCode(HttpWebResponse response, int code)
        {
            statusCodeLBL.Text = "Response Code: " + code.ToString() + " [" + response.StatusCode.ToString() + "]";
            statusCodeLBL.Refresh();
        }

        private void AddressCB_Leave(object sender, EventArgs e)
        {
            if (AddressCB.Text == "https://uat01.webapi.tab.com.au" || AddressCB.Text == "https://uat01.beta.tab.com.au")
            {
                enviornmentLBL.Text = "YARRA";
                clientId = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
                clientSecret = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
                AMLtoken = "5065157db002f1d9f70cbf8f1489fb8806748308";
            }
            else if (AddressCB.Text == "https://uat02.beta.tab.com.au" || AddressCB.Text == "https://uat02.webapi.tab.com.au")
            {
                enviornmentLBL.Text = "MURRAY";
                clientId = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
                clientSecret = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
                AMLtoken = "5065157db002f1d9f70cbf8f1489fb8806748308";
            }
            else if (AddressCB.Text == "http://10.26.128.209:8080")
            {
                enviornmentLBL.Text = "MEKONG";
                clientId = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
                clientSecret = "b0eb33de-aa74-4832-a7c9-a7599b85b552";
                AMLtoken = "5065157db002f1d9f70cbf8f1489fb8806748308";
            }
            else if (AddressCB.Text == "https://pre.webapi.tab.com.au" || AddressCB.Text == "https://pre-api.beta.tab.com.au")
            {
                enviornmentLBL.Text = "NILE";
                clientId = "3846e606-3985-4d00-b1bd-5bf5c7b0faa3";
                clientSecret = "84e4376a-11d3-4d3a-8313-5f5757272f09";
                AMLtoken = "e60a776ce4abb0525744986edd002c4acba829ea";
            }
            else if (AddressCB.Text == "https://api.beta.tab.com.au")
            {
                enviornmentLBL.Text = "PROD - BE CAREFULL!!";
            }
            else
            {
                enviornmentLBL.Text = "";
            }

        }
    } 
}
    
