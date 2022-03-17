using Autofac;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Model;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading;

namespace ChatRoom.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = Applibs.AutofacConfig.Container.Resolve<IConsoleWrapper>();

            try
            {
                var hubClient = Applibs.AutofacConfig.Container.Resolve<IHubClient>();
                hubClient.StartAsync();

                while (!SpinWait.SpinUntil(() => false, 1000) && hubClient.State != ConnectionState.Connected)
                {
                    console.Clear();
                    console.WriteLine($"HubClient State:{hubClient.State}...");
                }


                console.WriteLine("Connect Success");
                console.Read();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
