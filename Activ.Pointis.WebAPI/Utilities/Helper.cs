using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Activ.Pointis.WebAPI.Utilities
{
    public class Helper
    {

        public static string generateRandomString(int _size)
        {
            Random rand = new Random();
            int stringlen = rand.Next(4, _size);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {
                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            return str;

        }


        public static string GenerateSHA256Hash(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public static void EcrireErreurDansJournal(string Erreur)
        {
            if (!EventLog.SourceExists("Imperium"))
            {
                EventLog.CreateEventSource("Imperium", "ImperiumLog");
            }
            EventLog mylog = new EventLog();
            mylog.Source = "Imperium";
            mylog.WriteEntry(Erreur);
        }

        public static string GetUniqueReference()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            return builder.ToString();
        }



        public static DateTime ConvertStringToDate(string Date)
        {
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);
            return DateTime.Parse(Date, culture, System.Globalization.DateTimeStyles.AssumeLocal);
        }

        public static string TraiteListeString(string strAtraiter, string[] separateur)
        {
            string str = "";
            try
            {
                if (strAtraiter.Trim() != "")
                {
                    var T = TraiteStringToListe(strAtraiter, separateur);   //strAtraiter.Split(separateur, StringSplitOptions.RemoveEmptyEntries);
                    if (T != null)
                    {
                        if (T.Length > 0)
                        {
                            foreach (string s in T)
                            {
                                if (s.Trim() != "")
                                {
                                    str += s + "#;";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                str = ex.ToString();
            }
            return str;
        }

        public static string[] TraiteStringToListe(string strAtraiter, string[] separateur)
        {
            try
            {
                if (strAtraiter.Trim() != "")
                {
                    return strAtraiter.Replace(" ", "").Split(separateur, StringSplitOptions.RemoveEmptyEntries);
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static bool IsDictionary(object o)
        {
            try
            {
                if (o == null) return false;
                return o is System.Collections.IDictionary &&
                       o.GetType().IsGenericType &&
                       o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
            }
            catch
            {
                return false;
            }
        }

        public static bool IsList(object o)
        {
            try
            {
                if (o == null) return false;
                return o is System.Collections.IList &&
                       o.GetType().IsGenericType &&
                       o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
            }
            catch
            {
                return false;
            }
        }


    }
}