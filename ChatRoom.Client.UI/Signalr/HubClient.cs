using Autofac.Features.Indexed;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.KeepAliveConn;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace ChatRoom.Client.UI.Signalr
{
    public class HubClient : IHubClient
    {
        private IIndex<string, IActionHandler> handlerSets;

        public HubClient(string url, string hubName, IIndex<string, IActionHandler> handlerSets)
        {
            Url = url;
            HubName = hubName;
            this.handlerSets = handlerSets;
        }

        public override void BroadCastAction(string str)
        {
            try
            {
                var actionModule = ActionModule.FromString(str);

                if (this.handlerSets.TryGetValue(actionModule.Action.ToLower(), out var handler))
                {
                    //var second = 0;
                    //while (!SpinWait.SpinUntil(() => false, 1000) && second < 10)
                    //{
                    //    second += 1;
                    //}

                    handler.Execute(actionModule);
                }
            }
            catch (Exception)
            {
            }
        }

        public override async Task<ActionModule> GetAction<T>(T act)
        {

            var sendAction = new ActionModule()
            {
                Action = act.Action(),
                Message = act.ToString()
            };

            if (this.State != ConnectionState.Connected)
            {
                return null;
            }

            var str = await this.HubProxy?.Invoke<string>("GetAction", sendAction.ToString()).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    return string.Empty;
                }
                else
                {
                    return task.Result;
                }
            });

            return string.IsNullOrEmpty(str) ? null : ActionModule.FromString(str);
        }

        public override void SendAction<T>(T act)
        {
            var sendAction = new ActionModule()
            {
                Action = act.Action(),
                Message = act.ToString()
            };

            if (this.State != ConnectionState.Connected)
            {
                return;
            }

            this.HubProxy?.Invoke<string>("SendAction", sendAction.ToString());
        }

        public override async Task StartAsync()
        {
            this.HubConnection = new HubConnection(Url);
            this.HubConnection.TransportConnectTimeout = TimeSpan.FromSeconds(30);
            this.HubProxy = HubConnection.CreateHubProxy(HubName);
            this.HubProxy.On<string>("BroadCastAction", str => this.BroadCastAction(str));
            // 連線開啟
            await this.HubConnection.Start().ContinueWith(task =>
            {
            });
        }

        public override void Disconnect()
        {
            this.HubProxy = null;

            this.HubConnection.Dispose();
            this.HubConnection.Stop();
            this.HubConnection = null;
        }
    }
}
