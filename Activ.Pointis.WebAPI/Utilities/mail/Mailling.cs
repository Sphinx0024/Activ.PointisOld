using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Activ.Pointis.WebAPI.Utilities
{
    public class Mailling
    {
        public static void EnvoyerMailAvecCopie(MailConfig Config, string Message, string objet, List<string> Adresse, List<string> CC)
        {
            SmtpClient client;
            string MsTemp = "";
            try
            {
                MsTemp = Properties.Resources.MailTempBody.ToString();
                //MsTemp = Properties.Resources.MailTempBody.ToString();
            }
            catch (Exception) { }

            Message = MsTemp.Replace("##BODY##", Message);
            try
            {
                string strAd = "";
                if (Adresse != null)
                {
                    if (Adresse.Count > 0)
                    {
                        foreach (string str in Adresse)
                        {
                            if (IsValidMail(str))
                            {
                                strAd += str.Trim() + ",";
                            }
                        }
                    }
                }

                strAd = strAd.Substring(0, strAd.Length - 1);

                using (MailMessage msg = new MailMessage(Config.gFrom, strAd, System.Web.HttpUtility.UrlDecode(objet), System.Web.HttpUtility.UrlDecode(Message)))
                {
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    client = new SmtpClient(Config.gsmtp, Config.gport)
                    {
                        UseDefaultCredentials = true,
                        Credentials = new NetworkCredential(Config.gLogin, Config.gPwd),
                        EnableSsl = Config.gssl
                    };

                    if (CC != null)
                    {
                        if (CC.Count > 0)
                        {
                            MailAddress Adr = null;
                            foreach (string str in CC)
                            {
                                if (IsValidMail(str))
                                {
                                    Adr = new MailAddress(str);
                                    msg.CC.Add(Adr);
                                }
                            }
                        }
                    }

                    msg.IsBodyHtml = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                    client.Dispose();
                }
            }
            catch (Exception ex)
            {
                EventLogger.Instance.WriteLog(ex.ToString(), true);
            }
        }

        public static bool IsValidMail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}