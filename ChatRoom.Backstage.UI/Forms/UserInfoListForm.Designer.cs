namespace ChatRoom.Backstage.UI.Forms
{
    partial class UserInfoListForm
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
            this.dvgUserList = new System.Windows.Forms.DataGridView();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnUnMute = new System.Windows.Forms.Button();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faccountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpasswordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fnickNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fisLockedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fisMutedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ferrorTimesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floginIdentifierDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dvgUserList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgUserList
            // 
            this.dvgUserList.AllowUserToAddRows = false;
            this.dvgUserList.AllowUserToDeleteRows = false;
            this.dvgUserList.AutoGenerateColumns = false;
            this.dvgUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fidDataGridViewTextBoxColumn,
            this.faccountDataGridViewTextBoxColumn,
            this.fpasswordDataGridViewTextBoxColumn,
            this.fnickNameDataGridViewTextBoxColumn,
            this.fisLockedDataGridViewTextBoxColumn,
            this.fisMutedDataGridViewTextBoxColumn,
            this.ferrorTimesDataGridViewTextBoxColumn,
            this.floginIdentifierDataGridViewTextBoxColumn});
            this.dvgUserList.DataSource = this.accountBindingSource;
            this.dvgUserList.Location = new System.Drawing.Point(9, 41);
            this.dvgUserList.Name = "dvgUserList";
            this.dvgUserList.ReadOnly = true;
            this.dvgUserList.RowTemplate.Height = 24;
            this.dvgUserList.Size = new System.Drawing.Size(445, 257);
            this.dvgUserList.TabIndex = 0;
            this.dvgUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgUserList_CellClick);
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(217, 12);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.TabIndex = 3;
            this.btnUnlock.Text = "解鎖";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(298, 12);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(75, 23);
            this.btnMute.TabIndex = 4;
            this.btnMute.Text = "禁言";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnUnMute
            // 
            this.btnUnMute.Location = new System.Drawing.Point(379, 12);
            this.btnUnMute.Name = "btnUnMute";
            this.btnUnMute.Size = new System.Drawing.Size(75, 23);
            this.btnUnMute.TabIndex = 5;
            this.btnUnMute.Text = "解禁言";
            this.btnUnMute.UseVisualStyleBackColor = true;
            this.btnUnMute.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // accountBindingSource
            // 
            this.accountBindingSource.DataSource = typeof(ChatRoom.Domain.Model.DataType.Account);
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
            this.faccountDataGridViewTextBoxColumn.HeaderText = "帳號";
            this.faccountDataGridViewTextBoxColumn.Name = "faccountDataGridViewTextBoxColumn";
            this.faccountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fpasswordDataGridViewTextBoxColumn
            // 
            this.fpasswordDataGridViewTextBoxColumn.DataPropertyName = "f_password";
            this.fpasswordDataGridViewTextBoxColumn.HeaderText = "f_password";
            this.fpasswordDataGridViewTextBoxColumn.Name = "fpasswordDataGridViewTextBoxColumn";
            this.fpasswordDataGridViewTextBoxColumn.ReadOnly = true;
            this.fpasswordDataGridViewTextBoxColumn.Visible = false;
            // 
            // fnickNameDataGridViewTextBoxColumn
            // 
            this.fnickNameDataGridViewTextBoxColumn.DataPropertyName = "f_nickName";
            this.fnickNameDataGridViewTextBoxColumn.HeaderText = "暱稱";
            this.fnickNameDataGridViewTextBoxColumn.Name = "fnickNameDataGridViewTextBoxColumn";
            this.fnickNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fisLockedDataGridViewTextBoxColumn
            // 
            this.fisLockedDataGridViewTextBoxColumn.DataPropertyName = "f_isLocked";
            this.fisLockedDataGridViewTextBoxColumn.HeaderText = "鎖定狀態";
            this.fisLockedDataGridViewTextBoxColumn.Name = "fisLockedDataGridViewTextBoxColumn";
            this.fisLockedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fisMutedDataGridViewTextBoxColumn
            // 
            this.fisMutedDataGridViewTextBoxColumn.DataPropertyName = "f_isMuted";
            this.fisMutedDataGridViewTextBoxColumn.HeaderText = "禁言狀態";
            this.fisMutedDataGridViewTextBoxColumn.Name = "fisMutedDataGridViewTextBoxColumn";
            this.fisMutedDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ferrorTimesDataGridViewTextBoxColumn
            // 
            this.ferrorTimesDataGridViewTextBoxColumn.DataPropertyName = "f_errorTimes";
            this.ferrorTimesDataGridViewTextBoxColumn.HeaderText = "f_errorTimes";
            this.ferrorTimesDataGridViewTextBoxColumn.Name = "ferrorTimesDataGridViewTextBoxColumn";
            this.ferrorTimesDataGridViewTextBoxColumn.ReadOnly = true;
            this.ferrorTimesDataGridViewTextBoxColumn.Visible = false;
            // 
            // floginIdentifierDataGridViewTextBoxColumn
            // 
            this.floginIdentifierDataGridViewTextBoxColumn.DataPropertyName = "f_loginIdentifier";
            this.floginIdentifierDataGridViewTextBoxColumn.HeaderText = "f_loginIdentifier";
            this.floginIdentifierDataGridViewTextBoxColumn.Name = "floginIdentifierDataGridViewTextBoxColumn";
            this.floginIdentifierDataGridViewTextBoxColumn.ReadOnly = true;
            this.floginIdentifierDataGridViewTextBoxColumn.Visible = false;
            // 
            // UserInfoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 310);
            this.Controls.Add(this.btnUnMute);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.dvgUserList);
            this.Name = "UserInfoListForm";
            this.Text = " 使用者列表";
            this.Shown += new System.EventHandler(this.UserInfoList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgUserList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgUserList;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnUnMute;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faccountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fpasswordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fnickNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fisLockedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fisMutedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ferrorTimesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn floginIdentifierDataGridViewTextBoxColumn;
    }
}