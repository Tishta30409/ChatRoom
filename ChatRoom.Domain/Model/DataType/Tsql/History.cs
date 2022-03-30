using System;

namespace ChatRoom.Domain.Model
{
    //From Sql
    public class History
    {
        public long f_id { get; set; }

        public int f_roomID { get; set; }

        public string f_nickName { get; set; }

        public string f_content { get; set; }

        public DateTime f_createDateTime { get; set; }
    }
}
