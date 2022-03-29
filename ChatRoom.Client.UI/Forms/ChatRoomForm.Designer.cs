namespace ChatRoom.Client.UI.Forms
{
    partial class ChatRoomForm
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
            this.textMessage = new System.Windows.Forms.TextBox();
            this.textUserEnter = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.labRoomName = new System.Windows.Forms.Label();
            this.labNickName = new System.Windows.Forms.Label();
            this.btnUserList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(14, 58);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textMessage.Size = new System.Drawing.Size(586, 264);
            this.textMessage.TabIndex = 0;
            // 
            // textUserEnter
            // 
            this.textUserEnter.Location = new System.Drawing.Point(14, 367);
            this.textUserEnter.MaxLength = 20;
            this.textUserEnter.Name = "textUserEnter";
            this.textUserEnter.Size = new System.Drawing.Size(486, 22);
            this.textUserEnter.TabIndex = 1;
            this.textUserEnter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textUserEnter_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(525, 367);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "送出";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // labRoomName
            // 
            this.labRoomName.AutoSize = true;
            this.labRoomName.Location = new System.Drawing.Point(12, 19);
            this.labRoomName.Name = "labRoomName";
            this.labRoomName.Size = new System.Drawing.Size(53, 12);
            this.labRoomName.TabIndex = 3;
            this.labRoomName.Text = "房間名稱";
            // 
            // labNickName
            // 
            this.labNickName.AutoSize = true;
            this.labNickName.Location = new System.Drawing.Point(12, 339);
            this.labNickName.Name = "labNickName";
            this.labNickName.Size = new System.Drawing.Size(80, 12);
            this.labNickName.TabIndex = 4;
            this.labNickName.Text = "暱稱:aaakdskad";
            // 
            // btnUserList
            // 
            this.btnUserList.Location = new System.Drawing.Point(487, 19);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(113, 23);
            this.btnUserList.TabIndex = 7;
            this.btnUserList.Text = "房間使用者清單";
            this.btnUserList.UseVisualStyleBackColor = true;
            this.btnUserList.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // ChatRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 413);
            this.Controls.Add(this.btnUserList);
            this.Controls.Add(this.labNickName);
            this.Controls.Add(this.labRoomName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textUserEnter);
            this.Controls.Add(this.textMessage);
            this.Name = "ChatRoomForm";
            this.Text = "ChatRoom";
            this.Shown += new System.EventHandler(this.ChatRoom_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.TextBox textUserEnter;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label labRoomName;
        private System.Windows.Forms.Label labNickName;
        private System.Windows.Forms.Button btnUserList;
    }
}