using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using BakaServer;

namespace SteamLoginManager
{
    public partial class MainForm : Form
    {
        public static Config config = new Config("config.ini");

        private int HEIGHT_ORIGINAL, HEIGHT_EXPANDED;

        private Thread loginThread = null;

        public void RefreshAccounts()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach (var kv in Utils.Accounts)
            {
                var account = kv.Value;
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    kv.Key,
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
            panel1.Visible = true;
            loginThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    var account = Utils.Accounts[listView1.SelectedItems[0].Text];

                    LoginCallback("Killing Steam");
                    Utils.KillSteam();

                    if (checkBox1.Checked)
                    {
                        LoginCallback("Processing user data");
                        if (!Utils.ProcessUserData(account.SteamId))
                        {
                            LoginCallback(null);
                            return;
                        }
                    }

                    if (checkBox2.Checked)
                    {
                        LoginCallback("Deleting login users");
                        if (!Utils.DeleteLoginUsers())
                        {
                            LoginCallback(null);
                            return;
                        }
                    }

                    LoginCallback("Logging in");
                    Utils.LoginAccount(account, LoginCallback);

                    LoginCallback("");
                }
                catch (ThreadAbortException)
                {
                    LoginCallback(null);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }))
            {
                IsBackground = true
            };
            loginThread.Start();
        }

        public void LoginCallback(string state)
        {
            Invoke(new Action(() =>
            {
                if (state == null)
                {
                    panel1.Visible = false;
                }
                else if (state == "")
                {
                    panel1.Visible = false;
                    if (checkBox3.Checked)
                    {
                        WindowState = FormWindowState.Minimized;
                    }
                }
                else
                {
                    label_loading.Text = state;
                }
            }));
        }

        public MainForm()
        {
            InitializeComponent();
            HEIGHT_EXPANDED = Height;
            HEIGHT_ORIGINAL = HEIGHT_EXPANDED - groupBox2.Height - 12;
            Height = HEIGHT_ORIGINAL;

            panel1.Dock = DockStyle.Fill;

            label_loading.Height = (panel1.Height - label_loading.Height - progressBar1.Height) / 2 - 3;
            progressBar1.Top = label_loading.Bottom + 12;
            progressBar1.Left = (panel1.Width - progressBar1.Width) / 2;
            button4.Top = progressBar1.Bottom + 12;
            button4.Left = (panel1.Width - button4.Width) / 2;

            panel1.Visible = false;

            textBox1.Text = Utils.SteamPath = config["SteamPath", Utils.SteamPath];
            textBox2.Text = Utils.SteamTitle = config["SteamTitle", Utils.SteamTitle];
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (loginThread != null && loginThread.IsAlive)
            {
                loginThread.Abort();
                loginThread = null;
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

        private void textBox2_Leave(object sender, EventArgs e)
        {
            config["SteamTitle"] = Utils.SteamTitle = textBox2.Text;
            config.Save();
        }

        #region listView1 Events

        private void listView1_ItemSelectionChanged(object sender = null, ListViewItemSelectionChangedEventArgs e = null)
        {
            toolStripMenuItem2.Visible = accountToolStripMenuItem_Delete.Visible = listView1.SelectedItems.Count > 0;
            toolStripMenuItem1.Visible = accountToolStripMenuItem_Login.Visible = accountToolStripMenuItem_Edit.Visible = listView1.SelectedItems.Count == 1;
            accountToolStripMenuItem_SteamGuardCode.Visible = listView1.SelectedItems.Count == 1 && listView1.SelectedItems[0].SubItems[3].Text != "";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e) => LoginCurrentSelected();

        private void accountToolStripMenuItem_Login_Click(object sender, EventArgs e) => LoginCurrentSelected();

        private void accountToolStripMenuItem_SteamGuardCode_Click(object sender, EventArgs e)
        {
            var account = Utils.Accounts[listView1.SelectedItems[0].Text];
            var code = account.GenerateSteamGuard();
            if (code == null)
            {
                MessageBox.Show("Failed to generate code,please make sure you've entered the correct SharedSecret!", "Steam Guard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Account: " + account.Username + "\nCode: " + code, "Steam Guard", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Utils.Accounts.Remove(item.Text);
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
