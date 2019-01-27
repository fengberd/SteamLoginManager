using System;
using System.Windows.Forms;

namespace SteamLoginManager
{
    public partial class AddAccountForm : Form
    {
        public string EditAccount = null;
        public AddAccountForm(string edit = null)
        {
            InitializeComponent();
            EditAccount = edit;
            if(edit != null)
            {
                Text = "Edit Account";
                button1.Text = "Save";
                foreach(var account in Utils.Accounts)
                {
                    if(account.Username == edit)
                    {
                        textBox1.Text = account.Username;
                        textBox2.Text = account.Password;
                        checkBox1.Checked = account.SteamGuard;
                        textBox3.Text = account.SteamGuardSecret;
                        textBox4.Text = account.SteamId.ToString();
                        textBox5.Text = account.Note;
                    }
                }
            }
        }

        private void button1_Click(object sender,EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Username can't be blank!","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if(textBox2.Text == "")
            {
                MessageBox.Show("Password can't be blank!","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if(textBox4.Text == "")
            {
                MessageBox.Show("Steam ID is required!","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if(checkBox1.Checked && textBox3.Text == "")
            {
                MessageBox.Show("Steam Guard Secret can't be blank!","Error",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            if(EditAccount != null)
            {
                foreach(var account in Utils.Accounts)
                {
                    if(account.Username == EditAccount)
                    {
                        account.Username = textBox1.Text;
                        account.Password = textBox2.Text;
                        account.SteamGuard = checkBox1.Checked;
                        account.SteamGuardSecret = textBox3.Text;
                        account.SteamId = long.Parse(textBox4.Text);
                        account.Note = textBox5.Text;
                    }
                }
            }
            else
            {
                Utils.Accounts.Add(new Account()
                {
                    Username = textBox1.Text,
                    Password = textBox2.Text,
                    SteamGuard = checkBox1.Checked,
                    SteamGuardSecret = textBox3.Text,
                    SteamId = long.Parse(textBox4.Text),
                    Note = textBox5.Text
                });
            }
            if(Utils.SaveAccounts())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender,EventArgs e)
        {
            textBox3.Enabled = checkBox1.Checked;
            if(!checkBox1.Checked)
            {
                textBox3.Text = "";
            }
        }

        private void textBoxTrim_Leave(object sender,EventArgs e)
        {
            var text = (TextBox)sender;
            text.Text = text.Text.Trim();
        }

        private void textBoxInt_Leave(object sender,EventArgs e)
        {
            var text = (TextBox)sender;
            if(!long.TryParse(text.Text.Trim(),out long value))
            {
                text.Text = "";
            }
            else
            {
                text.Text = value.ToString();
            }
        }
    }
}
