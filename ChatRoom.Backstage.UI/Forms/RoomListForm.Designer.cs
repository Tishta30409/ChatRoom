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
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnRemoveRoom = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            this.dvgRoomList = new System.Windows.Forms.DataGridView();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.textRoomName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomList)).BeginInit();
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
            // 
            // btnRemoveRoom
            // 
            this.btnRemoveRoom.Location = new System.Drawing.Point(199, 70);
            this.btnRemoveRoom.Name = "btnRemoveRoom";
            this.btnRemoveRoom.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRoom.TabIndex = 1;
            this.btnRemoveRoom.Text = "移除房間";
            this.btnRemoveRoom.UseVisualStyleBackColor = true;
            // 
            // btnChangeName
            // 
            this.btnChangeName.Location = new System.Drawing.Point(199, 41);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(75, 23);
            this.btnChangeName.TabIndex = 2;
            this.btnChangeName.Text = "房間改名";
            this.btnChangeName.UseVisualStyleBackColor = true;
            // 
            // dvgRoomList
            // 
            this.dvgRoomList.AllowUserToAddRows = false;
            this.dvgRoomList.AllowUserToDeleteRows = false;
            this.dvgRoomList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoomList.Location = new System.Drawing.Point(12, 41);
            this.dvgRoomList.Name = "dvgRoomList";
            this.dvgRoomList.RowTemplate.Height = 24;
            this.dvgRoomList.Size = new System.Drawing.Size(181, 299);
            this.dvgRoomList.TabIndex = 3;
            this.dvgRoomList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgRoomList_CellContentClick);
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(199, 12);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(75, 23);
            this.btnJoinRoom.TabIndex = 5;
            this.btnJoinRoom.Text = "加入房間";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            // 
            // textRoomName
            // 
            this.textRoomName.Location = new System.Drawing.Point(12, 12);
            this.textRoomName.Name = "textRoomName";
            this.textRoomName.Size = new System.Drawing.Size(100, 22);
            this.textRoomName.TabIndex = 6;
            // 
            // RoomListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 348);
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
    }
}