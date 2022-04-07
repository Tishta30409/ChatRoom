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
    public class ChatMessageActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;

        private LocalData localData;

        public ChatMessageActionHandler(ChatRoomForm chatRoomForm)
        {
            this.chatRoomForm = chatRoomForm;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if (this.localData.RoomID == action.RoomID)
                {
                    this.chatRoomForm.OnReceiveMessage(action);
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
