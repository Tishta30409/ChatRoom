using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;

namespace ChatRoom.Backstage.Model
{
    public class AddRoomBackStageProcess : IBackStageProcess
    {
        private IRoomService svc;

        private IConsoleWrapper console;

        public AddRoomBackStageProcess(IRoomService sujectSvc, IConsoleWrapper console)
        {
            this.svc = sujectSvc;
            this.console = console;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("新增房間:\n");

                var roomName = string.Empty;
                while(roomName == string.Empty || roomName.Length > 20)
                {
                    this.console.Write("請輸入房間名稱(10個字以內):\n");
                    roomName = Console.ReadLine();
                }

                var result = this.svc.Add(roomName);

                if (result.room != null)
                {
                    console.WriteLine(" 房間新增成功");
                }
                else
                {
                    console.WriteLine(" 房間新增失敗");
                }

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
