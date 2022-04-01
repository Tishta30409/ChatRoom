using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class CheckConnectStateActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;

        private LobbyForm lobbyForm;

        private IUserRoomService userRoomService;

        private IHubClient hubClient;

        private LocalData localData;

        public CheckConnectStateActionHandler(ChatRoomForm chatRoomForm, LobbyForm lobbyForm, IHubClient hubClient, IUserRoomService userRoomService)
        {
            this.chatRoomForm = chatRoomForm;
            this.lobbyForm = lobbyForm;
            this.hubClient = hubClient;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
            this.userRoomService = userRoomService;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<CheckConnectStateAction>(actionModule.Message);

                //帳號相同 但是GUID不同 為前被踢
                if (this.localData.Account.f_account == action?.Account && this.localData.Account.f_loginIdentifier != action?.LoginIdentifier)
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

                    this.userRoomService.LeaveRoom(this.localData.Account.f_account);

                    switch (this.localData.FormViewType)
                    {
                        case FormViewType.Lobby:
                            this.localData.FormViewType = FormViewType.Main;
                            this.lobbyForm.OnDisconnect();
                            break;
                        case FormViewType.ChatRoom:
                            this.localData.FormViewType = FormViewType.Main;
                            this.chatRoomForm.OnDisconnect();
                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
