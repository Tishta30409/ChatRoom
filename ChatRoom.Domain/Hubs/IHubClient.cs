using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Domain.Hubs
{
    public interface IHubClient
    {
        /// <summary>
        /// 廣播用
        /// </summary>
        void BroadCastAction<A>(A act)
            where A : ActionBase;
    }
}
