using ChatRoom.Client.Signalr;
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

        IKeyboardReader keyboardReader;

        IHubClient hubClient;

        public ChatRoomProcess(IHistoryService historySvc, IConsoleWrapper console, IKeyboardReader keyboardReader, IHubClient hubClient)
        {
            this.historySvc = historySvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
            this.hubClient = hubClient;
        }

        public ProcessViewType Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("聊天室介面");
                this.console.WriteLine($"房間名稱:: {RoomListData.GetRoomName(LoginUserData.GetRoomID())}");
                this.console.WriteLine("開始聊天..(輸入exit離開)");

                var chatString = string.Empty;
                while (chatString.ToLower() != "exit")
                {
                    chatString = this.keyboardReader.GetInputString("", false, 20);

                }

                this.console.ReadLine();
                return ProcessViewType.Lobby;
            }
            catch (Exception)
            {
                return ProcessViewType.Lobby;
            }
        }
    }
}
