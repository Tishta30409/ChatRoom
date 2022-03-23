using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Server.ActionHandler
{
    public class LeaveRoomActionHandler : IActionHandler
    {
        private IAccountRepository repo;

        public LeaveRoomActionHandler(IAccountRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<LeaveRoomAction>(action.Message);

                //沒問題就廣播給所有連線
                var actionResult = new LeaveRoomAction()
                {
                    RoomID = content.RoomID,
                    NickName = content.NickName,
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
