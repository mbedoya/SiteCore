using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebSite.WebUtilities
{
    public class Misc
    {

        public static string GetDateDifferenceInMiliseconds(DateTime startDate, DateTime endDate)
        {
            TimeSpan t = endDate - startDate;
            return  t.Hours.ToString() + ":" + t.Minutes.ToString() + ":" + t.Seconds.ToString() + "." + t.Milliseconds.ToString();
        }

        public static string GetFormattedDate(DateTime date)
        {
            string dateString = "";
            string dateFormat = GetAppSetting("DateFormat");

            if (!String.IsNullOrEmpty(dateFormat))
            {
                dateString = date.ToString(dateFormat).Replace(".", "");
            }
            else
            {
                dateString = date.ToString("dd MMM, yyyy").Replace(".", "");
            }

            return dateString;
        }

        public static string GetAppSetting(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }

        public static string HTMLSubstring(string html, int length)
        {
            string regex = @"(<.+?>|&ldquo;|&.+uo;)";
            string noHtmlText = Regex.Replace(html, regex, " ").Trim();
            //Replace whitespace
            noHtmlText = noHtmlText.Replace("&nbsp;", " ");

            return PreviewText(noHtmlText, length);
        }

        public static string PreviewText(string text, int length)
        {
            if (length > text.Length)
            {
                return text;
            }
            else
            {
                string maxText = text.Substring(0, length);
                maxText = maxText.Substring(0, maxText.LastIndexOf(" ")) + " ...";

                return maxText;
            }
        }

        public static string RemoveDiacritics(string input)
        {
            string stFormD = input.Normalize(NormalizationForm.FormD);
            int len = stFormD.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[i]);
                }
            }
            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }

        public static string GetURLString(string text)
        {
            string textWithoutAccent = RemoveDiacritics(text);

            return Regex.Replace(textWithoutAccent, @"\b[&\s#@\.\,?]+", delegate(Match match)
            {
                string v = match.ToString();
                return "-";
            });
        }
    }
}