using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Forms;
using ChatRoom.Client.UI.Model;
using ChatRoom.Client.UI.Signalr;
using ChatRoom.Domain.Action;
using ChatRoom.Domain.KeepAliveConn;
using Newtonsoft.Json;
using System;

namespace ChatRoom.Client.UI.ActionHandler
{
    public class UpdateAccountActionHandler : IActionHandler
    {
        private ChatRoomForm chatRoomForm;
        private LocalData localData;


        public UpdateAccountActionHandler(ChatRoomForm chatRoomForm)
        {
            this.chatRoomForm = chatRoomForm;
            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        public void Execute(ActionModule actionModule)
        {
            try
            {
                var action = JsonConvert.DeserializeObject<UpdateAccountAction>(actionModule.Message);

                // 更新狀態
                if(this.localData.Account.f_account == action?.Account.f_account)
                {
                    this.localData.Account = action.Account;
                    this.chatRoomForm.UpdateAccount();
                }

                //畫面禁言處理
                if (Convert.ToBoolean(action.Account.f_isMuted))
                {
                    this.chatRoomForm.ClearAccountMsg(action.Account.f_nickName);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
