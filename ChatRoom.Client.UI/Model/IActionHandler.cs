using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Client.UI.Model
{
    public interface IActionHandler
    {
        void Execute(ActionModule actionModule);
    }
}
