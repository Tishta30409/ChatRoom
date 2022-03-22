using Autofac;
using Autofac.Features.Indexed;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using System;
using System.Linq;

namespace ChatRoom.Backstage
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = Applibs.AutofacConfig.Container.Resolve<IConsoleWrapper>();

            var legalTypes = new BackStageProcessType[]
           {
                BackStageProcessType.UpdateAccount,
                BackStageProcessType.UnlockAccount,
                BackStageProcessType.MuteAccount,
                BackStageProcessType.DeleteAccount,
                BackStageProcessType.AddRoom,
                BackStageProcessType.UpdateRoom,
                BackStageProcessType.DeleteRoom,
                BackStageProcessType.QueryHistory,
           };

            var legalTypesFormat = legalTypes.Select(t => $"{((int)t)}");
            var legalTypesDisplay = legalTypes.Select(t => t.ToDisplay());

            try
            {
                var processSets = Applibs.AutofacConfig.Container.Resolve<IIndex<BackStageProcessType, IBackStageProcess>>();

                string cmd = string.Empty;

                while (cmd.ToLower() != "exit")
                {
                    console.Clear();

                    console.WriteLine("聊天系統-後台介面");

                    // 處理第一層業務
                    if (legalTypesFormat.Any(p => p == cmd) &&
                        processSets.TryGetValue((BackStageProcessType)Convert.ToInt32(cmd), out IBackStageProcess process) &&
                        !process.Execute())
                    {

                        console.Clear();
                        console.WriteLine("Finished!");
                        console.Read();
                    }

                    console.WriteLine(string.Join("\r\n", legalTypesDisplay));

                    cmd = console.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
