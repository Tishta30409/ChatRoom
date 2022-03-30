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
        public AccountDisconnectActionHandler(IConsoleWrapper console, IHubClient hubClient)
        {
            this.console = console;
            this.hubClient = hubClient;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<AccountDisconnectAction>(actionModule.Message);

                if (LocalUserData.Account.f_account == action?.Account)
                {
                    //如果在房間內 先送離開通知在斷線
                    if (LocalUserData.RoomID != null)
                    {
                        this.hubClient.SendAction(new LeaveRoomMsgAction()
                        {
                            RoomID = LocalUserData.RoomID,
                            NickName = LocalUserData.Account.f_nickName
                        });
                    }

                    LocalUserData.DisConnect();
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
