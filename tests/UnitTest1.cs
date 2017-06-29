// /*
//  * TeleStax, Open Source Cloud Communications
//  * Copyright 2011-2016, Telestax Inc and individual contributors
//  * by the @Paras Kumar(parasbarnwal06@gmail.com).
//  *
//  * This is free software; you can redistribute it and/or modify it
//  * under the terms of the GNU Lesser General Public License as
//  * published by the Free Software Foundation; either version 2.1 of
//  * the License, or (at your option) any later version.
//  *
//  * This software is distributed in the hope that it will be useful,
//  * but WITHOUT ANY WARRANTY; without even the implied warranty of
//  * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  * Lesser General Public License for more details.
//  *
//  * You should have received a copy of the GNU Lesser General Public
//  * License along with this software; if not, write to the Free
//  * Software Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA
//  * 02110-1301 USA, or see the FSF site: http://www.fsf.org.
//  */
//


using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using org.restcomm.connect.sdk.dotnet;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;



namespace Test
{//In Credentials.txt(Project/bin/Debug)
 //First Line : Account Sid
 //Second Line :Authentication Token
 //Third Line :Login Password
    [TestFixture]
    public class NUnitTestClass
    {
#pragma warning disable

        string Sid = "test";
        string authtoken = "testpassword";

        Account akount;
        string baseurl;
        string loginresponse= "{\n  \"sid\": \"test\",\n  \"friendly_name\": \"DummyAccount\",\n  \"email_address\": \"account@localhost.com\",\n  \"type\": \"Full\",\n  \"status\": \"active\",\n  \"role\": \"Administrator\",\n  \"date_created\": \"Tue, 16 May 2017 07:20:44 +0000\",\n  \"date_updated\": \"Mon, 12 Jun 2017 11:45:43 +0000\",\n  \"auth_token\": \"testpassword\",\n  \"uri\": \"/2012-04-24/Accounts.json/AC43b4d94a9b2\",\n  \"subresource_uris\": {\n    \"available_phone_numbers\": \"/2012-04-24/Accounts/AC43b4d94a9b2/AvailablePhoneNumbers.json\",\n    \"calls\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Calls.json\",\n    \"conferences\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Conferences.json\",\n    \"incoming_phone_numbers\": \"/2012-04-24/Accounts/AC43b4d94a9b2/IncomingPhoneNumbers.json\",\n    \"notifications\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Notifications.json\",\n    \"outgoing_caller_ids\": \"/2012-04-24/Accounts/AC43b4d94a9b2/OutgoingCallerIds.json\",\n    \"recordings\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Recordings.json\",\n    \"sandbox\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Sandbox.json\",\n    \"sms_messages\": \"/2012-04-24/Accounts/AC43b4d94a9b2/SMS/Messages.json\",\n    \"transcriptions\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Transcriptions.json\"\n  }\n}";
        string changepasswordresponse = "{\n  \"sid\": \"test\",\n  \"friendly_name\": \"DummyAccount\",\n  \"email_address\": \"account@localhost.com\",\n  \"type\": \"Full\",\n  \"status\": \"active\",\n  \"role\": \"Administrator\",\n  \"date_created\": \"Tue, 16 May 2017 07:20:44 +0000\",\n  \"date_updated\": \"Mon, 12 Jun 2017 11:45:43 +0000\",\n  \"auth_token\": \"newpassword\",\n  \"uri\": \"/2012-04-24/Accounts.json/AC43b4d94a9b2\",\n  \"subresource_uris\": {\n    \"available_phone_numbers\": \"/2012-04-24/Accounts/AC43b4d94a9b2/AvailablePhoneNumbers.json\",\n    \"calls\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Calls.json\",\n    \"conferences\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Conferences.json\",\n    \"incoming_phone_numbers\": \"/2012-04-24/Accounts/AC43b4d94a9b2/IncomingPhoneNumbers.json\",\n    \"notifications\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Notifications.json\",\n    \"outgoing_caller_ids\": \"/2012-04-24/Accounts/AC43b4d94a9b2/OutgoingCallerIds.json\",\n    \"recordings\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Recordings.json\",\n    \"sandbox\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Sandbox.json\",\n    \"sms_messages\": \"/2012-04-24/Accounts/AC43b4d94a9b2/SMS/Messages.json\",\n    \"transcriptions\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Transcriptions.json\"\n  }\n}";
        string callresponse = "{\n  \"sid\": \"testcall\",\n  \"InstanceId\": \"ID189\",\n  \"date_created\": \"Mon, 19 Jun 2017 17:55:34 +0000\",\n  \"date_updated\": \"Mon, 19 Jun 2017 17:55:34 +0000\",\n  \"account_sid\": \"AC43b4d94a9b2\",\n  \"to\": \"To\",\n  \"from\": \"From\",\n  \"status\": \"QUEUED\",\n  \"start_time\": \"2017-06-19T17:55:34.000Z\",\n  \"price_unit\": \"USD\",\n  \"direction\": \"outbound-api\",\n  \"api_version\": \"2012-04-24\",\n  \"caller_name\": \"From\",\n  \"uri\": \"/2012-04-24/Accounts/A1862583c8638b26f2/Calls/CA57c2cb6154854e73b.json\",\n  \"subresource_uris\": {\n    \"notifications\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Calls/CA57c2cb6154854e73be/Notifications.json\",\n    \"recordings\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Calls/CA57c2cb6154854587ef/Recordings.json\"\n  }\n}";
        string clientresponse = "{\n  \"sid\": \"dummyclient\",\n  \"date_created\": \"Mon, 19 Jun 2017 19:50:19 +0000\",\n  \"date_updated\": \"Mon, 19 Jun 2017 19:50:19 +0000\",\n  \"account_sid\": \"AC43b4d94a9b2b1862583c8638b70d26f2\",\n  \"api_version\": \"2012-04-24\",\n  \"friendly_name\": \"DemoClient\",\n  \"login\": \"DemoClient\",\n  \"password\": \"Demo@1234\",\n  \"status\": \"1\",\n  \"voice_method\": \"POST\",\n  \"voice_fallback_method\": \"POST\",\n  \"uri\": \"/2012-04-24/Accounts/AC43b4d94a9b2b1862583c8638b70d26f2/Clients/CL0e6aa31b0c36401ea5abd728187f3623.json\"\n}";
        string appresponse = "{\n  \"sid\": \"dummyapp\",\n  \"date_created\": \"Mon, 19 Jun 2017 20:45:35 +0000\",\n  \"date_updated\": \"Mon, 19 Jun 2017 20:45:35 +0000\",\n  \"friendly_name\": \"testappps\",\n  \"account_sid\": \"AC43b4d94a9b2\",\n  \"api_version\": \"2012-04-24\",\n  \"voice_caller_id_lookup\": false,\n  \"uri\": \"/2012-04-24/Accounts/AC43b4d94a9b2/Applications/APdb12dfe7961d4a1b8e6b.json\"\n}";
        string emailresponse = "{\n  \"date_sent\": \"2017-06-19T21:04:56.040Z\",\n  \"account_sid\": \"AC43b4d94a9b2\",\n  \"from\": \"demo123@localhost.com\",\n  \"to\": \"demo345@localhost.com\",\n  \"body\": \"This is a test email\",\n  \"subject\": \"Test\"\n}";
        string numberresponse = "[{ \"friendlyName\": \"+12034848530\", \"phoneNumber\": \"12034848530\", \"isoCountry\": \"US\", \"cost\": \"0.67\", \"voiceCapable\": \"true\", \"smsCapable\": \"true\" }]";
        string notificationresponse = "[\n    {\n      \"sid\": \"NOa6b821987c1e47b4b91d2678fdndjdn\",\n      \"date_created\": \"Wed, 17 May 2017 11:09:40 +0000\",\n      \"date_updated\": \"Wed, 17 May 2017 11:09:40 +0000\",\n      \"account_sid\": \"AC43b4d94a9b2\",\n      \"api_version\": \"2012-04-24\",\n      \"log\": 0,\n      \"error_code\": 11001,\n      \"more_info\": \"/restcomm/errors/11001.html\",\n      \"message_text\": \"Cannot Connect to Client: bob : Make sure the Client exist or is registered with Restcomm\",\n      \"message_date\": \"2017-05-17T11:09:40.000Z\",\n      \"request_url\": \"\",\n      \"request_method\": \"\",\n      \"request_variables\": \"\",\n      \"uri\": \"/2012-04-24/Accounts/AC13b4372c/Notifications/NOa6b82198.json\"\n    }\n   ]";

