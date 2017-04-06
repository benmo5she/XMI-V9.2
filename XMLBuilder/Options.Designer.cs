namespace XMI
{
    partial class Options
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
            this.dirOL = new System.Windows.Forms.Label();
            this.dirO = new System.Windows.Forms.TextBox();
            this.serverL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.server = new System.Windows.Forms.ComboBox();
            this.pdir = new System.Windows.Forms.PictureBox();
            this.save = new RibbonStyle.RibbonMenuButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdir)).BeginInit();
            this.SuspendLayout();
            // 
            // dirOL
            // 
            this.dirOL.AutoSize = true;
            this.dirOL.Location = new System.Drawing.Point(3, 47);
            this.dirOL.Name = "dirOL";
            this.dirOL.Size = new System.Drawing.Size(49, 13);
            this.dirOL.TabIndex = 0;
            this.dirOL.Text = "Directory";
            // 
            // dirO
            // 
            this.dirO.Location = new System.Drawing.Point(89, 44);
            this.dirO.Name = "dirO";
            this.dirO.Size = new System.Drawing.Size(243, 20);
            this.dirO.TabIndex = 1;
            // 
            // serverL
            // 
            this.serverL.AutoSize = true;
            this.serverL.Location = new System.Drawing.Point(3, 21);
            this.serverL.Name = "serverL";
            this.serverL.Size = new System.Drawing.Size(75, 13);
            this.serverL.TabIndex = 2;
            this.serverL.Text = "Default Server";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.server);
            this.panel1.Controls.Add(this.pdir);
            this.panel1.Controls.Add(this.save);
            this.panel1.Controls.Add(this.dirO);
            this.panel1.Controls.Add(this.serverL);
            this.panel1.Controls.Add(this.dirOL);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 172);
            this.panel1.TabIndex = 62;
            // 
            // server
            // 
            this.server.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.server.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.server.FormattingEnabled = true;
            this.server.Location = new System.Drawing.Point(90, 15);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(266, 21);
            this.server.TabIndex = 72;
            // 
            // pdir
            // 
            this.pdir.Image = global::XMI.Properties.Resources.folder_open;
            this.pdir.Location = new System.Drawing.Point(338, 47);
            this.pdir.Name = "pdir";
            this.pdir.Size = new System.Drawing.Size(18, 16);
            this.pdir.TabIndex = 70;
            this.pdir.TabStop = false;
            this.pdir.Click += new System.EventHandler(this.pdir_Click);
            // 
            // save
            // 
            this.save.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.save.BackColor = System.Drawing.Color.Transparent;
            this.save.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.save.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.save.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.save.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.save.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.save.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.save.FadingSpeed = 0;
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save.ForeColor = System.Drawing.Color.DarkBlue;
            this.save.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.save.Image = global::XMI.Properties.Resources.kedit;
            this.save.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.save.ImageOffset = 5;
            this.save.IsPressed = false;
            this.save.KeepPress = false;
            this.save.Location = new System.Drawing.Point(64, 96);
            this.save.MaxImageSize = new System.Drawing.Point(38, 0);
            this.save.MenuPos = new System.Drawing.Point(0, 0);
            this.save.Name = "save";
            this.save.Radius = 8;
            this.save.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.save.Size = new System.Drawing.Size(243, 61);
            this.save.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.save.SplitDistance = 0;
            this.save.TabIndex = 61;
            this.save.Text = "Save Settings";
            this.save.Title = "";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.ribbonMenuButton1_Click);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(392, 194);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Options_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label dirOL;
        private System.Windows.Forms.TextBox dirO;
        private System.Windows.Forms.Label serverL;
        private RibbonStyle.RibbonMenuButton save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pdir;
        private System.Windows.Forms.ComboBox server;

    }
}