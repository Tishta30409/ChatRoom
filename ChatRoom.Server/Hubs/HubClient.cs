using ChatRoom.Domain.KeepAliveConn;
using Microsoft.AspNet.SignalR;
using NLog;
using System;
using System.Threading;

namespace ChatRoom.Server.Hubs
{
    public class HubClient : IHubClient
    {
        private ILogger logger = LogManager.GetLogger("ChatRoom.Server");

        private IHubContext hubContext => GlobalHost.ConnectionManager.GetHubContext<ChatRoomHub>();

        /// <summary>
        /// 廣撥用
        /// </summary>
        /// <param name="act"></param>
        public void BroadCastAction<A>(A act)
            where A : ActionBase
        {
            var sendAction = new ActionModule()
            {
                Action = act.Action(),
                Message = act.ToString()
            };

            try
            {
                this.logger.Trace($"{this.GetType().Name} BroadCastAction: {sendAction.ToString()}");

                this.hubContext.Clients.All.BroadCastAction(sendAction.ToString());
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} BroadCastAction Exception");
                bool runing = true;
                while (runing)
                {
                    SpinWait.SpinUntil(() => runing = false, 500);
                }

                this.hubContext.Clients.All.BroadCastAction(sendAction.ToString());
            }
        }
    }
}
