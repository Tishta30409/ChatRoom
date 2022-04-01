namespace ChatRoom.Backstage.UI.Forms
{
    partial class RoomUsersForm
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
            this.dvgRoomUserList = new System.Windows.Forms.DataGridView();
            this.userRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faccountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.froomIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoomBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgRoomUserList
            // 
            this.dvgRoomUserList.AllowUserToAddRows = false;
            this.dvgRoomUserList.AllowUserToDeleteRows = false;
            this.dvgRoomUserList.AutoGenerateColumns = false;
            this.dvgRoomUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoomUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fidDataGridViewTextBoxColumn,
            this.faccountDataGridViewTextBoxColumn,
            this.froomIDDataGridViewTextBoxColumn,
            this.fnickNameDataGridViewTextBoxColumn});
            this.dvgRoomUserList.DataSource = this.userRoomBindingSource;
            this.dvgRoomUserList.Location = new System.Drawing.Point(12, 12);
            this.dvgRoomUserList.Name = "dvgRoomUserList";
            this.dvgRoomUserList.ReadOnly = true;
            this.dvgRoomUserList.RowTemplate.Height = 24;
            this.dvgRoomUserList.Size = new System.Drawing.Size(182, 290);
            this.dvgRoomUserList.TabIndex = 0;
            this.dvgRoomUserList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgRoomUserList_CellDoubleClick);
            // 
            // userRoomBindingSource
            // 
            this.userRoomBindingSource.DataSource = typeof(ChatRoom.Domain.Model.DataType.UserRoom);
            // 
            // roomBindingSource
            // 
            this.roomBindingSource.DataSource = typeof(ChatRoom.Domain.Model.DataType.Room);
            // 
            // fidDataGridViewTextBoxColumn
            // 
            this.fidDataGridViewTextBoxColumn.DataPropertyName = "f_id";
            this.fidDataGridViewTextBoxColumn.HeaderText = "f_id";
            this.fidDataGridViewTextBoxColumn.Name = "fidDataGridViewTextBoxColumn";
            this.fidDataGridViewTextBoxColumn.ReadOnly = true;
            this.fidDataGridViewTextBoxColumn.Visible = false;
            // 
            // faccountDataGridViewTextBoxColumn
            // 
            this.faccountDataGridViewTextBoxColumn.DataPropertyName = "f_account";
            this.faccountDataGridViewTextBoxColumn.HeaderText = "f_account";
            this.faccountDataGridViewTextBoxColumn.Name = "faccountDataGridViewTextBoxColumn";
            this.faccountDataGridViewTextBoxColumn.ReadOnly = true;
            this.faccountDataGridViewTextBoxColumn.Visible = false;
            // 
            // froomIDDataGridViewTextBoxColumn
            // 
            this.froomIDDataGridViewTextBoxColumn.DataPropertyName = "f_roomID";
            this.froomIDDataGridViewTextBoxColumn.HeaderText = "f_roomID";
            this.froomIDDataGridViewTextBoxColumn.Name = "froomIDDataGridViewTextBoxColumn";
            this.froomIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.froomIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fnickNameDataGridViewTextBoxColumn
            // 
            this.fnickNameDataGridViewTextBoxColumn.DataPropertyName = "f_nickName";
            this.fnickNameDataGridViewTextBoxColumn.HeaderText = "暱稱";
            this.fnickNameDataGridViewTextBoxColumn.Name = "fnickNameDataGridViewTextBoxColumn";
            this.fnickNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // RoomUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 314);
            this.Controls.Add(this.dvgRoomUserList);
            this.Name = "RoomUsersForm";
            this.Text = "房間使用者列表(雙擊踢人)";
            this.Shown += new System.EventHandler(this.RoomUser_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoomBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgRoomUserList;
        private System.Windows.Forms.BindingSource userRoomBindingSource;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faccountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn froomIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnickNameDataGridViewTextBoxColumn;
    }
}