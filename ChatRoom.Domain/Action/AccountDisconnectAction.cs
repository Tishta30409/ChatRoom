using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    //通知玩家斷線
    public class AccountDisconnectAction : ActionBase
    {
        public override string Action()
           => "accountDisconnect";

        /// <summary>
        /// 房間ID
        /// </summary>
        public string Account { get; set; }
    }
}
