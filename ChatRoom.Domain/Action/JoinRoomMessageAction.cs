using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    public class JoinRoomMessageAction : ActionBase
    {
        //廣播加入房間
        public override string Action()
           => "JoinRoomMessage";

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
