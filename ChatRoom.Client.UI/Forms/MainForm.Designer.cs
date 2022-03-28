namespace ChatRoom.Client.UI
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.textAccount = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangedPwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(155, 132);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "登入";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(56, 147);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 2;
            this.btnRegister.Text = "註冊";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.ButtonOnClick);
            // 
            // textAccount
            // 
            this.textAccount.Location = new System.Drawing.Point(88, 32);
            this.textAccount.Name = "textAccount";
            this.textAccount.Size = new System.Drawing.Size(142, 22);
            this.textAccount.TabIndex = 3;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(88, 82);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(142, 22);
            this.textPassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "帳號";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "密碼";
            // 
            // btnChangedPwd
            // 
            this.btnChangedPwd.Location = new System.Drawing.Point(155, 161);
            this.btnChangedPwd.Name = "btnChangedPwd";
            this.btnChangedPwd.Size = new System.Drawing.Size(75, 23);
            this.btnChangedPwd.TabIndex = 7;
            this.btnChangedPwd.Text = "修改密碼";
            this.btnChangedPwd.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 216);
            this.Controls.Add(this.btnChangedPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.textAccount);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnLogin);
            this.Name = "MainForm";
            this.Text = "聊天室系統";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox textAccount;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnChangedPwd;
    }
}

