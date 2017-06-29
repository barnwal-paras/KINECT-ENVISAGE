using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace org.restcomm.connect.sdk.dotnet
{
    partial class Account
    {
     public List<Notification>   GetNotificationList(Dictionary<string ,string> parameters=null)
        {
            RestClient client = new RestClient(baseurl + "Accounts/" + Properties.sid +"/Notifications.json");
            client.Authenticator = new HttpBasicAuthenticator(Properties.sid, Properties.auth_token);
            RestRequest request = new RestRequest(Method.GET);
            foreach(var pair in parameters)
            {
                request.AddQueryParameter(pair.Key, pair.Value);
      
            }
         
           IRestResponse response = client.Execute(request);
            var content = response.Content;
            content ="["+content.Split('[',']')[1]+"]";
            content = Regex.Replace(content, @"[^\u0000-\u007F]+", string.Empty);
            var notificationpropertieslist = JsonConvert.DeserializeObject<List<NotificationProperties>>(content);
            var NotificationList = new List<Notification>();
            foreach (NotificationProperties n in notificationpropertieslist)
            {
                NotificationList.Add(new Notification(n));
            }
            return NotificationList;
        }
        
    }
   public class Notification
    {
        public NotificationProperties Properties;
        public Notification(NotificationProperties Properties)
        {
            this.Properties = Properties;
        }

    }
}
