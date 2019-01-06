namespace SteamLoginManager
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem40 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem41 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem42 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem43 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem44 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem45 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem46 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem47 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem48 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem49 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem50 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem51 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem52 = new System.Windows.Forms.ListViewItem("");
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Username = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SteamId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_SteamGuard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 296);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Accounts";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Id,
            this.columnHeader_Username,
            this.columnHeader_SteamId,
            this.columnHeader_SteamGuard});
            this.listView1.GridLines = true;
            listViewItem40.StateImageIndex = 0;
            listViewItem41.StateImageIndex = 0;
            listViewItem42.StateImageIndex = 0;
            listViewItem43.StateImageIndex = 0;
            listViewItem44.StateImageIndex = 0;
            listViewItem45.StateImageIndex = 0;
            listViewItem46.StateImageIndex = 0;
            listViewItem47.StateImageIndex = 0;
            listViewItem48.StateImageIndex = 0;
            listViewItem49.StateImageIndex = 0;
            listViewItem50.StateImageIndex = 0;
            listViewItem51.StateImageIndex = 0;
            listViewItem52.StateImageIndex = 0;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem40,
            listViewItem41,
            listViewItem42,
            listViewItem43,
            listViewItem44,
            listViewItem45,
            listViewItem46,
            listViewItem47,
            listViewItem48,
            listViewItem49,
            listViewItem50,
            listViewItem51,
            listViewItem52});
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(611, 270);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Id
            // 
            this.columnHeader_Id.Text = "ID";
            // 
            // columnHeader_Username
            // 
            this.columnHeader_Username.Text = "Username";
            this.columnHeader_Username.Width = 250;
            // 
            // columnHeader_SteamId
            // 
            this.columnHeader_SteamId.Text = "Steam ID";
            this.columnHeader_SteamId.Width = 200;
            // 
            // columnHeader_SteamGuard
            // 
            this.columnHeader_SteamGuard.Text = "Steam Guard";
            this.columnHeader_SteamGuard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader_SteamGuard.Width = 80;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 314);
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
            this.button2.Location = new System.Drawing.Point(606, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(29, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "▼";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 343);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(623, 128);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 16);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 483);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SteamLoginManager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader_Id;
        private System.Windows.Forms.ColumnHeader columnHeader_Username;
        private System.Windows.Forms.ColumnHeader columnHeader_SteamId;
        private System.Windows.Forms.ColumnHeader columnHeader_SteamGuard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

