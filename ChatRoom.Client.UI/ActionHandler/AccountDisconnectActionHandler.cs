using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class AccountDisconnectActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;

        private LobbyForm lobbyForm;

        private IHubClient hubClient;

        private LocalData localData;

        public AccountDisconnectActionHandler(ChatRoomForm chatRoomForm, LobbyForm lobbyForm,  IHubClient hubClient)
        {
            this.chatRoomForm = chatRoomForm;
            this.lobbyForm = lobbyForm;
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

                    this.lobbyForm.OnDisconnect();
                    this.chatRoomForm.OnDisconnect();

                    this.localData.DisConnect();
                    this.hubClient.Disconnect();
                  
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
