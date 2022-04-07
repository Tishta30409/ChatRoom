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
        private LocalData localData;

        public LeaveRoomActionHandler(ChatRoomForm chatRoomForm)
        {
            this.chatRoomForm = chatRoomForm;
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

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
