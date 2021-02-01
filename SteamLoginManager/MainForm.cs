using System;
using System.IO;
using System.Windows.Forms;

using BakaServer;

namespace SteamLoginManager
{
    public partial class MainForm : Form
    {
        public static Config config = new Config("config.ini");

        private int HEIGHT_ORIGINAL, HEIGHT_EXPANDED;

        public void RefreshAccounts()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var account in Utils.Accounts)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    account.Username,
                    account.Note,
                    account.SteamId.ToString(),
                    account.SteamGuard?"√":""
                }));
            }
            listView1.EndUpdate();
            listView1_ItemSelectionChanged();
        }

        public void LoginCurrentSelected()
        {
            if (listView1.SelectedItems.Count != 1)
            {
                return;
            }
            Utils.KillSteam();
            foreach (var account in Utils.Accounts)
            {
                if (account.Username == listView1.SelectedItems[0].Text)
                {
                    if (!checkBox1.Checked || Utils.ProcessUserData(account.SteamId))
                    {
                        if (!checkBox2.Checked || Utils.DeleteLoginUsers())
                        {
                            if (Utils.LoginAccount(account) && checkBox3.Checked)
                            {
                                WindowState = FormWindowState.Minimized;
                            }
                        }
                    }
                    return;
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();
            HEIGHT_EXPANDED = Height;
            HEIGHT_ORIGINAL = HEIGHT_EXPANDED - groupBox2.Height - 12;
            Height = HEIGHT_ORIGINAL;

            Utils.SteamPath = config["SteamPath", Utils.SteamPath];
            textBox1.Text = Utils.SteamPath;
            checkBox1.Checked = config.GetBool("ProcessUserData", false);
            checkBox2.Checked = config.GetBool("DeleteLoginUser", false);
            checkBox3.Checked = config.GetBool("MinimizeAfterLogin", false);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Utils.InitAccounts();
            RefreshAccounts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (new AddAccountForm().ShowDialog() == DialogResult.OK)
            {
                RefreshAccounts();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Height == HEIGHT_EXPANDED)
            {
                Height = HEIGHT_ORIGINAL;
                button2.Text = "▼";
            }
            else
            {
                Height = HEIGHT_EXPANDED;
                button2.Text = "▲";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            config["ProcessUserData"] = checkBox1.Checked.ToString();
            config.Save();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            config["DeleteLoginUser"] = checkBox2.Checked.ToString();
            config.Save();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            config["MinimizeAfterLogin"] = checkBox3.Checked.ToString();
            config.Save();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            try
            {
                var full = Path.GetFullPath(textBox1.Text);
                if (!File.Exists(Path.Combine(full, "Steam.exe")))
                {
                    throw new Exception("Not a steam path");
                }
                Utils.SteamPath = full;
                config["SteamPath"] = Utils.SteamPath;
                config.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't parse path you entered,please check and try again.\n\n" +
                    "Exception Details:\n" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = Utils.SteamPath;
        }

        #region listView1 Events

        private void listView1_ItemSelectionChanged(object sender = null, ListViewItemSelectionChangedEventArgs e = null)
        {
            toolStripMenuItem2.Visible = accountToolStripMenuItem_Delete.Visible = listView1.SelectedItems.Count > 0;
            toolStripMenuItem1.Visible = accountToolStripMenuItem_Login.Visible = accountToolStripMenuItem_Edit.Visible = listView1.SelectedItems.Count == 1;
            accountToolStripMenuItem_SteamGuardCode.Visible = listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[3].Text != "";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoginCurrentSelected();
        }

        private void accountToolStripMenuItem_Login_Click(object sender, EventArgs e)
        {
            LoginCurrentSelected();
        }

        private void accountToolStripMenuItem_SteamGuardCode_Click(object sender, EventArgs e)
        {
            foreach (var account in Utils.Accounts)
            {
                if (account.Username == listView1.SelectedItems[0].Text)
                {
                    string code = account.GenerateSteamGuard();
                    if (code == null)
                    {
                        MessageBox.Show("Failed to generate code,please make sure you've entered the correct SharedSecret!", "Steam Guard", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Your code is " + code, "Steam Guard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }
            }
        }

        private void accountToolStripMenuItem_Edit_Click(object sender, EventArgs e)
        {
            if (new AddAccountForm(listView1.SelectedItems[0].Text).ShowDialog() == DialogResult.OK)
            {
                RefreshAccounts();
            }
        }

        private void accountToolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Account remove = null;
                foreach (var account in Utils.Accounts)
                {
                    if (account.Username == item.Text)
                    {
                        remove = account;
                        break;
                    }
                }
                if (remove != null)
                {
                    Utils.Accounts.Remove(remove);
                }
            }
            if (Utils.SaveAccounts())
            {
                RefreshAccounts();
            }
        }

        private void accountToolStripMenuItem_Reload_Click(object sender, EventArgs e)
        {
            Utils.InitAccounts();
            RefreshAccounts();
        }

        #endregion
    }
}
