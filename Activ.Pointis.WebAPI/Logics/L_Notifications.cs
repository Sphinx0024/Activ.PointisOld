using Activ.Pointis.WebAPI.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Activ.Pointis.WebAPI.Utilities;

namespace Activ.Pointis.WebAPI.Logics
{
    public class L_Notifications
    {
        private byte _typeProcess;

        public L_Notifications(byte TypeProcess)
        {
            this._typeProcess = TypeProcess;
        }


        public string EnvoyerNotification(string mailAdresse, string objet, string message)
        {
            List<string> adresse = new List<string>();
            switch (this._typeProcess)
            {
                case (byte) Mapping.NotificationProcess.RetardEmployé:



                    Utilities.Mailling.EnvoyerMailAvecCopie(Mapping.MailConfig, message, objet, adresse, null);
                    string msg_inscription;
                    break;
            }


            return "";
        }
    }
}