namespace ChatRoom.Backstage.Forms.UI
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRoomList = new System.Windows.Forms.Button();
            this.btnUserList = new System.Windows.Forms.Button();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.textUserInput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textConnectState = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRoomUser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textRoomName = new System.Windows.Forms.TextBox();
            this.btnLeaveRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRoomList
            // 
            this.btnRoomList.Location = new System.Drawing.Point(342, 9);
            this.btnRoomList.Name = "btnRoomList";
            this.btnRoomList.Size = new System.Drawing.Size(75, 23);
            this.btnRoomList.TabIndex = 9;
            this.btnRoomList.Text = "房間列表";
            this.btnRoomList.UseVisualStyleBackColor = true;
            this.btnRoomList.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // btnUserList
            // 
            this.btnUserList.Location = new System.Drawing.Point(261, 9);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(75, 23);
            this.btnUserList.TabIndex = 10;
            this.btnUserList.Text = "使用者列表";
            this.btnUserList.UseVisualStyleBackColor = true;
            this.btnUserList.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // textMessage
            // 
            this.textMessage.BackColor = System.Drawing.Color.White;
            this.textMessage.Location = new System.Drawing.Point(14, 73);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.ReadOnly = true;
            this.textMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textMessage.Size = new System.Drawing.Size(403, 128);
            this.textMessage.TabIndex = 11;
            // 
            // textUserInput
            // 
            this.textUserInput.Location = new System.Drawing.Point(14, 207);
            this.textUserInput.Name = "textUserInput";
            this.textUserInput.Size = new System.Drawing.Size(264, 22);
            this.textUserInput.TabIndex = 12;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(342, 207);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "送出";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // textConnectState
            // 
            this.textConnectState.Enabled = false;
            this.textConnectState.Location = new System.Drawing.Point(74, 9);
            this.textConnectState.Name = "textConnectState";
            this.textConnectState.ReadOnly = true;
            this.textConnectState.Size = new System.Drawing.Size(100, 22);
            this.textConnectState.TabIndex = 14;
            this.textConnectState.Text = "未連線";
            this.textConnectState.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "連線狀態:";
            // 
            // btnRoomUser
            // 
            this.btnRoomUser.Location = new System.Drawing.Point(180, 9);
            this.btnRoomUser.Name = "btnRoomUser";
            this.btnRoomUser.Size = new System.Drawing.Size(75, 23);
            this.btnRoomUser.TabIndex = 16;
            this.btnRoomUser.Text = "房間使用者";
            this.btnRoomUser.UseVisualStyleBackColor = true;
            this.btnRoomUser.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "房間名稱:";
            // 
            // textRoomName
            // 
            this.textRoomName.BackColor = System.Drawing.Color.White;
            this.textRoomName.Location = new System.Drawing.Point(74, 45);
            this.textRoomName.Name = "textRoomName";
            this.textRoomName.ReadOnly = true;
            this.textRoomName.Size = new System.Drawing.Size(100, 22);
            this.textRoomName.TabIndex = 18;
            // 
            // btnLeaveRoom
            // 
            this.btnLeaveRoom.Location = new System.Drawing.Point(342, 43);
            this.btnLeaveRoom.Name = "btnLeaveRoom";
            this.btnLeaveRoom.Size = new System.Drawing.Size(75, 23);
            this.btnLeaveRoom.TabIndex = 19;
            this.btnLeaveRoom.Text = "離開房間";
            this.btnLeaveRoom.UseVisualStyleBackColor = true;
            this.btnLeaveRoom.Click += new System.EventHandler(this.OnButtonClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 239);
            this.Controls.Add(this.btnLeaveRoom);
            this.Controls.Add(this.textRoomName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRoomUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textConnectState);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textUserInput);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.btnUserList);
            this.Controls.Add(this.btnRoomList);
            this.Name = "MainForm";
            this.Text = "後台介面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRoomList;
        private System.Windows.Forms.Button btnUserList;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.TextBox textUserInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textConnectState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRoomUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textRoomName;
        private System.Windows.Forms.Button btnLeaveRoom;
    }
}

