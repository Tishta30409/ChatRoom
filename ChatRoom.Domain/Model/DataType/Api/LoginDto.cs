using ChatRoom.Domain.Repository;
using Newtonsoft.Json;

namespace ChatRoom.Domain.Model.DataObj
{
    public class LoginDto
    {
        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 限制長度 20 不能含中文
        /// </summary>
        public string Password { get; set; }


        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
