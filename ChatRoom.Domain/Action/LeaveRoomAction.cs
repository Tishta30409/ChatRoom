using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    //通知玩家離開某房間
    public class LeaveRoomAction : ActionBase
    {
        public override string Action()
           => "LeaveRoom";

        /// <summary>
        /// 房間ID
        /// </summary>
        public int RoomID { get; set; }

    }
}
