using ChatRoom.Domain.Action;
using ChatRoom.Domain.Hubs;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Server.ActionHandler
{
    public class HistoryActionHandler : IActionHandler
    {
        private IHistoryRepository repo;

        public HistoryActionHandler(IHistoryRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<HistoryAction>(action.Message);

                //塞資料
                var addResult = this.repo.Add(
                    new History()
                    {
                        f_roomID = content.RoomID,
                        f_nickName = content.NickName,
                        f_content = content.Content,
                        f_createDateTime = DateTime.Now,
                    });

                //沒問題就廣播給所有連線
                var actionResult = new HistoryAction()
                {
                    RoomID = addResult.history.f_roomID,
                    NickName = addResult.history.f_nickName,
                    Content  = addResult.history.f_content,
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
