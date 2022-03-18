namespace ChatRoom.Domain.Model
{
    public class Account
    {
        public int f_id { get; set; }

        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_account { get; set; }

        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_password { get; set; }

        /// <summary>
        /// 限制長度 10 可含中 英 數
        /// </summary>
        public string f_nickName { get; set; }

        public bool f_isMuted { get; set; }

        public bool f_isLocked { get; set; }

        public byte f_errorTimes { get; set; }

    }
}
