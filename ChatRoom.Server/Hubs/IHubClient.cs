using ChatRoom.Domain.KeepAliveConn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Server.Hubs
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
