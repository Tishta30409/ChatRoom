using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using System;
using System.Linq;

namespace ChatRoom.Backstage.Model
{
    public class HistoryQueryBackStageProcess : IBackStageProcess
    {
        private IHistoryService historySvc;

        private IRoomService roomSvc;

        private IConsoleWrapper console;

        private IKeyboardReader keyboardReader;

        public HistoryQueryBackStageProcess(IHistoryService historySvc, IRoomService roomSvc, IConsoleWrapper console, IKeyboardReader keyboardReader)
        {
            this.historySvc = historySvc;
            this.roomSvc = roomSvc;
            this.console = console;
            this.keyboardReader = keyboardReader;
        }

        public bool Execute()
        {
            try
            {
                this.console.Clear();
                this.console.WriteLine("查詢歷史資料:\n");

                //取得房間列表
                var listData = this.roomSvc.GetList();
                if (listData.rooms == null)
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

                    var listResult = this.historySvc.QueryList(id);

                    if (listResult.historys != null)
                    {
                        this.console.WriteLine($"房間名稱:{ findRoom.f_roomName }");
                        foreach (var history in listResult.historys)
                        {
                            this.console.WriteLine($"{history.f_nickName}({history.f_createDateTime}): {history.f_content}");
                        }

                        this.console.WriteLine("已經沒有資料了..");
                    }
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
