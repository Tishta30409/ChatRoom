using ChatRoom.Client.Model;
using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.ActionHandler
{
    public class AccountDisconnectActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        private IHubClient hubClient;
        public AccountDisconnectActionHandler(IConsoleWrapper console, IHubClient hubClient)
        {
            this.console = console;
            this.hubClient = hubClient;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<AccountDisconnectAction>(actionModule.Message);

                if (LocalUserData.Account.f_account == action?.Account)
                {
                    //如果在房間內 先送離開通知在斷線
                    if (LocalUserData.Room != null)
                    {
                        this.hubClient.SendAction(new ChatMessageAction()
                        {
                            Account = LocalUserData.Account.f_account,
                            RoomID = LocalUserData.Room.f_id,
                            NickName = LocalUserData.Account.f_nickName,
                            Content = "離開房間..",
                            IsRecord = false,
                        });
                    }

                    LocalUserData.DisConnect();
                    this.hubClient.Disconnect();
                    this.console.WriteLine($"{action.Account} 玩家斷線 請重新連線");
                    this.console.ReadLine();

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
