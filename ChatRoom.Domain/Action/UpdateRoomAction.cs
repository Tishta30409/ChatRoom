using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Domain.Action
{
    public class UpdateRoomAction: ActionBase
    {
        public override string Action()
            => "updateRoom";
    }
}
