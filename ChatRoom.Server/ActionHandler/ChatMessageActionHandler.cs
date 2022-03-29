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

        public ChatMessageActionHandler(IHistoryRepository repo, IRoomRepository roomRepo, IHubClient hubClient)
        {
            this.repo = repo;
            this.roomRepo = roomRepo;
            this.hubClient = hubClient;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<ChatMessageAction>(action.Message);

                //檢查房間是否存在
               var roomsResult =  this.roomRepo.QueryList();
               var room =  roomsResult.rooms?.FirstOrDefault(p => p.f_id == content.RoomID)?? null;

                if (room == null)
                {
                    //再廣播一次 讓客端離開房間
                    this.hubClient.BroadCastAction(new LeaveRoomAction()
                    {
                        RoomID = content.RoomID,
                    });

                    return (null, null);
                }
                else
                {
                    if (content.IsRecord)
                    {
                        //塞資料
                        var addResult = this.repo.Add(
                            new History()
                            {
                                f_roomID = content.RoomID,
                                f_nickName = content.NickName,
                                f_content = content.Content,
                                f_createDateTime = DateTime.Now,
                            });
                    }
                   

                    //沒問題就廣播給所有連線
                    var actionResult = new ChatMessageAction()
                    {
                        RoomID = content.RoomID,
                        NickName = content.NickName,
                        Content = content.Content,
                        CreateDateTime = DateTime.Now,
                    };

                    return (null, actionResult);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
