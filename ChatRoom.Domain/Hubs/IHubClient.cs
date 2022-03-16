using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Domain.Hubs
{
    public interface IHubClient
    {
        /// <summary>
        /// 廣撥用
        /// </summary>
        void BroadCastAction<A>(A act)
            where A : ActionBase;
    }
}
