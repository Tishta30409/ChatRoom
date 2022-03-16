using Newtonsoft.Json;

namespace ChatRoom.Domain.KeepAliveConn
{
    public abstract class ActionBase
    {
        /// <summary>
        /// 指令字串
        /// </summary>
        public abstract string Action();

        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => JsonConvert.SerializeObject(this);
    }
}
