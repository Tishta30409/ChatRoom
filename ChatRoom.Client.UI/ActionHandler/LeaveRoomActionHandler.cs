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
        private ChatRoomForm form;
        private LocalData localData;
        public LeaveRoomActionHandler(ChatRoomForm form)
        {
            this.form = form;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<LeaveRoomAction>(actionModule.Message);

                if (action?.RoomID == this.localData.RoomID || action.Account == this.localData.Account.f_account)
                {
                    var chatRoom = AutofacConfig.Container.Resolve<ChatRoomForm>();
                    chatRoom.OnLeaveRoom();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
