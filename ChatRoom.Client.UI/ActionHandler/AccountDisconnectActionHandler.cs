using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class AccountDisconnectActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        private IHubClient hubClient;

        private LocalData localData;

        public AccountDisconnectActionHandler(IConsoleWrapper console, IHubClient hubClient)
        {
            this.console = console;
            this.hubClient = hubClient;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<AccountDisconnectAction>(actionModule.Message);

                if (this.localData.Account.f_account == action?.Account)
                {
                    //如果在房間內 先送離開通知在斷線
                    if (this.localData.RoomID != null)
                    {
                        this.hubClient.SendAction(new ChatMessageAction()
                        {
                            Account = this.localData.Account.f_account,
                            RoomID = (int)this.localData.RoomID,
                            NickName = this.localData.Account.f_nickName,
                            Content = "離開房間..",
                            IsRecord = false,
                        });
                    }

                    this.localData.DisConnect();
                    this.hubClient.Disconnect();
                    this.console.WriteLine($"{action.Account} 玩家斷線 請重新連線");
                    this.console.ReadLine();

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
