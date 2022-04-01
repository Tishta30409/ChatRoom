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
            this.components = new System.ComponentModel.Container();
            this.dvgRoomUsers = new System.Windows.Forms.DataGridView();
            this.userRoomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faccountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.froomIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgRoomUsers
            // 
            this.dvgRoomUsers.AutoGenerateColumns = false;
            this.dvgRoomUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgRoomUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fidDataGridViewTextBoxColumn,
            this.faccountDataGridViewTextBoxColumn,
            this.froomIDDataGridViewTextBoxColumn,
            this.fnickNameDataGridViewTextBoxColumn});
            this.dvgRoomUsers.DataSource = this.userRoomBindingSource;
            this.dvgRoomUsers.Location = new System.Drawing.Point(12, 12);
            this.dvgRoomUsers.Name = "dvgRoomUsers";
            this.dvgRoomUsers.RowTemplate.Height = 24;
            this.dvgRoomUsers.Size = new System.Drawing.Size(169, 285);
            this.dvgRoomUsers.TabIndex = 0;
            // 
            // userRoomBindingSource
            // 
            this.userRoomBindingSource.DataSource = typeof(ChatRoom.Domain.Model.DataType.UserRoom);
            // 
            // fidDataGridViewTextBoxColumn
            // 
            this.fidDataGridViewTextBoxColumn.DataPropertyName = "f_id";
            this.fidDataGridViewTextBoxColumn.HeaderText = "f_id";
            this.fidDataGridViewTextBoxColumn.Name = "fidDataGridViewTextBoxColumn";
            this.fidDataGridViewTextBoxColumn.Visible = false;
            // 
            // faccountDataGridViewTextBoxColumn
            // 
            this.faccountDataGridViewTextBoxColumn.DataPropertyName = "f_account";
            this.faccountDataGridViewTextBoxColumn.HeaderText = "f_account";
            this.faccountDataGridViewTextBoxColumn.Name = "faccountDataGridViewTextBoxColumn";
            this.faccountDataGridViewTextBoxColumn.Visible = false;
            // 
            // froomIDDataGridViewTextBoxColumn
            // 
            this.froomIDDataGridViewTextBoxColumn.DataPropertyName = "f_roomID";
            this.froomIDDataGridViewTextBoxColumn.HeaderText = "f_roomID";
            this.froomIDDataGridViewTextBoxColumn.Name = "froomIDDataGridViewTextBoxColumn";
            this.froomIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fnickNameDataGridViewTextBoxColumn
            // 
            this.fnickNameDataGridViewTextBoxColumn.DataPropertyName = "f_nickName";
            this.fnickNameDataGridViewTextBoxColumn.HeaderText = "f_nickName";
            this.fnickNameDataGridViewTextBoxColumn.Name = "fnickNameDataGridViewTextBoxColumn";
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 314);
            this.Controls.Add(this.dvgRoomUsers);
            this.Name = "UserListForm";
            this.Text = "房間使用者清單";
            this.Shown += new System.EventHandler(this.UserListForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgRoomUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userRoomBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgRoomUsers;
        private System.Windows.Forms.DataGridViewTextBoxColumn fidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faccountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn froomIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userRoomBindingSource;
    }
}