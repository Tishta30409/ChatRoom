﻿using Autofac;
using Autofac.Features.Indexed;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Server.Applibs;
using ChatRoom.Server.Model;
using Microsoft.AspNet.SignalR;
using NLog;
using System;
using System.Threading.Tasks;

namespace ChatRoom.Server.Hubs
{
    public class ChatRoomHub :Hub
    {
        /// <summary>
        /// logger
        /// </summary>
        private static ILogger logger = LogManager.GetLogger("ChatRoom.Server");

        /// <summary>
        /// 連線時觸發
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            logger.Info($"{this.Context.ConnectionId} Connected");
            return base.OnConnected();
        }

        /// <summary>
        /// 段線時觸發
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            logger.Info($"{this.Context.ConnectionId} Disconnected");
            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// 斷線重連時觸發
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            logger.Info($"{this.Context.ConnectionId} Reconnected");
            return base.OnReconnected();
        }

        /// <summary>
        /// 接收請求(同步)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GetAction(string str)
        {
            try
            {
                var action = ActionModule.FromString(str);
                var actionResult = this.ExecuteAction(action);

                return actionResult.action.ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"{this.GetType().Name} SendAction Exception");
            }

            return string.Empty;
        }

        /// <summary>
        /// 接收請求
        /// </summary>
        /// <param name="str"></param>
        public void SendAction(string str)
        {
            try
            {
                logger.Info($"{this.GetType().Name} SendAction Receipt:{str}");

                var action = ActionModule.FromString(str);
                var actionResult = this.ExecuteAction(action);

                if (actionResult.action != null)
                {
                    this.Clients.All.BroadCastAction(actionResult.action.ToString());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"{this.GetType().Name} SendAction Exception");
            }
        }

        private (Exception exception, ActionModule action) ExecuteAction(ActionModule action)
        {
            try
            {
                using (var scope = AutofacConfig.Container.BeginLifetimeScope())
                {
                    var handlerSets = scope.Resolve<IIndex<string, IActionHandler>>();

                    if (handlerSets.TryGetValue(action.Action.ToLower(), out var actionHandler))
                    {
                        var excuteResult = actionHandler.ExecuteAction(action);

                        var actionResult = new ActionModule()
                        {
                            Action = excuteResult.actionBase.Action(),
                            Message = excuteResult.actionBase.ToString()
                        };

                        return (null, actionResult);
                    }

                    return (null, null);
                }
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

    }
}
