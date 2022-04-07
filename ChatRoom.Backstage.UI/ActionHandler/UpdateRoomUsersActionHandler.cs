using Autofac;
using ChatRoom.Backstage.Forms.UI;
using ChatRoom.Backstage.UI.Forms;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class UpdateRoomUsersActionHandler : IActionHandler
    {
        private RoomUsersForm roomUsersForm;

        private LocalData localData;

        public UpdateRoomUsersActionHandler(RoomUsersForm roomUsersForm, LocalData localData)
        {
            this.roomUsersForm = roomUsersForm;
            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateRoomUsersAction>(actionModule.Message);

                if (this.localData.RoomID == action?.UserRoom.f_roomID)
                {
                    if (action.IsJoin)
                    {
                        this.roomUsersForm.OnAddUser(action.UserRoom);
                    }
                    else
                    {
                        this.roomUsersForm.OnDeleteUser(action.UserRoom);
                    }
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
