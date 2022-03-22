using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;

namespace ChatRoom.Backstage.Model
{
    public class DeleteRoomBackStageProcess : IBackStageProcess
    {
        private IAccountService svc;

        private IConsoleWrapper console;

        public DeleteRoomBackStageProcess(IAccountService sujectSvc, IConsoleWrapper console)
        {
            this.svc = sujectSvc;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("刪除房間:\n");
                this.console.Read();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
