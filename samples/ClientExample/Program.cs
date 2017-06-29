using System;
using System.Collections.Generic;
using org.restcomm.connect.sdk.dotnet;

class MainClass
{
    public static void Main(string[] args)
    {
        //Login 
          Account akount = new Account("Enter your sid here", "Enter your authtoken here", "https://cloud.restcomm.com/restcomm/2012-04-24/");
        //Creates a client
        Client client = akount.makeclient("paras121", "Demo@1234").Create();

        Console.WriteLine(client.Properties.sid);

        //Gets list of all client
        List<Client> clientlist = akount.GetClientList();
        foreach (Client c in clientlist)
        {
            Console.WriteLine(c.Properties.friendly_name);

        }

       // Changes password of client
         client.ChangePassword(akount.Properties.sid, akount.Properties.auth_token, "Demo@123");


        //Deletes client
          client.Delete(akount.Properties.sid, akount.Properties.auth_token);

        Console.ReadLine();
    }
}

