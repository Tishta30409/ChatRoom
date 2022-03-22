using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;

namespace ChatRoom.Client.Model.Process
{
    public class ChatRoomProcess : IProcess
    {

        IHistoryService historySvc;

        IConsoleWrapper console;

        public ChatRoomProcess(IHistoryService historySvc, IConsoleWrapper console)
        {
            this.historySvc = historySvc;
            this.console = console;
        }

        public ProcessViewType Execute()
        {
            try
            {
                this.console.WriteLine("聊天室介面");
                this.console.Read();
                return ProcessViewType.Lobby;
            }
            catch (Exception)
            {
                return ProcessViewType.Lobby;
            }
        }
    }
}
