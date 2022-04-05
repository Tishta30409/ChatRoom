using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class UpdateRoomUsersActionHandler : IActionHandler
    {
        private UserListForm userListForm;

        private LocalData localData;

        public UpdateRoomUsersActionHandler(UserListForm userListForm, LocalData localData)
        {
            this.userListForm = userListForm;
            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateRoomUsersAction>(actionModule.Message);

                if (this.localData.RoomID == action?.RoomID)
                {
                    this.userListForm.OnRefreshList();
                }
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
