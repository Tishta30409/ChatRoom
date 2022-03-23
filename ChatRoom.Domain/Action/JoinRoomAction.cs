using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    public class JoinRoomAction : ActionBase
    {
        public override string Action()
           => "JoinRoom";

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
