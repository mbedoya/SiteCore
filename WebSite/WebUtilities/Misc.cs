using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
    }
}