namespace SteamLoginManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SteamGuard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip_Account = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.accountToolStripMenuItem_Login = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.accountToolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.columnHeader_SteamId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_Account.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Username,
            this.columnHeader_SteamId,
            this.columnHeader_SteamGuard});
            this.listView1.ContextMenuStrip = this.contextMenuStrip_Account;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(471, 270);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // columnHeader_Username
            // 
            this.columnHeader_Username.Text = "Username";
            this.columnHeader_Username.Width = 250;
            // 
            // columnHeader_SteamGuard
            // 
            this.columnHeader_SteamGuard.Text = "Steam Guard";
            this.columnHeader_SteamGuard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_SteamGuard.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(370, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add Account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(466, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "▼";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 128);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // contextMenuStrip_Account
            // 
            this.contextMenuStrip_Account.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem_Login,
            this.toolStripMenuItem1,
            this.accountToolStripMenuItem_Edit,
            this.accountToolStripMenuItem_Delete,
            this.toolStripMenuItem2,
            this.reloadToolStripMenuItem});
            this.contextMenuStrip_Account.Name = "contextMenuStrip_Account";
            this.contextMenuStrip_Account.Size = new System.Drawing.Size(118, 104);
            // 
            // accountToolStripMenuItem_Login
            // 
            this.accountToolStripMenuItem_Login.Name = "accountToolStripMenuItem_Login";
            this.accountToolStripMenuItem_Login.Size = new System.Drawing.Size(117, 22);
            this.accountToolStripMenuItem_Login.Text = "Login";
            this.accountToolStripMenuItem_Login.Visible = false;
            this.accountToolStripMenuItem_Login.Click += new System.EventHandler(this.accountToolStripMenuItem_Login_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            this.toolStripMenuItem1.Visible = false;
            // 
            // accountToolStripMenuItem_Edit
            // 
            this.accountToolStripMenuItem_Edit.Name = "accountToolStripMenuItem_Edit";
            this.accountToolStripMenuItem_Edit.Size = new System.Drawing.Size(117, 22);
            this.accountToolStripMenuItem_Edit.Text = "Edit";
            this.accountToolStripMenuItem_Edit.Visible = false;
            this.accountToolStripMenuItem_Edit.Click += new System.EventHandler(this.accountToolStripMenuItem_Edit_Click);
            // 
            // accountToolStripMenuItem_Delete
            // 
            this.accountToolStripMenuItem_Delete.Name = "accountToolStripMenuItem_Delete";
            this.accountToolStripMenuItem_Delete.Size = new System.Drawing.Size(117, 22);
            this.accountToolStripMenuItem_Delete.Text = "Delete";
            this.accountToolStripMenuItem_Delete.Visible = false;
            this.accountToolStripMenuItem_Delete.Click += new System.EventHandler(this.accountToolStripMenuItem_Delete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(114, 6);
            this.toolStripMenuItem2.Visible = false;
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Steam Path:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(357, 21);
            this.textBox1.TabIndex = 1;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(8, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(126, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Process User Data";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // columnHeader_SteamId
            // 
            this.columnHeader_SteamId.Text = "SteamId";
            this.columnHeader_SteamId.Width = 120;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(446, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "SteamLoginManager";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip_Account.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_Username;
        private System.Windows.Forms.ColumnHeader columnHeader_SteamGuard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Account;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem_Login;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem_Delete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ColumnHeader columnHeader_SteamId;
        private System.Windows.Forms.Button button3;
    }
}

