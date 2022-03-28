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

                if (LoginUserData.Account.f_account == action?.Account)
                {
                    //如果在房間內 先送離開通知在斷線
                    if (LoginUserData.Room != null)
                    {
                        this.hubClient.SendAction(new LeaveRoomMsgAction()
                        {
                            RoomID = LoginUserData.Room.f_id,
                            NickName = LoginUserData.Account.f_nickName
                        });
                    }

                    LoginUserData.DisConnect();
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