        [SetUp]
        public void Login()
        {
            //MockServer.AddGetRequest
            

                baseurl = MockServer.hostaddress + "restcomm/2012-04-24/";
                MockServer.AddAuthentication(Sid, authtoken);
                MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts.json/" + Sid, loginresponse);
                Thread.Sleep(500);
          
               akount = new Account(Sid, authtoken, baseurl);

            
        }
        [Test]
        public void AccountLogin()
        {
            Assert.AreEqual( "test", akount.Properties.sid);

        }
        [Test]
        public void ChangePassword()
        {

            var paradictionary = new Dictionary<string, string>();
            paradictionary.Add("Password", "newpassword");
            MockServer.AddPostRequest("/restcomm/2012-04-24/Accounts.json/" + Sid, paradictionary, changepasswordresponse);
            string oldauthtoken = akount.Properties.auth_token;
                akount.ChangePassword("newpassword");

                string newauthtoken = akount.Properties.auth_token;
                Assert.AreNotEqual(newauthtoken, oldauthtoken);

            
        }

        	[Test]
            public void  CreateSubAccount()
        {
            var paradictionary = new Dictionary<string, string>();
            paradictionary.Add("FriendlyName", "password");
            paradictionary.Add("EmailAddress", "b");
            paradictionary.Add("Password", "c");

            MockServer.AddPostRequest("/restcomm/2012-04-24/Accounts.json/", paradictionary, loginresponse);
            
            SubAccount a = akount.CreateSubAccount ("password", "b", "c");
          
            Assert.IsNotNull(a.Properties.friendly_name);
            }

          
            [Test]
            public void SubAccountListing(){
            string subaccountlistresponse = "[" + loginresponse + "]";
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts.json", subaccountlistresponse);
                List<SubAccount> subaccountlist= akount.GetSubAccountList ();
                    Assert.AreEqual (subaccountlist.Count, 1);
                }
        
