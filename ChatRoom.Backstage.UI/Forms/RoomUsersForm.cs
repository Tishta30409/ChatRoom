using Autofac;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Backstage.UI.Forms
{
    public partial class RoomUsersForm : Form
    {

        private UserRoom[] userRooms;

        private IUserRoomService svc;

        private LocalData localData;

        public RoomUsersForm()
        {
            InitializeComponent();

            this.svc = AutofacConfig.Container.Resolve<IUserRoomService>();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        private void RoomUser_Shown(object sender, EventArgs e)
        {
            var getResult = this.svc.QueryList((int)this.localData.RoomID);

            if (getResult.exception != null)
            {
                throw getResult.exception;
            }

            this.userRooms = getResult.userRooms.ToArray();

            var bind = new BindingList<UserRoom>(this.userRooms);
            var source = new BindingSource(bind, null);
            this.dvgRoomUserList.DataSource = source;
        }
    }
}
