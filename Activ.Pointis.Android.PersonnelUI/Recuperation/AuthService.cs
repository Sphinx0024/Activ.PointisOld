using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activ.Pointis.Android.PersonnelUI.Recuperation
{
    public class AuthService
    {
        private const string IsLoggedInKey = "IsLoggedIn";

        public bool IsUserLoggedIn()
        {
            return SecureStorage.GetAsync(IsLoggedInKey).Result == "true";
        }


        public void SetUserLoggedIn()
        {
            SecureStorage.SetAsync(IsLoggedInKey, "true");
        }

        public void LogoutUser()
        {
            SecureStorage.Remove(IsLoggedInKey);
        }

        public void SaveID(string key, string value)
        {
            SecureStorage.SetAsync(key, value);
        }

        public string GetID(string key)
        {
            return SecureStorage.GetAsync(key).Result;
        }

    }
}
