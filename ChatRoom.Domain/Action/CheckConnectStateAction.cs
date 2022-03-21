using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    public class CheckConnectStateAction : ActionBase
    {
        public override string Action()
          => "checkConnectStateAction";

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 房間ID
        /// </summary>
        public Guid GUID { get; set; }
    }
}
