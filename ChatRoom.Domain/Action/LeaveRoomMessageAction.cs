using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    public class LeaveRoomMessageAction : ActionBase
    {
        //廣播離開房間
        public override string Action()
           => "LeaveRoomMessage";

        /// <summary>
        /// 房間ID
        /// </summary>
        public int RoomID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 發話時間
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
