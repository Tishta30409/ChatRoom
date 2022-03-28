using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Client.UI.Model
{
    public interface IActionHandler
    {
        bool Execute(ActionModule actionModule);
    }
}
