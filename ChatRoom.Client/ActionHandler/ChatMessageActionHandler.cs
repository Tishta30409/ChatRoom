using ChatRoom.Client.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.ActionHandler
{
    public class ChatMessageActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public ChatMessageActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);



                if (LoginUserData.Room.f_id == action?.RoomID)
                {
                    this.console.WriteLine($"{action.NickName}({action.CreateDateTime}):: {action.Content}");
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