        [Test]
        public void MakeCall()
        {
        
            var paradictionary = new Dictionary<string, string>();
            paradictionary.Add("From", "Client1");
           paradictionary.Add("To", "Client2");
            paradictionary.Add("Url", "site.com");
            MockServer.AddPostRequest("/restcomm/2012-04-24/Accounts/" +akount.Properties.sid + "/Calls.json", paradictionary, callresponse);
            
           Call calldetail= akount.MakeCall("Client1", "Client2", "site.com").call();
            Assert.AreEqual("testcall", calldetail.Properties.sid);
        }
        [Test]
        public void GetCallDetail()
        {
            string calldetailresponse = "[" + callresponse + "]";
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/"+akount.Properties.sid+"/Calls.json", calldetailresponse);
           List<Call> calllist= akount.GetCallDetail().Search();
            Assert.AreEqual(1, calllist.Count);
        }
        [Test]
        public void CreateClient()
        {
            var paradictionary = new Dictionary<string, string>();
            paradictionary.Add("Login", "username");
            paradictionary.Add("Password", "password");
            MockServer.AddPostRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Clients.json", paradictionary, clientresponse);
           Client c= akount.makeclient("username", "password").Create();
            Assert.AreEqual("dummyclient", c.Properties.sid);
        }
        [Test]
        public void ClientList()
        {
        string    clientlistresponse = "["+clientresponse+ "]";
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Clients.json",clientlistresponse);
            List<Client> clientlist = akount.GetClientList();
            Assert.AreEqual(1, clientlist.Count);
        }
        [Test]
        public void makeapp()
        {
            var paradictionary = new Dictionary<string, string>();
            paradictionary.Add("FriendlyName", "appname");
            MockServer.AddPostRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Applications.json", paradictionary, appresponse);
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Applications" + "/dummyapp.json", appresponse);
            Application a= akount.CreateApplication("appname");
            Assert.AreEqual("dummyapp", a.Properties.sid);

        }
        [Test]
        public void applist()
        {
            string applistresponse = "[" + appresponse + "]";
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Applications.json", applistresponse);
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Applications"+"/dummyapp.json", appresponse);
            List<Application> a = akount.GetApplicationList();
            Assert.AreEqual(1, a.Count);
        }
        [Test]
        public void SendMail()
        {
            var paradictionary = new Dictionary<string, string>();
            paradictionary.Add("From", "emailid1");
            paradictionary.Add("To", "emailid2");
            paradictionary.Add("Body", "emailbody");
            paradictionary.Add("Subject", "Subject");
           
            MockServer.AddPostRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Email/Messages.json", paradictionary, emailresponse);
            akount.SendEmail("emailid1", "emailid2", "emailbody","Subject").Send();
            //will throw a error if something goes wrong
        }
        [Test]
        public void NumberSearch()
        {
            numberresponse=numberresponse.Replace((char)39,'"');
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/AvailablePhoneNumbers/US/Local.json", numberresponse);
           var numberlist= akount.SearchPhoneNumbers("US").Search();
            Assert.AreEqual("0.67", numberlist[0].Properties.cost); 
        }
        [Test]
        public void NotificationTest()
        {
            MockServer.AddGetRequest("/restcomm/2012-04-24/Accounts/" + akount.Properties.sid + "/Notifications.json",notificationresponse);
           
            var parameter = new Dictionary<string, string>();
          
            List<Notification> NotificationList = akount.GetNotificationList(parameter);
            Console.WriteLine(NotificationList[0].Properties.log);
            Assert.AreEqual(NotificationList[0].Properties.log, "0");
           
        }
    }
}
