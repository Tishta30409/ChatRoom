using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Hubs;
using ChatRoom.Server.Model;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ChatRoom.Server.ActionHandler
{
    public class ChatMessageActionHandler : IActionHandler
    {
        private IHistoryRepository repo;

        private IRoomRepository roomRepo;

        private IHubClient hubClient;

        private IUserRoomRepository userRoomRepo;

        public ChatMessageActionHandler(IHistoryRepository repo, IRoomRepository roomRepo, IUserRoomRepository userRoomRepo,  IHubClient hubClient)
        {
            this.repo = repo;
            this.roomRepo = roomRepo;
            this.hubClient = hubClient;
            this.userRoomRepo = userRoomRepo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<ChatMessageAction>(action.Message);

                //檢查玩家是否在房間中
                if (content.IsRecord)
                {
                    //塞資料
                    var addResult = this.repo.Add(
                        new History()
                        {
                            f_account = content.Account,
                            f_roomID = content.RoomID,
                            f_nickName = content.NickName,
                            f_content = content.Content,
                            f_createDateTime = DateTime.Now,
                        });
                }

                //沒問題就廣播給所有連線
                var actionResult = new ChatMessageAction()
                {
                    Account = content.Account,
                    RoomID = content.RoomID,
                    NickName = content.NickName,
                    Content = content.Content,
                    CreateDateTime = DateTime.Now,
                };

                return (null, actionResult);

            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
