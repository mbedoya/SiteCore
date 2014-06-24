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
        public static string GetAppSetting(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }

        public static string HTMLSubstring(string html, int length)
        {
            string regex = @"(<.+?>|&nbsp;|&ldquo;|&.+uo;)";
            return PreviewText(Regex.Replace(html, regex, "").Trim(), length);
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

            return Regex.Replace(textWithoutAccent, @"\b[&\s#@\.?]+", delegate(Match match)
            {
                string v = match.ToString();
                return "-";
            });
        }
    }
}