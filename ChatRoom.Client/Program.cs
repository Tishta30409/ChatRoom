using Autofac;
using Autofac.Features.Indexed;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Linq;
using System.Threading;

namespace ChatRoom.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = Applibs.AutofacConfig.Container.Resolve<IConsoleWrapper>();

            var legalTypes = new MainProcessType[]
            {
                MainProcessType.Login,
                MainProcessType.Register,
                MainProcessType.Leave
            };

            var legalTypesFormat = legalTypes.Select(t => $"{((int)t)}");
            var legalTypesDisplay = legalTypes.Select(t => t.ToDisplay());

            try
            {
                //連線
                var hubClient = Applibs.AutofacConfig.Container.Resolve<IHubClient>();
                hubClient.StartAsync();

                while (!SpinWait.SpinUntil(() => false, 1000) && hubClient.State != ConnectionState.Connected)
                {
                    console.Clear();
                    console.WriteLine($"HubClient State:{hubClient.State}...");
                }


                console.WriteLine("Connect Success");
                console.Read();

                var processSets = Applibs.AutofacConfig.Container.Resolve<IIndex<MainProcessType, IMainProcess>>();

                string cmd = string.Empty;

                while (cmd.ToLower() != "exit")
                {
                    console.Clear();

                    console.WriteLine("歡迎使用聊天系統!");

                    console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    cmd = console.ReadLine();

                    //處理第一層業
                    if (legalTypesFormat.Any(p => p == cmd) &&
                            processSets.TryGetValue((MainProcessType)Convert.ToInt32(cmd), out IMainProcess process) &&
                            !process.Execute())
                    {

                        console.Clear();
                        console.WriteLine("Finished!");
                        console.Read();
                    }
                }
            }
            catch (Exception ex)
            {
                console.Clear();
                console.WriteLine(ex.Message);
                console.Read();
            }

            console.Clear();
            console.WriteLine("Finished!");
            console.Read();
        }
    }

}

