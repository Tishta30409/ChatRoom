using ChatRoom.Client.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.ActionHandler
{
    public class JoinRoomMsgActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public JoinRoomMsgActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if(LoginUserData.GetRoomID() == action?.RoomID && LoginUserData.GetNickName() != action.NickName)
                {
                    this.console.WriteLine($"{action?.NickName??"沒有使用者"} 加入聊天室!");
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
