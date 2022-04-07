using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model.DataType;

namespace ChatRoom.Domain.Action
{
    /// <summary>
    /// 更新房間列表
    /// </summary>
    public class UpdateRoomsAction : ActionBase
    {
        public override string Action()
            => "updateRooms";

        public bool IsAdd { get; set; }

        public Room Room { get; set; }
    }
}
