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

namespace org.restcomm.connect.sdk.dotnet
{
    public struct classproperty
    {
        //public	account Account;

    }
    public struct accountProperties
    {
        public string sid { get; set; }
        public string friendly_name { get; set; }
        public string status { get; set; }
        public string date_updated { get; set; }
        public string date_created { get; set; }
        public string auth_token { get; set; }
        public string uri { get; set; }
    }
    public struct callProperties
    {

        public string sid { get; set; }
        public string parent_call_sid { get; set; }
        public string date_created { get; set; }
        public string date_updated { get; set; }
        public string to { get; set; }
        public string from { get; set; }
        public string phone_number_sid { get; set; }
        public string status { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string duratiom { get; set; }
        public string price { get; set; }
        public string direction { get; set; }
        public string answered_by { get; set; }
        public string api_version { get; set; }
        public string forward_from { get; set; }
        public string caller_name { get; set; }
        public string uri { get; set; }

    }
    public struct applicationProperties
    {
        public string sid { get; set; }
        public String account_sid { get; set; }
        public String friendly_Name { get; set; }
        public String date_updated { get; set; }
        public String date_created { get; set; }
        public String api_version { get; set; }
        public String kind { get; set; }
        public String voice_caller_id_lookup { get; set; }
        public string rcml_url { get; set; }
        public string uri { get; set; }

    }
   
    public struct numberProperties
    {

        public string friendlyName { get; set; }
        public string phoneNumber { get; set; }
        public string isoCountry { get; set; }
        public string cost { get; set; }
        public string voiceCapable { get; set; }
        public string smsCapable { get; set; }

    }
public struct clientProperties
    {
        public string sid { get; set; }
        public string date_created { get; set; }
        public string date_updated { get; set; }
        public string friendly_name { get; set; }
        public string account_sid { get; set; }
        public string api_version { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string voice_url { get; set; }
        public string voice_method { get; set; }
        public string voice_fallback_url { get; set; }
        public string voice_fallback_method { get; set; }
        public string voice_application { get; set; }
        public string uri { get; set; }

    }
    public struct gatewayproperties
    {
        public string Sid { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string FriendlyName { get; set; }
        public string Password { get; set; }
        public string Proxy { get; set; }
        public string Register { get; set; }
        public string UserName { get; set; }
        public string TimeToLive { get; set; }
        public string Uri { get; set; }


    }
    public struct NotificationProperties
    {
        public string sid { get; set; }
        public string date_created { get; set; }
        public string date_updated { get; set; }
        public string account_sid { get; set; }
        public string call_sid { get; set; }
        public string api_version { get; set; }
        public string log { get; set; }
        public string error_code { get; set; }
        public string more_info { get; set; }
        public string message_text { get; set; }
        public string message_date { get; set; }
        public string request_url { get; set; }
        public string request_method { get; set; }
        public string request_variables { get; set; }
        public string response_body { get; set; }
        public string response_headers { get; set; }
        public string uri { get; set; }
    }

}

