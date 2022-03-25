using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Hubs;
using ChatRoom.Server.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Server.ActionHandler
{
    public class JoinRoomMsgActionHandler : IActionHandler
    {
        private IAccountRepository repo;

        private IHubClient hubClient;

        public JoinRoomMsgActionHandler(IAccountRepository repo, IHubClient hubClient)
        {
            this.repo = repo;
            this.hubClient = hubClient;
        }

        public (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action)
        {
            try
            {
                var content = JsonConvert.DeserializeObject<JoinRoomMsgAction>(action.Message);

                //沒問題就廣播給所有連線
                var actionResult = new JoinRoomMsgAction()
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
