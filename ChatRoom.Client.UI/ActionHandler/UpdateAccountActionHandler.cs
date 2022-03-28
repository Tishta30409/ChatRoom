using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class UpdateAccountActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        private IHubClient hubClient;
        public UpdateAccountActionHandler(IConsoleWrapper console, IHubClient hubClient)
        {
            this.console = console;
            this.hubClient = hubClient;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateAccountAction>(actionModule.Message);

                if(LoginUserData.Account.f_account == action?.Account.f_account)
                {
                    LoginUserData.Account = action.Account;
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
