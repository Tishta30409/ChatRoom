using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Domain.Action
{
    //通知重取帳號清單
    public class UpdateRoomUsersAction : ActionBase
    {
        public override string Action()
             => "updateRoomUsers";

        public int RoomID { get; set; }
    }
}
