﻿using Autofac;
using ChatRoom.Backstage.Forms.UI;
using ChatRoom.Backstage.UI.Model;
using ChatRoom.Client.UI.Applibs;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Repository;
using ChatRoom.Domain.Service;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace ChatRoom.Backstage.UI.Forms
{
    public partial class RoomListForm : Form
    {
        private Room[] rooms;

        private Room room;

        private IRoomService svc;

        private IUserRoomService userRoomService;

        private LocalData localData;

        public RoomListForm()
        {
            InitializeComponent();

            this.localData = AutofacConfig.Container.Resolve<LocalData>();

            this.svc = AutofacConfig.Container.Resolve<IRoomService>();
            this.userRoomService = AutofacConfig.Container.Resolve<IUserRoomService>();
            

        }

        private void RoomListForm_Shown(object sender, EventArgs e)
        {
            this.GetRoomList();
        }

        private void GetRoomList()
        {
            var roomsResult = this.svc.GetList();

            if (roomsResult.exception != null)
            {
                throw roomsResult.exception;
            }

            this.rooms = roomsResult.rooms.ToArray();

            var bind = new BindingList<Room>(this.rooms);
            var source = new BindingSource(bind, null);
            this.dvgRoomList.DataSource = source;
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            if (room == null)
            {
                MessageBox.Show("請先選擇房間");
            }

            try
            {
                var btn = (Button)sender;

                switch (btn.Name)
                {
                    case "btnJoinRoom":
                        this.JoinRoom();
                        break;
                    case "btnChangeName":
                        this.ChangeName();
                        break;
                    case "btnRemoveRoom":
                        this.RemoveRoom();
                        break;
                    case "btnAddRoom":
                        this.AddRoom();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void JoinRoom()
        {
            var joinResult = this.userRoomService.JoinRoom(
                new UserRoom()
                {
                    f_account = this.localData.Account,
                    f_nickName = "Admin",
                    f_roomID = this.rooms[this.dvgRoomList.CurrentCell.RowIndex].f_id
                });

            this.localData.RoomID = joinResult.userRoom.f_roomID;
            this.localData.RoomName = this.rooms[this.dvgRoomList.CurrentCell.RowIndex].f_roomName;

            var mainForm = AutofacConfig.Container.Resolve<MainForm>();
            mainForm.ShowJoinRoom();
        }

        private void RemoveRoom()
        {
            var result = this.svc.Delete(this.room.f_id);
            if (result.room != null)
            {
                this.rooms[this.dvgRoomList.CurrentCell.RowIndex] = result.room;
                MessageBox.Show("移除成功");
                this.GetRoomList();
            }
            else
            {
                MessageBox.Show("移除失敗");
            }
        }

        private void AddRoom()
        {
            if(this.textRoomName.Text == "")
            {
                MessageBox.Show("請先輸入房間名稱");
            }

            var result = this.svc.Add(this.textRoomName.Text);
            if (result.resultCode == ResultCode.SUCCESS)
            {
                MessageBox.Show("新增成功");
                this.GetRoomList();
            }
            else
            {
                MessageBox.Show("新增失敗");
            }
        }

        private void ChangeName()
        {
            var result =  this.svc.Update(this.room);
            if (result.room != null)
            {
                this.rooms[this.dvgRoomList.CurrentCell.RowIndex] = result.room;
                MessageBox.Show("更新成功");
                this.GetRoomList();
            }
            else
            {
                MessageBox.Show("更新失敗");
            }
        }


        private void dvgRoomList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.RowIndex < this.rooms.Length && e.RowIndex < this.rooms.Length)
            {
                room = rooms[e.RowIndex];
            }
        }
    }
}