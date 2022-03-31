using ChatRoom.Client.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
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
                this.console.WriteLine($"房間名稱:: {RoomListData.GetRoomName(LocalUserData.Room.f_id)}");
                this.console.WriteLine($"使用者暱稱::{LocalUserData.Account.f_nickName}");
                this.console.WriteLine("開始聊天..(輸入exit離開)");

                int? roomID = LocalUserData.Room.f_id;

                //歷史訊息
                var queryList = this.historySvc.QueryList(roomID);
                foreach (var history in queryList.historys)
                {
                    this.console.WriteLine($"{history.f_nickName}({history.f_createDateTime}):: {history.f_content}");
                }

                var chatString = string.Empty;
                while (chatString.ToLower() != "exit")
                {
                    if (LocalUserData.Room != null)
                    {
                        this.console.WriteLine("聊天室不存在 返回大廳");
                        break;
                    }
                    else
                    {
                        //只取字串 不顯示在畫面 收到訊息才KEY到畫面
                        chatString = this.keyboardReader.GetInputString("", false, UserConstants.ContentLength);

                        //this.console.WriteLine(chatString);
                        if (LocalUserData.Account.f_isMuted == 0 && chatString.ToLower() != "exit" && LocalUserData.Room != null)
                            this.hubClient.SendAction(new ChatMessageAction()
                            {
                                Account = LocalUserData.Account.f_account,
                                Content = chatString,
                                RoomID = LocalUserData.Room.f_id,
                                NickName = LocalUserData.Account.f_nickName,
                                IsRecord = true
                            });
                    }
                }

                // 離開 

                this.hubClient.SendAction(new ChatMessageAction()
                {
                    Account = LocalUserData.Account.f_account,
                    RoomID = LocalUserData.Room.f_id,
                    NickName = LocalUserData.Account.f_nickName,
                    Content = "離開房間..",
                    IsRecord = false,
                });

                LocalUserData.Room = null;

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
