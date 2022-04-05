using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Domain.Action
{
    public class UpdateRoomsAction : ActionBase
    {
        public override string Action()
            => "updateRooms";
    }
}
