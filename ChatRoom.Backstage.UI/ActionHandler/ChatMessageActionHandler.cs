using Autofac;
using ChatRoom.Backstage.Forms.UI;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class ChatMessageActionHandler : IActionHandler
    {
        private MainForm mainForm;

        private LocalData localData;

        public ChatMessageActionHandler(MainForm chatRoomForm)
        {
            this.mainForm = chatRoomForm;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if (this.localData.RoomID == action?.RoomID)
                {
                    this.mainForm.OnReceiveMessage(action);
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
