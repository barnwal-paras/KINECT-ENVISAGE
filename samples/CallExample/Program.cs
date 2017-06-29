using System;
using org.restcomm.connect.sdk.dotnet;
using System.Collections.Generic;

namespace Calls
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            //Login 
            Account akount = new Account("Enter your sid here", "Enter your authtoken here", "https://cloud.restcomm.com/restcomm/2012-04-24/");

            //Makes call
            var OutBCall = akount.MakeCall("From?", "client:democlients", "http://cloud.restcomm.com/restcomm/demos/hello-play.xml");
            //adds parameter in call
            OutBCall.AddParameter("Timeout", "15");
            Call call = OutBCall.call();

            //Prints call status
            Console.WriteLine(call.Properties.status);

            //Gets list of all call
            List<Call> calllist = akount.GetCallDetail().Search();

            //Prints the name of client recieving call
            foreach (Call c in calllist)
            {

                Console.WriteLine(c.Properties.to);
            }
            Console.ReadLine();
        }
    }
}
