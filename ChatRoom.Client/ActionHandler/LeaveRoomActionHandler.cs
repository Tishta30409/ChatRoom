using ChatRoom.Client.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.ActionHandler
{
    public class LeaveRoomActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public LeaveRoomActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if(LocalUserData.Room.f_id == action?.RoomID)
                {
                    LocalUserData.LeaveRoom();

                    this.console.WriteLine($"{action.RoomID} 聊天室已斷線");
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
