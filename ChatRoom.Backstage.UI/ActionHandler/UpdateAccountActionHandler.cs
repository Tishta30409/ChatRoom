using ChatRoom.Backstage.Forms.UI;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Backstage.UI.ActionHandler
{
    public class UpdateAccountActionHandler : IActionHandler
    {

        private MainForm mainForm;

        private LocalData localData;

        public UpdateAccountActionHandler(MainForm mainForm, LocalData localData)
        {
            this.mainForm = mainForm;

            this.localData = localData;
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateAccountAction>(actionModule.Message);

                if (Convert.ToBoolean(action.Account.f_isMuted))
                {
                    this.mainForm.ClearAccountMsg(action.Account.f_nickName);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
