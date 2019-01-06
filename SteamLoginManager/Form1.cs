using System;
using System.Windows.Forms;

using BakaServer;

namespace SteamLoginManager
{
    public partial class Form1 : Form
    {
        public static Config config = new Config("config.ini"), accounts = new Config("accounts.ini");

        private int HEIGHT_ORIGINAL, HEIGHT_EXPANDED;

        public Form1()
        {
            InitializeComponent();
            HEIGHT_EXPANDED = Height;
            HEIGHT_ORIGINAL = HEIGHT_EXPANDED - groupBox2.Height - 12;
            Height = HEIGHT_ORIGINAL;
        }

        private void button1_Click(object sender,EventArgs e)
        {

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
    }
}
