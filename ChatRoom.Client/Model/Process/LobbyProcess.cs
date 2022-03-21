using ChatRoom.Domain.Model.Process;
using System;

namespace ChatRoom.Client.Model.Process
{
    public class LobbyProcess : IProcess
    {
        public LobbyProcess()
        {
        }

        public bool Execute()
        {
            try
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
