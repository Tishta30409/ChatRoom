using ChatRoom.Backstage.Forms.UI;
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

        private MainForm mainForm;

        private LocalData localData;

        public UpdateAccountsActionHandler(UserInfoListForm userInfoListForm, MainForm mainForm, LocalData localData)
        {
            this.userInfoListForm = userInfoListForm;
            this.mainForm = mainForm;

            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateAccountsAction>(actionModule.Message);

                this.userInfoListForm.OnRefreshList();

            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
