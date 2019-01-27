using System;

namespace SteamLoginManager
{
    public class Account
    {
        public string Username, Password;
        public long SteamId;

        public bool SteamGuard = false;
        public string SteamGuardSecret;

        public string GenerateSteamGuard()
        {
            if(!SteamGuard || SteamGuardSecret == null || SteamGuardSecret.Length == 0)
            {
                return null;
            }
            try
            {
                return new SteamAuth.SteamGuardAccount()
                {
                    SharedSecret = SteamGuardSecret
                }.GenerateSteamGuardCode();
            }
            catch
            {
                return null;
            }
        }
    }
}
