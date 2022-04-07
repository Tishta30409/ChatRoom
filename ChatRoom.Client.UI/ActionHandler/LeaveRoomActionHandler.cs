using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class LeaveRoomActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;
        private LobbyForm lobbyForm;
        private LocalData localData;
        private UserListForm userListForm;

        public LeaveRoomActionHandler(ChatRoomForm chatRoomForm, LobbyForm lobbyFrom, UserListForm userListForm)
        {
            this.chatRoomForm = chatRoomForm;
            this.lobbyForm = lobbyFrom;
            this.userListForm = userListForm;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<LeaveRoomAction>(actionModule.Message);

                if (action.IsRoomClose || action?.RoomID == this.localData.RoomID && action.Account == this.localData.Account.f_account)
                {
                    chatRoomForm.OnLeaveRoom();
                }

                this.lobbyForm.OnRefreshList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
