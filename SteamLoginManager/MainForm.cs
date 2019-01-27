using System;
using System.Windows.Forms;

using BakaServer;

namespace SteamLoginManager
{
    public partial class MainForm : Form
    {
        public static Config config = new Config("config.ini"), accounts = new Config("accounts.ini");

        private int HEIGHT_ORIGINAL, HEIGHT_EXPANDED;

        public void RefreshAccounts()
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();
            foreach(var account in Utils.Accounts)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    account.Username,
                    account.SteamId.ToString(),
                    account.SteamGuard?"√":""
                }));
            }
            listView1.EndUpdate();
            listView1_ItemSelectionChanged();
        }

        public MainForm()
        {
            InitializeComponent();
            HEIGHT_EXPANDED = Height;
            HEIGHT_ORIGINAL = HEIGHT_EXPANDED - groupBox2.Height - 12;
            Height = HEIGHT_ORIGINAL;
        }

        private void MainForm_Load(object sender,EventArgs e)
        {
            Utils.InitAccounts();
            RefreshAccounts();
        }

        private void button1_Click(object sender,EventArgs e)
        {
            if(new AddAccountForm().ShowDialog() == DialogResult.OK)
            {
                RefreshAccounts();
            }
        }

        private void button2_Click(object sender,EventArgs e)
        {
            if(Height == HEIGHT_EXPANDED)
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

        private void listView1_ItemSelectionChanged(object sender=null,ListViewItemSelectionChangedEventArgs e=null)
        {
            toolStripMenuItem2.Visible = accountToolStripMenuItem_Delete.Visible = listView1.SelectedItems.Count > 0;
            toolStripMenuItem1.Visible = accountToolStripMenuItem_Login.Visible = accountToolStripMenuItem_Edit.Visible = listView1.SelectedItems.Count == 1;
        }

        private void accountToolStripMenuItem_Login_Click(object sender,EventArgs e)
        {
            Utils.KillSteam();
            foreach(var account in Utils.Accounts)
            {
                if(account.Username == listView1.SelectedItems[0].Text)
                {
                    Utils.LoginAccount(account);
                    return;
                }
            }
        }

        private void reloadToolStripMenuItem_Click(object sender,EventArgs e)
        {
            Utils.InitAccounts();
            RefreshAccounts();
        }

        private void accountToolStripMenuItem_Edit_Click(object sender,EventArgs e)
        {
            if(new AddAccountForm(listView1.SelectedItems[0].Text).ShowDialog() == DialogResult.OK)
            {
                RefreshAccounts();
            }
        }

        private void accountToolStripMenuItem_Delete_Click(object sender,EventArgs e)
        {
            foreach(ListViewItem item in listView1.SelectedItems)
            {
                Account remove = null;
                foreach(var account in Utils.Accounts)
                {
                    if(account.Username == item.Text)
                    {
                        remove = account;
                        break;
                    }
                }
                if(remove != null)
                {
                    Utils.Accounts.Remove(remove);
                }
            }
            if(Utils.SaveAccounts())
            {
                RefreshAccounts();
            }
        }
    }
}
