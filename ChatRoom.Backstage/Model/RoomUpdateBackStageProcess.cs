using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ChatRoom.Backstage.Model
{
    public class RoomUpdateBackStageProcess : IBackStageProcess
    {
        private IRoomService roomSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public RoomUpdateBackStageProcess(IRoomService roomSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
        {
            this.roomSvc = roomSvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("更新房間:\n");

                var listData = this.roomSvc.GetList();
                if (listData.rooms?.Count() == 0 || listData.rooms == null)
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

                    string roomName = String.Empty;
                    while (roomName == String.Empty)
                    {
                        this.console.WriteLine("請輸入新房間名:");
                        roomName = keyboardReader.GetInputString("", false, UserConstants.RoomNameLength);
                    }

                    var updateRoom = this.roomSvc.Update(new Room()
                    {
                        f_id = id,
                        f_roomName = roomName,
                    });

                    this.console.WriteLine($"執行結果: {JsonConvert.SerializeObject(updateRoom)}");

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
