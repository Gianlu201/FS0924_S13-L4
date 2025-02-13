using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FS0924_S13_L4.Models
{
    public static class User
    {
        private static string Username { get; set; }
        private static string Password { get; set; }
        private static bool AccessState { get; set; } = false;
        public static List<DateTime> AccessHistory { get; set; } = new List<DateTime>();

        public static void SetUserInfo(string username, string password, DateTime date)
        {
            Username = username;
            Password = password;
            AccessHistory.Add(date);
            AccessState = true;
        }

        public static string GetUsername()
        {
            return Username;
        }

        public static bool Login(string password, DateTime now)
        {
            if (password == Password)
            {
                AccessState = true;
                AccessHistory.Add(now);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool Logout()
        {
            if (AccessState)
            {
                AccessState = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsUserLogged()
        {
            if (AccessState)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DateTime GetLastAccess()
        {
            return AccessHistory[AccessHistory.Count - 1];
        }
    }
}
