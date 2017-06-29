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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace org.restcomm.connect.sdk.dotnet
{
    public static class jsonoperation
    {
        public static string GetPropertyJson(this string jsonstring, string property)
        {

            jsonstring = Regex.Replace(jsonstring, @"[^\u0000-\u007F]+", string.Empty);
            JObject jdata = JObject.Parse(jsonstring);
            string propertyvalue = jdata.Value<string>(property);
            if (propertyvalue != null)
                return propertyvalue;
            else return "";
        }
        public static List<string> GetPropertiesJson(this string jsonstring, string property)
        {
            jsonstring = Regex.Replace(jsonstring, @"[^\u0000-\u007F]+", string.Empty);
            JArray j;

            if (jsonstring.ToLower().Contains('['))
            {

                jsonstring = "[" + jsonstring.Split('[', ']')[1] + "]";
                jsonstring = Regex.Replace(jsonstring, @"[^\u0000-\u007F]+", string.Empty);

            }

           
                j = JArray.Parse(jsonstring);
         
           
            var values = j.Values<string>(property).ToArray();
            List<string> valuelist = new List<string>();
            if (values != null&&values.Length!=0) { 
                    valuelist = values.Cast<string>().ToList();

                    return valuelist;
        }
            else
            {
                List<string> empty = new List<string>();
                int i = 0;
                while (i<200)
                {
                    empty.Add("");
                    i++;
                }
                return empty;

            }
        }
    }

}
