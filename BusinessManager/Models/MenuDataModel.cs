using System;
using System.Collections.Generic;

namespace BusinessManager.Models
{
    public class MenuDataModel : BaseDataModel
    {   
        public string Name { get; set; }
        public string URL { get; set; }
        public int? MenuOrder { get; set; }
        public int? MenuID { get; set; }        
    }
    
}