using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;

namespace ChatRoom.Backstage.Model
{
    public class UpdateRoomBackStageProcess : IBackStageProcess
    {
        private IAccountService svc;

        private IConsoleWrapper console;

        public UpdateRoomBackStageProcess(IAccountService sujectSvc, IConsoleWrapper console)
        {
            this.svc = sujectSvc;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("更新房間:\n");
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
