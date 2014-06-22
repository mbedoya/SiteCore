using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BusinessManager.Models
{
    public class RoleDataModel
    {
        
	public int? ID  { get; set; }
	public string Name  { get; set; }
	public DateTime DateCreated  { get; set; }
	public int? CreatedBy  { get; set; }        
    }
}