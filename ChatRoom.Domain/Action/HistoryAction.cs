using ChatRoom.Domain.KeepAliveConn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Action
{
    public class HistoryAction: ActionBase
    {
        public override string Action()
           => "historyAction";

        /// <summary>
        /// 房間ID
        /// </summary>
        public int RoomID { get; set; }

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
    }
}
