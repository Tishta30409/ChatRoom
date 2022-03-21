using ChatRoom.Domain.Model.Process;
using System;

namespace ChatRoom.Client.Model.Process
{
    public class ChatRoomProcess : IProcess
    {
        public ChatRoomProcess()
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
