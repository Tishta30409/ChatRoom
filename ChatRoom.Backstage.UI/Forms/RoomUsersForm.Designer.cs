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
            this.dvgRoomUserList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgRoomUserList
            // 
            this.dvgRoomUserList.AllowUserToAddRows = false;
            this.dvgRoomUserList.AllowUserToDeleteRows = false;
            this.dvgRoomUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoomUserList.Location = new System.Drawing.Point(12, 12);
            this.dvgRoomUserList.Name = "dvgRoomUserList";
            this.dvgRoomUserList.RowTemplate.Height = 24;
            this.dvgRoomUserList.Size = new System.Drawing.Size(302, 381);
            this.dvgRoomUserList.TabIndex = 0;
            // 
            // RoomUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 405);
            this.Controls.Add(this.dvgRoomUserList);
            this.Name = "RoomUsersForm";
            this.Text = "房間使用者列表(雙擊踢人)";
            this.Shown += new System.EventHandler(this.RoomUser_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUserList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgRoomUserList;
    }
}