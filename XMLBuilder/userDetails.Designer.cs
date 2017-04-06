namespace XMI
{
    partial class userDetails
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
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.serverL = new System.Windows.Forms.Label();
            this.server = new System.Windows.Forms.ComboBox();
            this.password = new System.Windows.Forms.TextBox();
            this.passL = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.userl = new System.Windows.Forms.Label();
            this.terminal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(14, 146);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(118, 42);
            this.ok.TabIndex = 0;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(169, 146);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(118, 42);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // serverL
            // 
            this.serverL.AutoSize = true;
            this.serverL.Location = new System.Drawing.Point(11, 21);
            this.serverL.Name = "serverL";
            this.serverL.Size = new System.Drawing.Size(41, 13);
            this.serverL.TabIndex = 2;
            this.serverL.Text = "Server:";
            // 
            // server
            // 
            this.server.FormattingEnabled = true;
            this.server.Items.AddRange(new object[] {
            "https://cguat2.creditguard.co.il/xpo/Relay",
            "https://cgopt.creditguard.co.il/xpo/Relay"});
            this.server.Location = new System.Drawing.Point(58, 18);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(229, 21);
            this.server.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(218, 45);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(69, 20);
            this.password.TabIndex = 8;
            // 
            // passL
            // 
            this.passL.AutoSize = true;
            this.passL.Location = new System.Drawing.Point(156, 48);
            this.passL.Name = "passL";
            this.passL.Size = new System.Drawing.Size(56, 13);
            this.passL.TabIndex = 7;
            this.passL.Text = "Password:";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(58, 45);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(69, 20);
            this.user.TabIndex = 6;
            // 
            // userl
            // 
            this.userl.AutoSize = true;
            this.userl.Location = new System.Drawing.Point(11, 48);
            this.userl.Name = "userl";
            this.userl.Size = new System.Drawing.Size(32, 13);
            this.userl.TabIndex = 5;
            this.userl.Text = "User:";
            // 
            // terminal
            // 
            this.terminal.Location = new System.Drawing.Point(58, 71);
            this.terminal.Name = "terminal";
            this.terminal.Size = new System.Drawing.Size(69, 20);
            this.terminal.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Terminal:";
            // 
            // mid
            // 
            this.mid.Location = new System.Drawing.Point(218, 71);
            this.mid.Name = "mid";
            this.mid.Size = new System.Drawing.Size(69, 20);
            this.mid.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "MID:";
            // 
            // userDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 200);
            this.Controls.Add(this.mid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.terminal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passL);
            this.Controls.Add(this.user);
            this.Controls.Add(this.userl);
            this.Controls.Add(this.server);
            this.Controls.Add(this.serverL);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Name = "userDetails";
            this.ShowIcon = false;
            this.Text = "userDetails";
            this.Load += new System.EventHandler(this.userDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label serverL;
        public System.Windows.Forms.ComboBox server;
        public System.Windows.Forms.TextBox password;
        public System.Windows.Forms.Label passL;
        public System.Windows.Forms.TextBox user;
        public System.Windows.Forms.Label userl;
        public System.Windows.Forms.TextBox terminal;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox mid;
        public System.Windows.Forms.Label label2;
    }
}