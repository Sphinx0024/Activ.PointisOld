using Activ.Pointis.WebAPI.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace Activ.Pointis.WebAPI.Utilities
{
    public class Mapping
    {
        public static string CORS_Allow = Helper.TraiteListeString(ConfigurationManager.AppSettings["CORS_Allowed"].ToString(), new string[] { ";", "," }).Trim().Replace("#;", ",");
        public static string Url_Client = (ConfigurationManager.AppSettings["Url_Client"] != null ? ConfigurationManager.AppSettings["Url_Client"].ToString() : "");
        public static string Url_Active_Client = (ConfigurationManager.AppSettings["Url_Active_Client"] != null ? ConfigurationManager.AppSettings["Url_Active_Client"].ToString() : "");
        public static int AuthDiration = (ConfigurationManager.AppSettings["AuthDuration"] != null ? int.Parse(ConfigurationManager.AppSettings["AuthDuration"].ToString()) : 30);
        public static string ConnexionOrionString = (ConfigurationManager.AppSettings["ConnStringORION"] != null ? ConfigurationManager.AppSettings["ConnStringORION"].ToString() : "");
        public static string ConnexionFidelisString = (ConfigurationManager.AppSettings["ConnString"] != null ? ConfigurationManager.AppSettings["ConnString"].ToString() : "");
        public static string V_Client = (ConfigurationManager.AppSettings["VueCompte"] != null ? ConfigurationManager.AppSettings["VueCompte"].ToString() : "");
        public static int AuthDuration = 60;
        public static bool IsOrionDataBase = false;

        public static string url_user = "https://pointis.activactions.net/";
        public static string admin_page = "login.html";

        public static MailConfig MailConfig = new MailConfig()
        {
            gLogin = (ConfigurationManager.AppSettings["gLogin"] != null ? ConfigurationManager.AppSettings["gLogin"].ToString() : ""),
            gFrom = (ConfigurationManager.AppSettings["gFrom"] != null ? ConfigurationManager.AppSettings["gFrom"].ToString() : ""),
            gsmtp = (ConfigurationManager.AppSettings["gsmtp"] != null ? ConfigurationManager.AppSettings["gsmtp"].ToString() : ""),
            gport = short.Parse(ConfigurationManager.AppSettings["gport"] != null ? ConfigurationManager.AppSettings["gport"].ToString() : ""),
            gPwd = (ConfigurationManager.AppSettings["gPwd"] != null ? ConfigurationManager.AppSettings["gPwd"].ToString() : ""),
            gssl = bool.Parse(ConfigurationManager.AppSettings["gssl"] != null ? ConfigurationManager.AppSettings["gssl"].ToString() : "0")
        };

        public static string ClientMapCode = "#BM#";

        public const string USERROLEUSER = "User";

        public const string USERROLEADMIN = "Admin";

        public enum Status : byte
        {
            Nouveau = 0,
            EnCours = 1,
            Annuler = 2,
            Valider = 3,
            Rejeter = 4,
            Closed = 5,
            Archiver = 8,
            EnAttente = 9,
            Engager = 10,
        }

        public enum NotificationProcess
        {
            RetardEmployé
            //InscriptionClient
        }
    }
}