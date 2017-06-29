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
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Text.RegularExpressions;



namespace org.restcomm.connect.sdk.dotnet
{

    public partial class Account
    {

        public accountProperties Properties;


        public static string baseurl;

        //constructor method to instantiate account 

        public Account(string sid, string Tokenno, string baseurl)
        {
            Account.baseurl = baseurl;

            RestClient client = new RestClient(baseurl + "Accounts.json/" + sid);
            RestRequest login = new RestRequest(Method.GET);
           
            client.Authenticator = new HttpBasicAuthenticator(sid, Tokenno);
           
            IRestResponse response = client.Execute(login);
            var content = response.Content;
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            Properties = JsonConvert.DeserializeObject<accountProperties>(content);
        

        }

        public void ChangePassword(string NewPassword)
        {

            RestClient client = new RestClient(baseurl + "Accounts.json/" + Properties.sid);
            RestRequest login = new RestRequest(Method.POST);

            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            login.AddParameter("Password", NewPassword);
            IRestResponse response = client.Execute(login);
            var content = response.Content;



            Properties.date_updated = content.GetPropertyJson("date_updated");

            Properties.auth_token = content.GetPropertyJson("auth_token");



        }

        public SubAccount CreateSubAccount(string FriendlyName, string emailid, string password)
        {

            RestClient client = new RestClient(baseurl + "Accounts.json/");
            RestRequest login = new RestRequest(Method.POST);
            login.AddParameter("FriendlyName", FriendlyName);
            login.AddParameter("EmailAddress", emailid);
            login.AddParameter("Password", password);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            IRestResponse response = client.Execute(login);
            var content = response.Content;
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            SubAccount newaccount = new SubAccount(content.GetPropertyJson("sid"), content.GetPropertyJson("auth_token"), Account.baseurl);
           return newaccount;


        }

        public List<SubAccount> GetSubAccountList()
        {

            RestClient client = new RestClient(baseurl + "Accounts.json");
            RestRequest login = new RestRequest(Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            IRestResponse response = client.Execute(login);
            var content = response.Content;
            
            List<string> sidlist = content.GetPropertiesJson("sid");
            if (sidlist != null)
            {
                List<string> authtokenlist = content.GetPropertiesJson("auth_token");

                List<SubAccount> subaccountlist = new List<SubAccount>();
                for (int i = 0; i < sidlist.Count; i++)
                {
                    subaccountlist.Add(new SubAccount(sidlist[i], authtokenlist[i], Account.baseurl));

                }
                
                return subaccountlist;
            }
            else
                return null;

        }




    }



    public class SubAccount : Account
    {
        public SubAccount(string Sid, string Tokenno, string baseurl) : base(Sid, Tokenno, baseurl = Account.baseurl)
        {

        }

        public string CloseSubAccount()
        {
            RestClient client = new RestClient(baseurl + "Accounts.json/" + Properties.sid);
            RestRequest login = new RestRequest(Method.PUT);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            login.AddParameter("Status", "closed");
            IRestResponse response = client.Execute(login);
            return response.Content;
        }

    }
}



