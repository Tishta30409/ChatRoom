using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using ChatRoom.Domain.Model;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class UpdateAccountActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;

        private IHubClient hubClient;

        private LocalData localData;


        public UpdateAccountActionHandler(ChatRoomForm chatRoomForm, IHubClient hubClient)
        {
            this.chatRoomForm = chatRoomForm;
            this.hubClient = hubClient;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateAccountAction>(actionModule.Message);

                if(this.localData.Account.f_account == action?.Account.f_account)
                {
                    this.localData.Account = action.Account;

                    this.chatRoomForm.UpdateAccount();

                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
