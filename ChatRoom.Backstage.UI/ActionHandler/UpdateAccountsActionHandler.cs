using ChatRoom.Backstage.UI.Forms;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class UpdateAccountsActionHandler : IActionHandler
    {
        private UserInfoListForm userInfoListForm;

        private LocalData localData;

        public UpdateAccountsActionHandler(UserInfoListForm userInfoListForm, LocalData localData)
        {
            this.userInfoListForm = userInfoListForm;
            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateRoomsAction>(actionModule.Message);

                this.userInfoListForm.OnRefreshList();

            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
