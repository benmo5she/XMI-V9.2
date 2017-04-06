namespace XMI
{
    partial class textW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(textW));
            this.box = new System.Windows.Forms.RichTextBox();
            this.symbol = new System.Windows.Forms.PictureBox();
            this.autoFill = new RibbonStyle.RibbonMenuButton();
            this.save = new RibbonStyle.RibbonMenuButton();
            ((System.ComponentModel.ISupportInitialize)(this.symbol)).BeginInit();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.box.AutoWordSelection = true;
            this.box.Location = new System.Drawing.Point(12, 135);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(681, 332);
            this.box.TabIndex = 0;
            this.box.Text = "";
            this.box.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.box_LinkClicked);
            this.box.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseUp);
            // 
            // symbol
            // 
            this.symbol.Location = new System.Drawing.Point(12, 10);
            this.symbol.Name = "symbol";
            this.symbol.Size = new System.Drawing.Size(681, 119);
            this.symbol.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.symbol.TabIndex = 1;
            this.symbol.TabStop = false;
            // 
            // autoFill
            // 
            this.autoFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoFill.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.autoFill.BackColor = System.Drawing.Color.Transparent;
            this.autoFill.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.autoFill.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.autoFill.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.autoFill.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.autoFill.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.autoFill.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.autoFill.FadingSpeed = 0;
            this.autoFill.FlatAppearance.BorderSize = 0;
            this.autoFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoFill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoFill.ForeColor = System.Drawing.Color.DarkBlue;
            this.autoFill.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.autoFill.Image = global::XMI.Properties.Resources.tests4;
            this.autoFill.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.autoFill.ImageOffset = 5;
            this.autoFill.IsPressed = false;
            this.autoFill.KeepPress = false;
            this.autoFill.Location = new System.Drawing.Point(613, 10);
            this.autoFill.MaxImageSize = new System.Drawing.Point(38, 0);
            this.autoFill.MenuPos = new System.Drawing.Point(0, 0);
            this.autoFill.Name = "autoFill";
            this.autoFill.Radius = 8;
            this.autoFill.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.autoFill.Size = new System.Drawing.Size(80, 57);
            this.autoFill.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.autoFill.SplitDistance = 0;
            this.autoFill.TabIndex = 65;
            this.autoFill.TabStop = false;
            this.autoFill.Text = "autoFillJ106";
            this.autoFill.Title = "";
            this.autoFill.UseVisualStyleBackColor = true;
            this.autoFill.Visible = false;
            this.autoFill.Click += new System.EventHandler(this.autoFill_Click);
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
            this.save.Location = new System.Drawing.Point(228, 56);
            this.save.MaxImageSize = new System.Drawing.Point(38, 0);
            this.save.MenuPos = new System.Drawing.Point(0, 0);
            this.save.Name = "save";
            this.save.Radius = 8;
            this.save.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.save.Size = new System.Drawing.Size(243, 61);
            this.save.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.save.SplitDistance = 0;
            this.save.TabIndex = 66;
            this.save.Text = "Save Settings";
            this.save.Title = "";
            this.save.UseVisualStyleBackColor = true;
            this.save.Visible = false;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // textW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 496);
            this.Controls.Add(this.save);
            this.Controls.Add(this.autoFill);
            this.Controls.Add(this.symbol);
            this.Controls.Add(this.box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "textW";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.textW_Load);
            this.SizeChanged += new System.EventHandler(this.textW_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.symbol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox box;
        public System.Windows.Forms.PictureBox symbol;
        public RibbonStyle.RibbonMenuButton autoFill;
        public RibbonStyle.RibbonMenuButton save;
    }
}