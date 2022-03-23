using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Action;
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

                int roomID = LoginUserData.GetRoomID();

                //歷史訊息
                var queryList = this.historySvc.QueryList(roomID);
                foreach (var history in queryList.historys)
                {
                    this.console.WriteLine($"{history.f_nickName}({history.f_createDateTime}):: {history.f_content}");
                }

                var chatString = string.Empty;
                while (chatString.ToLower() != "exit")
                {
                    //只取字串 不顯示在畫面 收到訊息才KEY到畫面
                    chatString = this.keyboardReader.GetInputString("", false, 20);

                    //this.console.WriteLine(chatString);
                    if(LoginUserData.GetIsMuted() == false && chatString.ToLower() != "exit")
                    this.hubClient.SendAction(new ChatMessageAction() { 
                        Content = chatString,
                        RoomID = LoginUserData.GetRoomID(),
                        NickName = LoginUserData.GetNickName(),
                    });
                }

                // 離開 
                this.hubClient.SendAction(new LeaveRoomAction()
                {
                    RoomID = LoginUserData.GetRoomID(),
                    NickName = LoginUserData.GetNickName(),
                });

                LoginUserData.LeaveRoom();

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
