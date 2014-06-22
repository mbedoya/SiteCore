using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebSite.Models
{
    public class FileUIModel
    {
        private string url;
        private FileType type;

        public enum FileType 
        {
            Image,
            File,
            None
        }
        
        public string URL {
            get 
            {
                return url;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    string regex = @"(.+png|.+jpg|.+bmp|.+jpeg)";
                    if (Regex.IsMatch(value, regex))
                    {
                        type = FileType.Image;
                    }
                    else
                    {
                        type = FileType.File;
                    }
                }
                else
                {
                    type = FileType.File;
                }
                
                url = value;
            }
        }

        public FileType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}