using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class LeaveRoomMsgActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public LeaveRoomMsgActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if(LocalUserData.Room?.f_id == action?.RoomID)
                {
                    this.console.WriteLine($"{action.NickName} 離開聊天室..");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
