using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ChatRoom.Backstage.Model
{
    public class RoomDeleteBackStageProcess : IBackStageProcess
    {
        private IRoomService roomSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public RoomDeleteBackStageProcess(IRoomService roomSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
        {
            this.roomSvc = roomSvc;
            this.keyboardReader = keyboardReader;
            this.console = console;
            
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("刪除房間:\n");

                var listData = this.roomSvc.GetList();
                if(listData.rooms == null || listData.rooms?.Count() ==0)
                {
                    this.console.WriteLine("目前沒有房間存在");
                }
                else
                {
                    foreach (var room in listData.rooms)
                    {
                        this.console.WriteLine($"id:{room.f_id}, name:{room.f_roomName}");
                    }

                    string roomID = String.Empty;
                    int id = 0;
                    Room findRoom = null;

                    while (roomID == String.Empty || findRoom == null)
                    {
                        this.console.WriteLine("請輸入房間ID:");
                        roomID = keyboardReader.GetInputString("^[0-9]*$", false, UserConstants.DefaultLength);

                        int.TryParse(roomID, out id);
                        findRoom = listData.rooms.FirstOrDefault(room => room.f_id == id);
                    }

                    var deleteResult = this.roomSvc.Delete(id);

                    this.console.WriteLine($"執行結果: {JsonConvert.SerializeObject(deleteResult)}");

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
