using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace SteamLoginManager
{
    public static class Utils
    {
        public static string SteamPath = @"C:\Program Files (x86)\Steam\";
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
                if(MessageBox.Show("Failed to parse accounts.json,continue?\nContinue WILL CLEAR ALL OF YOUR ACCOUNTS DATA!\n\n" +
                    "Exception Details:\n" + e.ToString(),"Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.Yes)
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
                if(MessageBox.Show("Failed to save accounts.json,continue?\nContinue won't save the changes you made!\n\n" +
                    "Exception Details:\n" + e.ToString(),"Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) != DialogResult.Yes)
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

        public static bool ProcessUserData(long steamId)
        {
            var userdata = Path.Combine(SteamPath,"userdata");
            var userdata_backup = Path.Combine(SteamPath,"userdata_backup");
            if(!Directory.Exists(userdata_backup))
            {
                Directory.CreateDirectory(userdata_backup);
            }
            foreach(var dir in Directory.EnumerateDirectories(userdata))
            {
                var name = Path.GetFileName(dir);
                if(name != steamId.ToString())
                {
                    var target = Path.Combine(userdata_backup,name);
                    if(Directory.Exists(target))
                    {
                        try
                        {
                            Directory.Delete(target,true);
                        }
                        catch(Exception e)
                        {
                            if(MessageBox.Show("Failed to delete '" + target + "',continue?\n\n" +
                                "Exception Details:\n" + e,"Error",MessageBoxButtons.YesNo,MessageBoxIcon.Stop) != DialogResult.Yes)
                            {
                                return false;
                            }
                        }
                    }
                    try
                    {
                        Directory.Move(dir,target);
                    }
                    catch(Exception e)
                    {
                        if(MessageBox.Show("Failed to move '" + dir + "' to '" + target + "',continue?\n\n" +
                            "Exception Details:\n" + e,"Error",MessageBoxButtons.YesNo,MessageBoxIcon.Stop) != DialogResult.Yes)
                        {
                            return false;
                        }
                    }
                }
            }
            var fromBackup = Path.Combine(userdata_backup,steamId.ToString());
            if(Directory.Exists(fromBackup))
            {
                var moveTarget = Path.Combine(userdata,steamId.ToString());
                if(Directory.Exists(moveTarget))
                {
                    switch(MessageBox.Show("Target folder userdata/" + steamId + " already exists,override it with the folder in userdata_backup?\n\n" +
                        "Yes = Delete userdata and use userdata_backup instead\n" +
                        "No = Delete userdata_backup and continue\n" +
                        "Cancel = Do nothing and stop.","Warning",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Stop))
                    {
                    case DialogResult.Yes:
                        Directory.Delete(moveTarget,true);
                        Directory.Move(fromBackup,moveTarget);
                        break;
                    case DialogResult.No:
                        Directory.Delete(fromBackup,true);
                        break;
                    default:
                        return false;
                    }
                }
                else
                {
                    Directory.Move(fromBackup,moveTarget);
                }
            }
            return true;
        }

        public static bool DeleteLoginUsers()
        {
            var file = Path.Combine(SteamPath,"config","loginusers.vdf");
            try
            {
                File.Delete(file);
            }
            catch { }
            if(File.Exists(file))
            {
                if(MessageBox.Show("Failed to delete loginusers.vdf,continue?","Error",MessageBoxButtons.YesNo,MessageBoxIcon.Error) != DialogResult.Yes)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool LoginAccount(Account account)
        {
            var steam = Path.Combine(SteamPath,"Steam.exe");
            if(!File.Exists(steam))
            {
                MessageBox.Show("Can't find Steam.exe in steam path.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = steam,
                    Arguments = "-login \"" + account.Username + "\" \"" + account.Password.Replace("\\","\\\\").Replace("\"","\\\"") + "\""
                });

                var code = account.GenerateSteamGuard();
                if (code != null)
                {
                    int tries = 30;
                    while (tries-- > 0)
                    {
                        Thread.Sleep(1000);
                        NTAPI.EnumWindows((hwnd, lparam) =>
                        {
                            if (NTAPI.GetWindowText(hwnd).Contains("Steam Guard"))
                            {
                                tries = -1;
                                if (NTAPI.SetForegroundWindow(hwnd) == 0)
                                {
                                    tries = 0;
                                    return false;
                                }
                                NTAPI.SendString(code + "\n");
                                return false;
                            }
                            return true;
                        }, IntPtr.Zero);
                    }
                    if (tries > -2) // Not automatically filled
                    {
                        MessageBox.Show("Your code is " + code, "Steam Guard", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Failed to start steam.\n\n" +
                    "Exception Details:\n" + e,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
