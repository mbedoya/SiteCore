using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class ForeignKeyUIModel
    {
        public string Name { get; set; }
        public int? Value { get; set; }
        public bool ReadOnly { get; set; }
        public List<BaseUIModel> Collection { get; set; }
    }
}