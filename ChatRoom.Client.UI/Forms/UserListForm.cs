using Autofac;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Client.UI.Model;
using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Client.UI.Forms
{
    public partial class UserListForm : Form
    {
        private BindingList<UserRoom> userRooms;

        private IUserRoomService svc;

        private LocalData localData;

        private delegate void DelOnAddUser(UserRoom userRoom);

        private delegate void DelOnDeleteUser(UserRoom userRoom);

        private object obj;

        public UserListForm()
        {
            InitializeComponent();

            this.svc = AutofacConfig.Container.Resolve<IUserRoomService>();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();

            this.obj = new object();

        }

        private void UserListForm_Shown(object sender, EventArgs e)
        {
            this.GetList();
        }

        //減少對庫的處理 
        private void GetList()
        {
            var getResult = this.svc.QueryList((int)this.localData.RoomID);

            if (getResult.exception != null)
            {
                throw getResult.exception;
            }

            var listData = getResult.userRooms.ToList();
            this.userRooms = new BindingList<UserRoom>(listData);
            var source = new BindingSource(this.userRooms, null);
            this.dvgRoomUsers.DataSource = source;
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
                if (this.Visible && this.userRooms.FirstOrDefault(x=>x.f_nickName == userRoom.f_nickName) == null)
                {
                    lock (this.obj)
                    {
                        this.userRooms?.Add(userRoom);
                    }
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
                    lock (this.obj)
                    {
                        this.userRooms.Remove(this.userRooms.FirstOrDefault(x=>x.f_nickName == userRoom.f_nickName));
                    }
                    
                    var bind = new BindingList<UserRoom>(this.userRooms);
                    var source = new BindingSource(bind, null);
                    this.dvgRoomUsers.DataSource = source;
                }

            }
        }

    }
}
