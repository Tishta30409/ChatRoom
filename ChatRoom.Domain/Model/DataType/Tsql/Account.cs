namespace ChatRoom.Domain.Model
{
    //From Sql
    public class Account
    {
        public int f_id { get; set; }

        public string f_account { get; set; }

        public string f_password { get; set; }
        public string f_nickName { get; set; }

        /// <summary>
        /// Boolean SQL byte 0 1
        /// </summary>
        public byte f_isLocked { get; set; }

        // <summary>
        /// Boolean SQL byte 0 1
        /// </summary>
        public byte f_isMuted { get; set; }

        public byte f_errorTimes { get; set; }

        public string f_loginIdentifier { get; set; }
    }
}
