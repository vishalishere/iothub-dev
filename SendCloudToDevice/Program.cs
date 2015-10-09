using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;

namespace SendCloudToDevice
{
    class Program
    {
        static ServiceClient serviceClient;
        static string connectionString = "HostName=iothub-dev.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=W0ZPIjKEUxeB+1g95DAN8eZgQ99G+JmIUTaC7KYemgs=";
        static void Main(string[] args)
        {
            serviceClient = ServiceClient.CreateFromConnectionString(connectionString);

            Console.WriteLine("Send Cloud-to-Device message\n");
            string message;
            do
            {
                Console.Write("Please type any message to send a C2D message: ");
                message = Console.ReadLine();
                SendCloudToDeviceMessageAsync(message).Wait();
                
            } while (message != "quit");

            Console.ReadLine();
        }

        private async static Task SendCloudToDeviceMessageAsync(string message)
        {
            var commandMessage = new Message(Encoding.ASCII.GetBytes(message));
            await serviceClient.SendAsync("myFirstDevice", commandMessage);
        }
    }
}
