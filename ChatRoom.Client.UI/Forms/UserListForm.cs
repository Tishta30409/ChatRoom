using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom.Client.UI.Forms
{
    public partial class UserListForm : Form
    {
        private UserRoom[] userRooms;

        private IUserRoomService svc;

        public UserListForm()
        {
            InitializeComponent();

            this.svc = AutofacConfig.Container.Resolve<IUserRoomService>();
        }

        private void UserListForm_Shown(object sender, EventArgs e)
        {
            var getResult = this.svc.QueryList(LocalUserData.Room.f_id);

            if (getResult.exception != null)
            {
                throw getResult.exception;
            }

            //List<string> showData = new List<string>();

            //foreach (UserRoom userRoom in getResult.userRooms.ToArray())
            //{
            //    showData.Add(userRoom.f_nickName);
            //}

            this.userRooms = getResult.userRooms.ToArray();

            var bind = new BindingList<UserRoom>(this.userRooms);
            var source = new BindingSource(bind, null);
            this.dvgRoomUsers.DataSource = source;
        }
    }
}
