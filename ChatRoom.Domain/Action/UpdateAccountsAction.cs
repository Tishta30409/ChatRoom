using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model.DataType;

namespace ChatRoom.Domain.Action
{
    //通知玩家離開某房間
    public class UpdateAccountsAction : ActionBase
    {
        public override string Action()
           => "updateAccounts";
    }
}
