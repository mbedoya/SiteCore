using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessManager.Models
{
    public class BaseDataModel
    {
        public int? ID { get; set; }

        public override bool Equals(object obj)
        {
            return (int)obj == ID;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
