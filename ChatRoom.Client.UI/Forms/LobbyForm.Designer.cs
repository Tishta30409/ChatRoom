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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewRooms = new System.Windows.Forms.DataGridView();
            this.btnChangeNickName = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textNickName = new System.Windows.Forms.TextBox();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.roomBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.froomNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRooms
            // 
            this.dataGridViewRooms.AutoGenerateColumns = false;
            this.dataGridViewRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRooms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fidDataGridViewTextBoxColumn,
            this.froomNameDataGridViewTextBoxColumn});
            this.dataGridViewRooms.DataSource = this.roomBindingSource;
            this.dataGridViewRooms.Location = new System.Drawing.Point(12, 79);
            this.dataGridViewRooms.Name = "dataGridViewRooms";
            this.dataGridViewRooms.RowTemplate.Height = 24;
            this.dataGridViewRooms.Size = new System.Drawing.Size(220, 270);
            this.dataGridViewRooms.TabIndex = 0;
            this.dataGridViewRooms.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRoomList_Click);
            // 
            // btnChangeNickName
            // 
            this.btnChangeNickName.Location = new System.Drawing.Point(42, 40);
            this.btnChangeNickName.Name = "btnChangeNickName";
            this.btnChangeNickName.Size = new System.Drawing.Size(75, 23);
            this.btnChangeNickName.TabIndex = 1;
            this.btnChangeNickName.Text = "修改暱稱";
            this.btnChangeNickName.UseVisualStyleBackColor = true;
            this.btnChangeNickName.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 9F);
            this.label1.Location = new System.Drawing.Point(40, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "暱稱";
            // 
            // textNickName
            // 
            this.textNickName.Location = new System.Drawing.Point(75, 12);
            this.textNickName.MaxLength = 10;
            this.textNickName.Name = "textNickName";
            this.textNickName.Size = new System.Drawing.Size(123, 22);
            this.textNickName.TabIndex = 3;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Location = new System.Drawing.Point(124, 40);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangePwd.TabIndex = 4;
            this.btnChangePwd.Text = "修改密碼";
            this.btnChangePwd.UseVisualStyleBackColor = true;
            this.btnChangePwd.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(85, 356);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.ButtonOnClick);
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
            this.fidDataGridViewTextBoxColumn.Visible = false;
            // 
            // froomNameDataGridViewTextBoxColumn
            // 
            this.froomNameDataGridViewTextBoxColumn.DataPropertyName = "f_roomName";
            this.froomNameDataGridViewTextBoxColumn.HeaderText = "房間名稱";
            this.froomNameDataGridViewTextBoxColumn.Name = "froomNameDataGridViewTextBoxColumn";
            // 
            // LobbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 391);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.textNickName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangeNickName);
            this.Controls.Add(this.dataGridViewRooms);
            this.Name = "LobbyForm";
            this.Text = "房間列表(雙擊房間進入)";
            this.Shown += new System.EventHandler(this.LobbyForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.Button btnChangeNickName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNickName;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.BindingSource roomBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn froomNameDataGridViewTextBoxColumn;
    }
}