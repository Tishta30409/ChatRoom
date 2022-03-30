using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class LeaveRoomActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public LeaveRoomActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if(LocalUserData.RoomID == action?.RoomID)
                {
                    LocalUserData.LeaveRoom();

                    this.console.WriteLine($"{action.RoomID} 聊天室已斷線");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
