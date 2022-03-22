using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.Process;
using ChatRoom.Domain.Service;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace ChatRoom.Client.Model.Process
{
    public class LobbyProcess : IProcess
    {
        IAccountService accountSvc;

        IRoomService roomSvc;

        IConsoleWrapper console;

        public LobbyProcess(IAccountService accountSvc, IRoomService roomSvc, IConsoleWrapper console)
        {
            this.accountSvc = accountSvc;
            this.roomSvc = roomSvc;
            this.console = console;
        }

        public ProcessViewType Execute()
        {
            try
            {
                var queryResult = this.roomSvc.GetList();

                this.console.Clear();
                this.console.WriteLine("大廳介面(房間列表): 請輸入想加入的房間編號");

                if(queryResult.rooms != null)
                {
                    foreach(var room in queryResult.rooms)
                    {
                        this.console.WriteLine($"房間編號:{room.f_id}. 房間名稱:{room.f_roomName}");

                    }
                }

                string selectRoomID = string.Empty;

                int number = 0;

                while (queryResult.rooms.Where((element, index) => element.f_id == number).Count() == 0 || selectRoomID == string.Empty)
                {
                    this.console.WriteLine("請輸入房間編號:\n");
                    selectRoomID = this.console.ReadLine();
                    Int32.TryParse(selectRoomID, out number);
                }

                LoginUserData.account.f_roomID = number;
                var updateResult =  this.accountSvc.Update(LoginUserData.account);
                if(updateResult.account != null)
                {
                    this.console.WriteLine("加入房間成功");
                    this.console.Read();
                    return ProcessViewType.ChatRoom;
                }
                else
                {
                    this.console.WriteLine("加入房間失敗");
                    this.console.Read();
                    return ProcessViewType.Lobby;
                }

               
                
            }
            catch (Exception)
            {
                return ProcessViewType.Main;
            }
        }
    }
}
