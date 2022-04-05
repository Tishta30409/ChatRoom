using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Client.UI.Forms
{
    public partial class UserListForm : Form
    {
        private UserRoom[] userRooms;

        private IUserRoomService svc;

        private LocalData localData;

        private delegate void DelOnRefreshList();

        public UserListForm()
        {
            InitializeComponent();

            this.svc = AutofacConfig.Container.Resolve<IUserRoomService>();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();
        }

        private void UserListForm_Shown(object sender, EventArgs e)
        {
            this.GetList();
        }

        private void GetList()
        {
            var getResult = this.svc.QueryList((int)this.localData.RoomID);

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

        public void OnRefreshList()
        {
            if (this.InvokeRequired)
            {
                DelOnRefreshList del = new DelOnRefreshList(OnRefreshList);
                this.Invoke(del);
            }
            else
            {
                this.GetList();
            }
        }
    }
}
