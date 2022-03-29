using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class JoinRoomMsgActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;

        public JoinRoomMsgActionHandler(ChatRoomForm chatRoomForm)
        {
            this.chatRoomForm = chatRoomForm;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if(LocalUserData.Room?.f_id == action?.RoomID && LocalUserData.Account.f_nickName != action.NickName)
                {
                    this.chatRoomForm.OnReceiveMessage(action);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
