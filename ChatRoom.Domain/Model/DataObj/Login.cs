namespace ChatRoom.Domain.Model.DataObj
{
    public class Login
    {
        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_account { get; set; }


        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string f_password { get; set; }
    }
}
