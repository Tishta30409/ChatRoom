using Autofac;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Backstage.UI.Forms
{
    public partial class RoomUsersForm : Form
    {

        private UserRoomLocker userRooms;

        private IUserRoomService svc;

        private LocalData localData;

        private delegate void DelOnAddUser(UserRoom userRoom);

        private delegate void DelOnDeleteUser(UserRoom userRoom);

        private object obj;

        public RoomUsersForm()
        {
            InitializeComponent();

            this.svc = AutofacConfig.Container.Resolve<IUserRoomService>();
            this.localData = AutofacConfig.Container.Resolve<LocalData>();

            this.obj = new object();
        }



        private void RoomUser_Shown(object sender, EventArgs e)
        {
            this.GetList();
        }

        private void GetList()
        {
            if (this.localData.RoomID != null)
            {
                var getResult = this.svc.QueryList((int)this.localData.RoomID);

                if (getResult.exception != null)
                {
                    throw getResult.exception;
                }

                var data = getResult.userRooms.ToList();
                this.userRooms = new UserRoomLocker(data);
                var source = new BindingSource(this.userRooms.GetRoomUsers(), null);
                this.dvgRoomUserList.DataSource = source;
            }
        }

        private void dvgRoomUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < this.userRooms.Count() && this.userRooms.GetElement(e.RowIndex).f_account != "Admin")
            {
                var result = this.svc.LeaveRoom(this.userRooms.GetElement(e.RowIndex).f_account);

                if (result.userRoom != null)
                {
                    this.GetList();
                }
            }
        }

        public void OnAddUser(UserRoom userRoom)
        {
            if (this.InvokeRequired)
            {
                DelOnAddUser del = new DelOnAddUser(OnAddUser);
                this.Invoke(del, userRoom);
            }
            else
            {
                // TODO this.userRooms 封裝起來 LOCK
                if (this.Visible)
                {
                    this.userRooms.TryAdd(userRoom);
                    var source = new BindingSource(this.userRooms.GetRoomUsers(), null);
                    this.dvgRoomUserList.DataSource = source;
                }
            }
        }

        public void OnDeleteUser(UserRoom userRoom)
        {
            if (this.InvokeRequired)
            {
                DelOnDeleteUser del = new DelOnDeleteUser(OnDeleteUser);
                this.Invoke(del, userRoom);
            }
            else
            {
                if (this.Visible)
                {
                    this.userRooms.Remove(userRoom);
                    var source = new BindingSource(this.userRooms.GetRoomUsers(), null);
                    this.dvgRoomUserList.DataSource = source;
                }
            }
        }
    }
}
