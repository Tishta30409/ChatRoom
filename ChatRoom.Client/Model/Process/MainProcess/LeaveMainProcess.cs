using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;
using System.Text.RegularExpressions;

namespace ChatRoom.Client.Model.Process
{
    public class LeaveMainProcess : IMainProcess
    {
        public LeaveMainProcess()
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
