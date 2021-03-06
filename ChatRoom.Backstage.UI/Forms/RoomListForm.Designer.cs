namespace ChatRoom.Backstage.UI.Forms
{
    partial class RoomListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.dvgRoomList = new System.Windows.Forms.DataGridView();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.textRoomName = new System.Windows.Forms.TextBox();
            this.fidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.froomNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(118, 12);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 23);
            this.btnAddRoom.TabIndex = 0;
            this.btnAddRoom.Text = "新增房間";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Location = new System.Drawing.Point(199, 99);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRoom.TabIndex = 1;
            this.btnRemoveRoom.Text = "移除房間";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            this.btnRemoveRoom.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(199, 70);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(75, 23);
            this.btnChangeName.TabIndex = 2;
            this.btnChangeName.Text = "房間改名";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // dvgRoomList
            // 
            this.dvgRoomList.AllowUserToAddRows = false;
            this.dvgRoomList.AllowUserToDeleteRows = false;
            this.dvgRoomList.AllowUserToResizeColumns = false;
            this.dvgRoomList.AllowUserToResizeRows = false;
            this.dvgRoomList.AutoGenerateColumns = false;
            this.dvgRoomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoomList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fidDataGridViewTextBoxColumn,
            this.froomNameDataGridViewTextBoxColumn});
            this.dvgRoomList.DataSource = this.roomBindingSource;
            this.dvgRoomList.Location = new System.Drawing.Point(12, 41);
            this.dvgRoomList.Name = "dvgRoomList";
            this.dvgRoomList.ReadOnly = true;
            this.dvgRoomList.RowTemplate.Height = 24;
            this.dvgRoomList.Size = new System.Drawing.Size(181, 299);
            this.dvgRoomList.TabIndex = 3;
            this.dvgRoomList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgRoomList_CellClick);
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(199, 41);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(75, 23);
            this.btnJoinRoom.TabIndex = 5;
            this.btnJoinRoom.Text = "加入房間";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            this.btnJoinRoom.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // textRoomName
            // 
            this.textRoomName.Location = new System.Drawing.Point(12, 12);
            this.textRoomName.Name = "textRoomName";
            this.textRoomName.Size = new System.Drawing.Size(100, 22);
            this.textRoomName.TabIndex = 6;
            // 
            // fidDataGridViewTextBoxColumn
            // 
            this.fidDataGridViewTextBoxColumn.DataPropertyName = "f_id";
            this.fidDataGridViewTextBoxColumn.HeaderText = "f_id";
            this.fidDataGridViewTextBoxColumn.Name = "fidDataGridViewTextBoxColumn";
            this.fidDataGridViewTextBoxColumn.ReadOnly = true;
            this.fidDataGridViewTextBoxColumn.Visible = false;
            // 
            // froomNameDataGridViewTextBoxColumn
            // 
            this.froomNameDataGridViewTextBoxColumn.DataPropertyName = "f_roomName";
            this.froomNameDataGridViewTextBoxColumn.HeaderText = "房間名稱";
            this.froomNameDataGridViewTextBoxColumn.Name = "froomNameDataGridViewTextBoxColumn";
            this.froomNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataSource = typeof(ChatRoom.Domain.Model.DataType.Room);
            // 
            // RoomListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 348);
            this.Controls.Add(this.textRoomName);
            this.Controls.Add(this.btnJoinRoom);
            this.Controls.Add(this.dvgRoomList);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.btnRemoveRoom);
            this.Controls.Add(this.btnAddRoom);
            this.Name = "RoomListForm";
            this.Text = "房間列表";
            this.Shown += new System.EventHandler(this.RoomListForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnRemoveRoom;
        private System.Windows.Forms.Button btnChangeName;
        private System.Windows.Forms.DataGridView dvgRoomList;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.TextBox textRoomName;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn froomNameDataGridViewTextBoxColumn;
    }
}