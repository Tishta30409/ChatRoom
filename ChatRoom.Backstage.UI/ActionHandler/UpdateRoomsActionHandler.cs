using ChatRoom.Backstage.UI.Forms;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class UpdateRoomsActionHandler : IActionHandler
    {
        private RoomListForm roomListForm;

        private LocalData localData;

        public UpdateRoomsActionHandler(RoomListForm roomListForm, LocalData localData)
        {
            this.roomListForm = roomListForm;
            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateRoomsAction>(actionModule.Message);

                if (action.IsAdd)
                {
                    this.roomListForm.OnAddRoom(action.Room);
                }
                else
                {
                    this.roomListForm.OnRemoveRoom(action.Room);
                }

            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
