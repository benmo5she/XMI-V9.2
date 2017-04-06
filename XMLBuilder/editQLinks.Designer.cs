namespace XMI
{
    partial class editQLinks
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.reset = new RibbonStyle.RibbonMenuButton();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(14, 15);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(483, 225);
            this.listBox1.TabIndex = 0;
            // 
            // reset
            // 
            this.reset.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.reset.BackColor = System.Drawing.Color.Transparent;
            this.reset.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.reset.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.reset.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.reset.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.reset.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.reset.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.reset.FadingSpeed = 0;
            this.reset.FlatAppearance.BorderSize = 0;
            this.reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.ForeColor = System.Drawing.Color.DarkBlue;
            this.reset.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.reset.Image = global::XMI.Properties.Resources.Action_reload_icon;
            this.reset.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.reset.ImageOffset = 5;
            this.reset.IsPressed = false;
            this.reset.KeepPress = false;
            this.reset.Location = new System.Drawing.Point(214, 255);
            this.reset.MaxImageSize = new System.Drawing.Point(38, 0);
            this.reset.MenuPos = new System.Drawing.Point(0, 0);
            this.reset.Name = "reset";
            this.reset.Radius = 8;
            this.reset.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.reset.Size = new System.Drawing.Size(75, 61);
            this.reset.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.reset.SplitDistance = 0;
            this.reset.TabIndex = 62;
            this.reset.TabStop = false;
            this.reset.Text = "Reset";
            this.reset.Title = "";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // editQLinks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(509, 328);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.listBox1);
            this.Name = "editQLinks";
            this.Text = "editQLinks";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        public RibbonStyle.RibbonMenuButton reset;


    }
}