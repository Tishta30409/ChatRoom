using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class UpdateRoomsActionHandler : IActionHandler
    {
        private LobbyForm lobbyForm;

        private LocalData localData;

        public UpdateRoomsActionHandler(LobbyForm lobbyForm, LocalData localData)
        {
            this.lobbyForm = lobbyForm;
            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateRoomsAction>(actionModule.Message);

                this.lobbyForm.OnRefreshList();

            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
