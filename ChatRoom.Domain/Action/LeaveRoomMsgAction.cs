using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    public class LeaveRoomMsgAction : ActionBase
    {
        //廣播離開房間
        public override string Action()
           => "leaveRoomMsg";

        /// <summary>
        /// 房間ID
        /// </summary>
        public int? RoomID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 發話時間 Server塞資料
        /// </summary>
        public DateTime CreateDateTime { get; set; }
    }
}
