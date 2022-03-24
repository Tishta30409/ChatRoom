using ChatRoom.Client.Model;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace ChatRoom.Client.ActionHandler
{
    public class CheckConnectStateActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public CheckConnectStateActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<CheckConnectStateAction>(actionModule.Message);

                //帳號相同 但是GUID不同 為前被踢
                if(LoginUserData.GetAccount() == action?.Account && LoginUserData.GetGUID() != action?.GUID)
                {
                    LoginUserData.account =  new Account() { };
                    this.console.WriteLine("帳號重複登入 即將關閉視窗...");
                    this.console.Read();
                    Environment.Exit(0);
                }

                return true;
            }
            catch (Exception ex)
            {
                this.console.Clear();
                this.console.WriteLine(ex.Message);
                this.console.Read();

                return false;
            }
        }
    }
}
