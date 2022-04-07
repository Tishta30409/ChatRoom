using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model.DataType;

namespace ChatRoom.Domain.Action
{
    //通知重取帳號清單
    public class UpdateRoomUsersAction : ActionBase
    {
        public override string Action()
             => "updateRoomUsers";

        public bool IsJoin { get; set; }

        public UserRoom UserRoom { get; set; }

    }
}
