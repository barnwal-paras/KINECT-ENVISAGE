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
using System.Threading;
using System.Collections.Generic;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

using Newtonsoft.Json;


namespace Test
{
    public static class MockServer
    {
        public static string hostaddress = "http://localhost:9090/";
        public static FluentMockServer server;
        public static String Sid;
        public static String AuthToken;


        static MockServer()
        {

            server = FluentMockServer.Start(new FluentMockServerSettings
            {
                Urls = new[] { hostaddress },
                StartAdminInterface = true,
                ReadStaticMappings = true
            });
            
        }


        public static void AddAuthentication(string sid, string authToken)
        {

            server.SetBasicAuthentication(sid, authToken);
            Sid = sid;
            AuthToken = authToken;
        }



        public static void AddGetRequest(string path, string response)
        {
            server
                .Given(Request.Create().WithPath(path)
                    .UsingGet()
                    .WithHeader("Authorization", "Basic " + Convert.ToBase64String(
                        System.Text.ASCIIEncoding.ASCII.GetBytes(
                            string.Format("{0}:{1}", Sid, AuthToken)))))
                .RespondWith(Response.Create()
                    .WithStatusCode(200)
                    .WithBody(response));


        }
        public static void AddPutRequest(string path, Dictionary<string, string> parameter, string response)
        {

            List<string> paralist = new List<string>();
            foreach (var pair in parameter)
            {
                paralist.Add(pair.Key + "=" + pair.Value);

            }


            server
                    .Given(Request.Create().WithPath(path)
                        .UsingPost()
                        .WithBody(b => b.Contain(paralist))
                            .WithHeader("Authorization", "Basic " + Convert.ToBase64String(
                                System.Text.Encoding.ASCII.GetBytes(
                                    string.Format("{0}:{1}", Sid, AuthToken))))
                        )
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBody(response));
        }
        public static void AddPostRequest(string path, Dictionary<string, string> parameter, string response)
        {

            List<string> paralist = new List<string>();
            foreach (var pair in parameter)
            {
                paralist.Add(pair.Key+"="+pair.Value);
              
            }
            
        
            server
                    .Given(Request.Create().WithPath(path)
                        .UsingPost()
                        .WithBody(b => b.Contain(paralist))
                            .WithHeader("Authorization", "Basic " + Convert.ToBase64String(
                                System.Text.Encoding.ASCII.GetBytes(
                                    string.Format("{0}:{1}", Sid, AuthToken))))
                        )
                        .RespondWith(Response.Create()
                            .WithStatusCode(200)
                            .WithBody(response));   
        }


        private static bool Contain(this string stringtext,List<string> stringlist)
        {
            bool k = true;
            foreach(string s in stringlist)
            {
                if (!stringtext.Contains(s))
                    k = false;
            }
            return k;
        }

      
        private static IList<IList<T>> Permutations<T>(IList<T> list)
        {
            List<IList<T>> perms = new List<IList<T>>();
            if (list.Count == 0)
                return perms; // Empty list.
            int factorial = 1;
            for (int i = 2; i <= list.Count; i++)
                factorial *= i;
            for (int v = 0; v < factorial; v++)
            {
                List<T> s = new List<T>(list);
                int k = v;
                for (int j = 2; j <= list.Count; j++)
                {
                    int other = (k % j);
                    T temp = s[j - 1];
                    s[j - 1] = s[other];
                    s[other] = temp;
                    k = k / j;
                }
                perms.Add(s);
            }
            return perms;
        }
       

    }


}

