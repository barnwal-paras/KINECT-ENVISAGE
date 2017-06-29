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
namespace org.restcomm.connect.sdk.dotnet
{
    public partial class Account
    {
        public string GetGatewayList()
        {
            RestClient client = new RestClient(baseurl + "Accounts/" + Properties.sid + "/Management/Gateways.json");
            RestRequest request = new RestRequest(Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            IRestResponse response = client.Execute(request);
            return response.Content;

        }


    }
    public class Gateway
    {
        public gatewayproperties Properties;

        public Gateway(IRestResponse response)
        {

        }
        
    }
}

