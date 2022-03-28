namespace ChatRoom.Client.UI.Forms
{
    partial class LobbyForm
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
            this.dataGridViewRooms = new System.Windows.Forms.DataGridView();
            this.btnChangeNickName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textNickName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRooms
            // 
            this.dataGridViewRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRooms.Location = new System.Drawing.Point(27, 57);
            this.dataGridViewRooms.Name = "dataGridViewRooms";
            this.dataGridViewRooms.RowTemplate.Height = 24;
            this.dataGridViewRooms.Size = new System.Drawing.Size(315, 296);
            this.dataGridViewRooms.TabIndex = 0;
            this.dataGridViewRooms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRoomList_Click);
            // 
            // btnChangeNickName
            // 
            this.btnChangeNickName.Location = new System.Drawing.Point(235, 16);
            this.btnChangeNickName.Name = "btnChangeNickName";
            this.btnChangeNickName.Size = new System.Drawing.Size(75, 23);
            this.btnChangeNickName.TabIndex = 1;
            this.btnChangeNickName.Text = "修改暱稱";
            this.btnChangeNickName.UseVisualStyleBackColor = true;
            this.btnChangeNickName.Click += new System.EventHandler(this.btnChangeNickName_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9F);
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "暱稱";
            // 
            // textNickName
            // 
            this.textNickName.Location = new System.Drawing.Point(60, 16);
            this.textNickName.Name = "textNickName";
            this.textNickName.Size = new System.Drawing.Size(141, 22);
            this.textNickName.TabIndex = 3;
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 415);
            this.Controls.Add(this.textNickName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeNickName);
            this.Controls.Add(this.dataGridViewRooms);
            this.Name = "LobbyForm";
            this.Text = "房間列表(雙擊房間進入)";
            this.Shown += new System.EventHandler(this.LobbyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.Button btnChangeNickName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNickName;
    }
}