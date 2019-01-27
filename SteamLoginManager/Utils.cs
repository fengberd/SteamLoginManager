using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Diagnostics;

namespace SteamLoginManager
{
    public static class Utils
    {
        public static List<Account> Accounts = new List<Account>();

        public static void InitAccounts()
        {
            try
            {
                Accounts.Clear();
                if(!File.Exists("accounts.json"))
                {
                    File.WriteAllText("accounts.json","[]",Encoding.UTF8);
                }
                Accounts.AddRange(JsonConvert.DeserializeObject<ICollection<Account>>(File.ReadAllText("accounts.json",Encoding.UTF8)));
            }
            catch(Exception e)
            {
                if(MessageBox.Show("Failed to parse accounts.json,continue?\nContinue WILL CLEAR ALL OF YOUR ACCOUNTS DATA!\n\nError Details:\n" + e.ToString(),"Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
        }

        public static bool SaveAccounts()
        {
            try
            {
                File.WriteAllText("accounts.json",JsonConvert.SerializeObject(Accounts),Encoding.UTF8);
            }
            catch(Exception e)
            {
                if(MessageBox.Show("Failed to save accounts.json,continue?\nContinue won't save the changes you made!\n\nError Details:\n" + e.ToString(),"Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        public static int KillSteam()
        {
            int count = 0;
            foreach(var process in Process.GetProcesses())
            {
                if(process.ProcessName == "Steam" || process.ProcessName == "steamwebhelper" || process.ProcessName == "SteamService")
                {
                    try
                    {
                        process.Kill();
                        count++;
                    }
                    catch { }
                }
            }
            return count;
        }

        public static void LoginAccount(Account account)
        {
            
        }
    }
}
