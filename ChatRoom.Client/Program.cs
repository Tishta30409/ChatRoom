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

                var mainProcessSets = Applibs.AutofacConfig.Container.Resolve<IIndex<MainProcessType, IMainProcess>>();

                var processSets = Applibs.AutofacConfig.Container.Resolve<IIndex<ProcessType, IProcess>>();

                string cmd = string.Empty;

                while (cmd.ToLower() != "exit")
                {
                    console.Clear();

                    console.WriteLine("歡迎使用聊天系統!");

                    console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    console.WriteLine("或是輸入exit離開");

                    cmd = console.ReadLine();

                    if (legalTypesFormat.Any(p => p == cmd) && mainProcessSets.TryGetValue((MainProcessType)Convert.ToInt32(cmd), out IMainProcess mainProcess) )
                    {
                        ProcessViewType view = mainProcess.Execute();

                        while (view != ProcessViewType.Main)
                        {
                            switch (view)
                            {
                                case ProcessViewType.Lobby:
                                    {
                                        processSets.TryGetValue(ProcessType.Lobby, out IProcess lobbyProcess);
                                        view = lobbyProcess.Execute();
                                    }
                                    break;
                                case ProcessViewType.ChatRoom:
                                    processSets.TryGetValue(ProcessType.ChatRoom, out IProcess chatRoomProcess);
                                    view = chatRoomProcess.Execute();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                //離開聊天室 記得要斷線
                console.Read();
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

