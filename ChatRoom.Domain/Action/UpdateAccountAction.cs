using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using System;

namespace ChatRoom.Domain.Action
{
    //通知玩家離開某房間
    public class UpdateAccountAction : ActionBase
    {
        public override string Action()
           => "updateAccount";

        /// <summary>
        /// 房間ID
        /// </summary>
        public Account Account { get; set; }

    }
}
