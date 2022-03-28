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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.labRoomName = new System.Windows.Forms.Label();
            this.labNickName = new System.Windows.Forms.Label();
            this.textRoomName = new System.Windows.Forms.TextBox();
            this.textNickName = new System.Windows.Forms.TextBox();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 368);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(486, 22);
            this.textBox1.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(525, 354);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "送出";
            this.btnSend.UseVisualStyleBackColor = true;
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
            this.labNickName.Location = new System.Drawing.Point(25, 338);
            this.labNickName.Name = "labNickName";
            this.labNickName.Size = new System.Drawing.Size(29, 12);
            this.labNickName.TabIndex = 4;
            this.labNickName.Text = "暱稱";
            // 
            // textRoomName
            // 
            this.textRoomName.Location = new System.Drawing.Point(71, 12);
            this.textRoomName.Name = "textRoomName";
            this.textRoomName.Size = new System.Drawing.Size(149, 22);
            this.textRoomName.TabIndex = 5;
            // 
            // textNickName
            // 
            this.textNickName.Location = new System.Drawing.Point(71, 335);
            this.textNickName.Name = "textNickName";
            this.textNickName.Size = new System.Drawing.Size(139, 22);
            this.textNickName.TabIndex = 6;
            // 
            // btnUserList
            // 
            this.btnUserList.Location = new System.Drawing.Point(487, 19);
            this.btnUserList.Name = "btnUserList";
            this.btnUserList.Size = new System.Drawing.Size(113, 23);
            this.btnUserList.TabIndex = 7;
            this.btnUserList.Text = "房間使用者清單";
            this.btnUserList.UseVisualStyleBackColor = true;
            // 
            // ChatRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 419);
            this.Controls.Add(this.btnUserList);
            this.Controls.Add(this.textNickName);
            this.Controls.Add(this.textRoomName);
            this.Controls.Add(this.labNickName);
            this.Controls.Add(this.labRoomName);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textMessage);
            this.Name = "ChatRoom";
            this.Text = "ChatRoom";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label labRoomName;
        private System.Windows.Forms.Label labNickName;
        private System.Windows.Forms.TextBox textRoomName;
        private System.Windows.Forms.TextBox textNickName;
        private System.Windows.Forms.Button btnUserList;
    }
}