using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Domain.Action
{
    /// <summary>
    /// 更新房間列表
    /// </summary>
    public class UpdateRoomsAction : ActionBase
    {
        public override string Action()
            => "updateRooms";
    }
}
