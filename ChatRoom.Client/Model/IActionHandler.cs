using ChatRoom.Domain.KeepAliveConn;

namespace ChatRoom.Client.Model
{
    public interface IActionHandler
    {
        bool Execute(ActionModule actionModule);
    }
}
