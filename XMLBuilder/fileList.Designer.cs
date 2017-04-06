namespace XMI
{
    partial class fileList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.search = new System.Windows.Forms.TextBox();
            this.searchL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.delete = new RibbonStyle.RibbonMenuButton();
            this.addPlan = new RibbonStyle.RibbonMenuButton();
            this.load = new RibbonStyle.RibbonMenuButton();
            this.runM = new RibbonStyle.RibbonMenuButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addTest = new System.Windows.Forms.ToolStripMenuItem();
            this.loadX = new System.Windows.Forms.ToolStripMenuItem();
            this.runMu = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(78, 6);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(242, 20);
            this.search.TabIndex = 3;
            this.search.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // searchL
            // 
            this.searchL.AutoSize = true;
            this.searchL.Location = new System.Drawing.Point(19, 9);
            this.searchL.Name = "searchL";
            this.searchL.Size = new System.Drawing.Size(41, 13);
            this.searchL.TabIndex = 4;
            this.searchL.Text = "Search";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.delete);
            this.panel1.Controls.Add(this.addPlan);
            this.panel1.Controls.Add(this.load);
            this.panel1.Controls.Add(this.runM);
            this.panel1.Controls.Add(this.searchL);
            this.panel1.Controls.Add(this.search);
            this.panel1.Location = new System.Drawing.Point(1, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(695, 286);
            this.panel1.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-2, 35);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(645, 224);
            this.dataGridView1.TabIndex = 69;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileListDataGridView_CellClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // delete
            // 
            this.delete.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.delete.BackColor = System.Drawing.Color.Transparent;
            this.delete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.delete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.delete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.delete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.delete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.delete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.delete.FadingSpeed = 0;
            this.delete.FlatAppearance.BorderSize = 0;
            this.delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.delete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.ForeColor = System.Drawing.Color.DarkBlue;
            this.delete.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.delete.Image = global::XMI.Properties.Resources.gtkremove;
            this.delete.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.delete.ImageOffset = 5;
            this.delete.IsPressed = false;
            this.delete.KeepPress = false;
            this.delete.Location = new System.Drawing.Point(525, 290);
            this.delete.MaxImageSize = new System.Drawing.Point(38, 0);
            this.delete.MenuPos = new System.Drawing.Point(0, 0);
            this.delete.Name = "delete";
            this.delete.Radius = 8;
            this.delete.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.delete.Size = new System.Drawing.Size(75, 61);
            this.delete.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.delete.SplitDistance = 0;
            this.delete.TabIndex = 68;
            this.delete.Text = "Delete";
            this.delete.Title = "";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // addPlan
            // 
            this.addPlan.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.addPlan.BackColor = System.Drawing.Color.Transparent;
            this.addPlan.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.addPlan.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.addPlan.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.addPlan.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.addPlan.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addPlan.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.addPlan.FadingSpeed = 0;
            this.addPlan.FlatAppearance.BorderSize = 0;
            this.addPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPlan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPlan.ForeColor = System.Drawing.Color.DarkBlue;
            this.addPlan.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.addPlan.Image = global::XMI.Properties.Resources.add;
            this.addPlan.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.addPlan.ImageOffset = 5;
            this.addPlan.IsPressed = false;
            this.addPlan.KeepPress = false;
            this.addPlan.Location = new System.Drawing.Point(57, 290);
            this.addPlan.MaxImageSize = new System.Drawing.Point(38, 0);
            this.addPlan.MenuPos = new System.Drawing.Point(0, 0);
            this.addPlan.Name = "addPlan";
            this.addPlan.Radius = 8;
            this.addPlan.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.addPlan.Size = new System.Drawing.Size(75, 61);
            this.addPlan.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.addPlan.SplitDistance = 0;
            this.addPlan.TabIndex = 67;
            this.addPlan.Text = "Add test Plan";
            this.addPlan.Title = "";
            this.addPlan.UseVisualStyleBackColor = true;
            this.addPlan.Click += new System.EventHandler(this.addPlan_Click);
            // 
            // load
            // 
            this.load.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.load.AutoEllipsis = true;
            this.load.BackColor = System.Drawing.Color.Transparent;
            this.load.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.load.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.load.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.load.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.load.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.load.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.load.FadingSpeed = 0;
            this.load.FlatAppearance.BorderSize = 0;
            this.load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.load.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load.ForeColor = System.Drawing.Color.DarkBlue;
            this.load.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.load.Image = global::XMI.Properties.Resources.documentopen;
            this.load.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.load.ImageOffset = 5;
            this.load.IsPressed = false;
            this.load.KeepPress = false;
            this.load.Location = new System.Drawing.Point(221, 290);
            this.load.MaxImageSize = new System.Drawing.Point(38, 0);
            this.load.MenuPos = new System.Drawing.Point(0, 0);
            this.load.Name = "load";
            this.load.Radius = 8;
            this.load.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.load.Size = new System.Drawing.Size(75, 61);
            this.load.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.load.SplitDistance = 0;
            this.load.TabIndex = 66;
            this.load.Text = "Load";
            this.load.Title = "";
            this.load.UseVisualStyleBackColor = true;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // runM
            // 
            this.runM.Arrow = RibbonStyle.RibbonMenuButton.e_arrow.None;
            this.runM.BackColor = System.Drawing.Color.Transparent;
            this.runM.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.runM.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.runM.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.runM.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.runM.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.runM.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.runM.FadingSpeed = 0;
            this.runM.FlatAppearance.BorderSize = 0;
            this.runM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.runM.ForeColor = System.Drawing.Color.DarkBlue;
            this.runM.GroupPos = RibbonStyle.RibbonMenuButton.e_groupPos.None;
            this.runM.Image = global::XMI.Properties.Resources.gtkpaste;
            this.runM.ImageLocation = RibbonStyle.RibbonMenuButton.e_imagelocation.Top;
            this.runM.ImageOffset = 5;
            this.runM.IsPressed = false;
            this.runM.KeepPress = false;
            this.runM.Location = new System.Drawing.Point(387, 290);
            this.runM.MaxImageSize = new System.Drawing.Point(38, 0);
            this.runM.MenuPos = new System.Drawing.Point(0, 0);
            this.runM.Name = "runM";
            this.runM.Radius = 8;
            this.runM.ShowBase = RibbonStyle.RibbonMenuButton.e_showbase.Yes;
            this.runM.Size = new System.Drawing.Size(75, 61);
            this.runM.SplitButton = RibbonStyle.RibbonMenuButton.e_splitbutton.No;
            this.runM.SplitDistance = 0;
            this.runM.TabIndex = 65;
            this.runM.Text = "Run Tests";
            this.runM.Title = "";
            this.runM.UseVisualStyleBackColor = true;
            this.runM.Click += new System.EventHandler(this.runM_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTest,
            this.loadX,
            this.runMu,
            this.deleteRow});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addTest
            // 
            this.addTest.Image = global::XMI.Properties.Resources.expand;
            this.addTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addTest.Name = "addTest";
            this.addTest.Size = new System.Drawing.Size(108, 20);
            this.addTest.Text = "Add Test Plan";
            this.addTest.Click += new System.EventHandler(this.addPlan_Click);
            // 
            // loadX
            // 
            this.loadX.Image = global::XMI.Properties.Resources.folder_open;
            this.loadX.Name = "loadX";
            this.loadX.Size = new System.Drawing.Size(61, 20);
            this.loadX.Text = "Load";
            this.loadX.Click += new System.EventHandler(this.loadX_Click);
            // 
            // runMu
            // 
            this.runMu.Image = global::XMI.Properties.Resources.gtkpaste;
            this.runMu.Name = "runMu";
            this.runMu.Size = new System.Drawing.Size(133, 20);
            this.runMu.Text = "Run Multiple Tests";
            this.runMu.Click += new System.EventHandler(this.runMu_Click);
            // 
            // deleteRow
            // 
            this.deleteRow.Image = global::XMI.Properties.Resources.gtkremove;
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Size = new System.Drawing.Size(68, 20);
            this.deleteRow.Text = "Delete";
            this.deleteRow.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // fileList
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(650, 286);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(127, 283);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fileList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "STD DB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fileList_FormClosing);
            this.Load += new System.EventHandler(this.fileList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox search;
        public System.Windows.Forms.Label searchL;
        private System.Windows.Forms.Panel panel1;
        private RibbonStyle.RibbonMenuButton runM;
        private RibbonStyle.RibbonMenuButton load;
        private RibbonStyle.RibbonMenuButton addPlan;
        private RibbonStyle.RibbonMenuButton delete;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addTest;
        private System.Windows.Forms.ToolStripMenuItem runMu;
        private System.Windows.Forms.ToolStripMenuItem deleteRow;
        public System.Windows.Forms.ToolStripMenuItem loadX;
        public System.Windows.Forms.DataGridView dataGridView1;
    }
}