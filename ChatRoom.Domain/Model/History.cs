using System;

namespace ChatRoom.Domain.Model
{
    public class History
    {
        public Int64 f_id { get; set; }

        public int f_roomID { get; set; }

        public string f_nickName { get; set; }

        public string f_content { get; set; }

        public DateTime f_createDateTime { get; set; }
    }
}
