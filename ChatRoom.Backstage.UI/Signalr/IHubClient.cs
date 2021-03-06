using ChatRoom.Domain.KeepAliveConn;
using Microsoft.AspNet.SignalR.Client;
using System.Threading.Tasks;

namespace ChatRoom.Client.Signalr
{
    public abstract class IHubClient
    {
        /// <summary>s
        /// HubName
        /// </summary>
        public string HubName;

        /// <summary>
        /// 連線字串
        /// </summary>
        public string Url;

        /// <summary>
        /// HubClient連線物件
        /// </summary>
        public HubConnection HubConnection;

        /// <summary>
        /// HubProxy
        /// </summary>
        protected IHubProxy HubProxy;

        /// <summary>
        /// 當前狀態
        /// </summary>
        public ConnectionState State
            => this.HubConnection?.State ?? ConnectionState.Disconnected;

        /// <summary>
        /// 廣播訊息
        /// </summary>
        public abstract void BroadCastAction(string str);

        public abstract Task<ActionModule> GetAction<T>(T act) where T : ActionBase;

        /// <summary>
        /// 發送單筆ActionModule
        /// </summary>
        /// <param name="bytes"></param>
        public abstract void SendAction<T>(T act) where T : ActionBase;

        /// <summary>
        /// HubClient啟動
        /// </summary>
        public abstract Task StartAsync();

        public abstract void Disconnect();
    }
}
