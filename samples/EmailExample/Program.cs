using System;
using org.restcomm.connect.sdk.dotnet;
namespace Email
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Login 
            Account akount = new Account("Enter your sid here", "Enter your authtoken here", "https://cloud.restcomm.com/restcomm/2012-04-24/");

            var EmailData = akount.SendEmail("demo123@restcomm.com", "abcd@myemail.com", "This is a test email", "Test");
            EmailData.Send();
            Console.ReadLine();
        }
    }
}

