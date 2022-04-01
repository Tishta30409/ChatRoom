using ChatRoom.Client.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using Newtonsoft.Json;
using System;

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
                if(LocalUserData.Account.f_account == action?.Account && LocalUserData.Account.f_loginIdentifier != action?.LoginIdentifier )
                {
                    LocalUserData.Account =  new Account() { };
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
