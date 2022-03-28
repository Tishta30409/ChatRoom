﻿using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class JoinRoomMsgActionHandler : IActionHandler
    {
        private IConsoleWrapper console;

        public JoinRoomMsgActionHandler(IConsoleWrapper console)
        {
            this.console = console;
        }

        public bool Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<ChatMessageAction>(actionModule.Message);

                if(LoginUserData.Room?.f_id == action?.RoomID && LoginUserData.Account.f_nickName != action.NickName)
                {
                    this.console.WriteLine($"{action?.NickName??"沒有使用者"} 加入聊天室!");
                }

                return true;
            }
            catch (Exception ex)
            {
                this.console.Clear();
                this.console.WriteLine(ex.Message);
                this.console.Read();

                return false;
            }
        }
    }
}