namespace ChatRoom.Client.UI.Forms
{
    partial class UserListForm
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
            this.dvgRoomUsers = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgRoomUsers
            // 
            this.dvgRoomUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoomUsers.Location = new System.Drawing.Point(12, 12);
            this.dvgRoomUsers.Name = "dvgRoomUsers";
            this.dvgRoomUsers.RowTemplate.Height = 24;
            this.dvgRoomUsers.Size = new System.Drawing.Size(316, 292);
            this.dvgRoomUsers.TabIndex = 0;
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 330);
            this.Controls.Add(this.dvgRoomUsers);
            this.Name = "UserListForm";
            this.Text = "房間使用者清單";
            this.Shown += new System.EventHandler(this.UserListForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgRoomUsers;
    }
}