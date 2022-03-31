using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class CheckConnectStateActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        private LocalData localData;

        public CheckConnectStateActionHandler(IConsoleWrapper console)
        {
            this.console = console;

            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<CheckConnectStateAction>(actionModule.Message);

                //帳號相同 但是GUID不同 為前被踢
                if(this.localData.Account.f_account == action?.Account && this.localData.Account.f_loginIdentifier != action?.LoginIdentifier )
                {
                    this.localData.Account =  new Account() { };
                    this.console.WriteLine("帳號重複登入 即將關閉視窗...");
                    this.console.Read();
                    Environment.Exit(0);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
