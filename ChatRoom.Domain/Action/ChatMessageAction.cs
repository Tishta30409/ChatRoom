using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Domain.Action
{
    public class ChatMessageAction : ActionBase
    {
        public override string Action()
           => "chatMessage";

        /// <summary>
        /// 房間ID
        /// </summary>
        public int? RoomID { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        ///  聊天內容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 發話時間
        /// </summary>
        public DateTime CreateDateTime { get; set; }


        public bool IsRecord { get; set; }
    }
}
