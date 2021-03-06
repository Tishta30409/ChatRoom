using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    //通知離開某房間
    public class LeaveRoomAction : ActionBase
    {
        public override string Action()
           => "leaveRoom";

        /// <summary>
        /// 房間ID
        /// </summary>
        public int RoomID { get; set; }

        public string Account { get; set; }

        public bool IsRoomClose { get; set; }

    }
}
