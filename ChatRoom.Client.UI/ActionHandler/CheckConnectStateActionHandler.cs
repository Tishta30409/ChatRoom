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

        public CheckConnectStateActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<CheckConnectStateAction>(actionModule.Message);

                //帳號相同 但是GUID不同 為前被踢
                if(LocalUserData.Account.f_account == action?.Account && LocalUserData.Account.f_loginIdentifier != action?.LoginIdentifier )
                {
                    LocalUserData.Account =  new Account() { };
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
