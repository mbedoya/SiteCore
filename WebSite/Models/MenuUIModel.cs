using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class MenuUIModel
    {
        public MenuDataModel Item { get; set; }
        public IList<MenuDataModel> Children { get; set; }
    }
}