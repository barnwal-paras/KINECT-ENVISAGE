// /*
//  * TeleStax, Open Source Cloud Communications
//  * Copyright 2011-2016, Telestax Inc and individual contributors
//  * by the @Paras Kumar(parasbarnwal06@gmail.com)
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
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace org.restcomm.connect.sdk.dotnet
{
    
    public partial class Account
    {
        public makecall MakeCall(string From, string To, string Url)
        {
            RestClient client = new RestClient(baseurl + "Accounts/" + Properties.sid + "/Calls.json");
            RestRequest makecall = new RestRequest(Method.POST);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            makecall.AddParameter("From", From);
            makecall.AddParameter("To", To);
            makecall.AddParameter("Url", Url);

            return new makecall(client, makecall);

        }
        public CallFilter GetCallDetail()
        {

            RestRequest makecall = new RestRequest(Method.GET);
            return new CallFilter(makecall, Properties.sid, Properties.auth_token);

        }



    }
    public class CallFilter
    {
        RestClient client;
        RestRequest request;
        string Sid;
        string TokenNo;
        List<string> parametername = new List<string>();
        List<string> parametervalue = new List<string>();
        public CallFilter(RestRequest request, string Sid, string TokenNo)
        {

            this.request = request;
            this.Sid = Sid;
            this.TokenNo = TokenNo;
        }
        public void AddSearchFilter(string ParameterName, string ParameterValue)
        {
            parametername.Add(ParameterName);
            parametervalue.Add(ParameterValue);
        }
        public List<Call> Search()
        {
            string clienturl = Account.baseurl + "Accounts/" + Sid + "/Calls.json";
            if (parametername.Count != 0)
            {
                clienturl += "?";
                int i = 0;
                foreach (string s in parametername)
                {
                    if (i != 0)
                        clienturl += "&";
                    clienturl += parametername[i];
                    clienturl += "=" + parametervalue[i];
                    i++;
                }


            }

            client = new RestClient(clienturl);
            client.Authenticator = new HttpBasicAuthenticator(Sid, TokenNo);
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            content = "[" + content.Split('[', ']')[1] + "]";

            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            var callsproperties = JsonConvert.DeserializeObject<List<callProperties>>(content);
            List<Call> calllist = new List<Call>();
            foreach(callProperties c in callsproperties)
            {
                calllist.Add(new Call(c));
            }
            return calllist;
            
        }
        
        }


        public class makecall
        {

            RestClient Client;
            RestRequest Request;
            public makecall(RestClient client, RestRequest request)
            {
                Client = client;

                Request = request;

            }
            public void AddParameter(string ParameterName, string ParameterValue)
            {

                Request.AddParameter(ParameterName, ParameterValue);

            }
            public Call call()
            {
                IRestResponse response = Client.Execute(Request);
            var content = response.Content;
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            callProperties properties = JsonConvert.DeserializeObject<callProperties>(content);
                Call newcall = new Call(properties);
            return newcall;
            }
        }

        public class Call
        {

            public callProperties Properties;
            public Call(callProperties properties)
            {
                Properties = properties;
            }
       
            public void ModifyCall(Dictionary<string,string> parameter, String AccountSid, String AuthToken)
            {
           
            RestClient client = new RestClient(Account.baseurl + "Accounts/" + AccountSid + "/Calls.json/" + Properties.sid);
            RestRequest makecallmodification = new RestRequest(Method.POST);
                client.Authenticator = new HttpBasicAuthenticator(AccountSid,AuthToken);
            foreach (var pair in parameter)
            {
                makecallmodification.AddParameter(pair.Key, pair.Value);
            }
                IRestResponse response= client.Execute(makecallmodification);
                var content = response.Content;
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            Properties = JsonConvert.DeserializeObject<callProperties>(content);
        }


        }
        public struct CallParameters
        {
            public string Method { get { return "Method"; } }
            public string FallbackUrl { get { return "FallbackUrl"; } }
            public string FallbackMethod { get { return "FallbackMethod"; } }
            public string statusCallbackEvent { get { return "statusCallbackEvent"; } }
            public string statusCallback { get { return "statusCallback"; } }
            public string statusCallbackMethod { get { return "statusCallbackMethod"; } }
            public string Timeout { get { return "Timeout"; } }
        }

    
}

