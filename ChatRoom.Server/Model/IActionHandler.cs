using ChatRoom.Domain.KeepAliveConn;
using System;

namespace ChatRoom.Server.Model
{
    public interface IActionHandler
    {
        (Exception exception, ActionBase actionBase) ExecuteAction(ActionModule action);
    }
}
