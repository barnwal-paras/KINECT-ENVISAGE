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
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace org.restcomm.connect.sdk.dotnet
{

    public partial class Account
    {
        public List<Client> GetClientList()
        {
            RestClient client = new RestClient(baseurl + "Accounts/" + Properties.sid + "/Clients.json");
            RestRequest request = new RestRequest(Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            IRestResponse response = client.Execute(request);
            var content = response.Content;
            List<Client> clientslist = new List<Client>();
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            var Propertieslist = JsonConvert.DeserializeObject<List<clientProperties>>(content);
            foreach(clientProperties properties in Propertieslist)
            {
                clientslist.Add(new Client(properties));
            }
          
            return clientslist;

        }
        public MakeClient makeclient(string Login, string Password)
        {
            RestClient client = new RestClient(baseurl + "Accounts/" + Properties.sid + "/Clients.json");
            RestRequest request = new RestRequest(Method.POST);
            request.AddParameter("Login", Login);
            request.AddParameter("Password", Password);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);

            return new MakeClient(client, request);

        }

    }
    public class Client
    {

        public clientProperties Properties;
        public Client(clientProperties properties)
        {
            Properties = properties;
        }
    
        public void Delete(String sid, string authtoken)
        {
            RestClient client = new RestClient(Account.baseurl + "Accounts/" + sid + "/Clients/" + Properties.sid+".json");
            RestRequest request = new RestRequest(Method.DELETE);
            client.Authenticator = new HttpBasicAuthenticator(sid, authtoken);
           IRestResponse response= client.Execute(request);
           
        }
        public void ChangePassword(String sid, string authtoken, string NewPassword)
        {
            RestClient client = new RestClient(Account.baseurl + "Accounts/" + sid + "/Clients/" + Properties.sid+".json");
            RestRequest request = new RestRequest(Method.PUT);
            client.Authenticator = new HttpBasicAuthenticator(sid, authtoken);
            request.AddParameter("Password", NewPassword);
            client.Execute(request);


        }
    }
    public class MakeClient
    {
        RestClient client;
        RestRequest request;
        public MakeClient(RestClient client, RestRequest request)
        {
            this.client = client;
            this.request = request;
        }
        public void AddParameter(string ParameterName, string ParameterValue)
        {   
            request.AddParameter(ParameterName, ParameterValue);
        }
        public Client Create()
        {

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            var Properties = JsonConvert.DeserializeObject<clientProperties>(content);
            return new Client(Properties);
        }

    }



}

