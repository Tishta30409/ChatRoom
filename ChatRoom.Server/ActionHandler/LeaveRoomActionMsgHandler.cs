using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Server.ActionHandler
{
    public class LeaveRoomMsgActionHandler : IActionHandler
    {
        private IAccountRepository repo;

        public LeaveRoomMsgActionHandler(IAccountRepository repo)
        {
            this.repo = repo;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<LeaveRoomMsgAction>(action.Message);

                //沒問題就廣播給所有連線
                var actionResult = new LeaveRoomMsgAction()
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
