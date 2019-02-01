using System;
using System.Threading;
using System.Windows.Forms;

namespace SteamLoginManager
{
    static class Program
    {
        public const string GUID = "SteamLoginManager/7d757cdf-819b-48ed-9b8c-1d0e9333bf72";

        private static EventWaitHandle waitHandle = null;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                waitHandle = EventWaitHandle.OpenExisting(GUID);
                waitHandle.Set();
                waitHandle.Close();
                return;
            }
            catch { }
            waitHandle = new EventWaitHandle(false,EventResetMode.AutoReset,GUID);
            var queryThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    while(true)
                    {
                        if(waitHandle.WaitOne())
                        {
                            var main = Application.OpenForms["MainForm"];
                            if(main != null)
                            {
                                main.Invoke(new Action(() =>
                                {
                                    main.WindowState = FormWindowState.Normal;
                                    main.Activate();
                                }));
                            }
                        }
                    }
                }
                catch(ThreadAbortException) { }
            }))
            {
                IsBackground = true
            };
            queryThread.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            queryThread.Abort();
            waitHandle.Close();
        }
    }
}
