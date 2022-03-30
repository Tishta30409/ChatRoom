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
            this.dvgUserList = new System.Windows.Forms.DataGridView();
            this.labState = new System.Windows.Forms.Label();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnUnMute = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnActive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dvgUserList)).BeginInit();
            this.SuspendLayout();
            // 
            // dvgUserList
            // 
            this.dvgUserList.AllowUserToAddRows = false;
            this.dvgUserList.AllowUserToDeleteRows = false;
            this.dvgUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgUserList.Location = new System.Drawing.Point(12, 110);
            this.dvgUserList.Name = "dvgUserList";
            this.dvgUserList.RowTemplate.Height = 24;
            this.dvgUserList.Size = new System.Drawing.Size(473, 257);
            this.dvgUserList.TabIndex = 0;
            this.dvgUserList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgUserList_CellClick);
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Location = new System.Drawing.Point(12, 18);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(35, 12);
            this.labState.TabIndex = 2;
            this.labState.Text = "狀態::";
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(12, 81);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(75, 23);
            this.btnUnlock.TabIndex = 3;
            this.btnUnlock.Text = "解鎖";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(93, 81);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(75, 23);
            this.btnMute.TabIndex = 4;
            this.btnMute.Text = "禁言";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnUnMute
            // 
            this.btnUnMute.Location = new System.Drawing.Point(174, 81);
            this.btnUnMute.Name = "btnUnMute";
            this.btnUnMute.Size = new System.Drawing.Size(75, 23);
            this.btnUnMute.TabIndex = 5;
            this.btnUnMute.Text = "解禁言";
            this.btnUnMute.UseVisualStyleBackColor = true;
            this.btnUnMute.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "鎖帳號 要確認有鎖定才可以解鎖";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "帳號禁言 要砍先前訊息";
            // 
            // btnActive
            // 
            this.btnActive.Location = new System.Drawing.Point(256, 81);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(75, 23);
            this.btnActive.TabIndex = 8;
            this.btnActive.Text = "Active";
            this.btnActive.UseVisualStyleBackColor = true;
            this.btnActive.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // UserInfoListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 377);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUnMute);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnUnlock);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.dvgUserList);
            this.Name = "UserInfoListForm";
            this.Text = " 使用者列表";
            this.Shown += new System.EventHandler(this.UserInfoList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dvgUserList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgUserList;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnUnMute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnActive;
    }
}