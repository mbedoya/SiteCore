using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;

using MySql.Data.MySqlClient;

namespace BusinessManager.Data
{
    public class BaseMenuDAL
    {
        public static List<MenuDataModel> GetAll()
        {
            List<MenuDataModel> menus = new List<MenuDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetMenus", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                MenuDataModel menu = new MenuDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 menu.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 menu.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["URL"].GetType() != typeof(DBNull))
	 {
	 menu.URL = Convert.ToString(item["URL"]);
	 }
	 if (item["MenuOrder"].GetType() != typeof(DBNull))
	 {
	 menu.MenuOrder = Convert.ToInt32(item["MenuOrder"]);
	 }
	 if (item["MenuID"].GetType() != typeof(DBNull))
	 {
	 menu.MenuID = Convert.ToInt32(item["MenuID"]);
	 }

                menus.Add(menu);                 
            }            

            return menus;
        }

        public static MenuDataModel Get(int id)
        {
            MenuDataModel menu = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetMenuByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                menu = new MenuDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 menu.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 menu.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["URL"].GetType() != typeof(DBNull))
	 {
	 menu.URL = Convert.ToString(item["URL"]);
	 }
	 if (item["MenuOrder"].GetType() != typeof(DBNull))
	 {
	 menu.MenuOrder = Convert.ToInt32(item["MenuOrder"]);
	 }
	 if (item["MenuID"].GetType() != typeof(DBNull))
	 {
	 menu.MenuID = Convert.ToInt32(item["MenuID"]);
	 }                
            }

            return menu;
        }

        public static void Update(MenuDataModel menu)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateMenu", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",menu.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",menu.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramURL = new MySqlParameter("pURL",menu.URL);
	 paramURL.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramURL);
	 MySqlParameter paramMenuOrder = new MySqlParameter("pMenuOrder",menu.MenuOrder);
	 paramMenuOrder.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramMenuOrder);
	 MySqlParameter paramMenuID = new MySqlParameter("pMenuID",menu.MenuID);
	 paramMenuID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramMenuID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(MenuDataModel menu)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateMenu", connection);                        
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",menu.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramName = new MySqlParameter("pName",menu.Name);
	 paramName.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramName);
	 MySqlParameter paramURL = new MySqlParameter("pURL",menu.URL);
	 paramURL.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramURL);
	 MySqlParameter paramMenuOrder = new MySqlParameter("pMenuOrder",menu.MenuOrder);
	 paramMenuOrder.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramMenuOrder);
	 MySqlParameter paramMenuID = new MySqlParameter("pMenuID",menu.MenuID);
	 paramMenuID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramMenuID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static List<MenuDataModel> GetMenu(int id)
        {

            List<MenuDataModel> menus = new List<MenuDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetByMenuID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                MenuDataModel menu = new MenuDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 menu.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 menu.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["URL"].GetType() != typeof(DBNull))
	 {
	 menu.URL = Convert.ToString(item["URL"]);
	 }
	 if (item["MenuOrder"].GetType() != typeof(DBNull))
	 {
	 menu.MenuOrder = Convert.ToInt32(item["MenuOrder"]);
	 }
	 if (item["MenuID"].GetType() != typeof(DBNull))
	 {
	 menu.MenuID = Convert.ToInt32(item["MenuID"]);
	 }

                menus.Add(menu);                 
            }            

            return menus;
        }

        public static List<MenuDataModel> GetByMenu(int? id)
        {
            List<MenuDataModel> menus = new List<MenuDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetMenusByMenu", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;        
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                MenuDataModel menu = new MenuDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 menu.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["Name"].GetType() != typeof(DBNull))
	 {
	 menu.Name = Convert.ToString(item["Name"]);
	 }
	 if (item["URL"].GetType() != typeof(DBNull))
	 {
	 menu.URL = Convert.ToString(item["URL"]);
	 }
	 if (item["MenuOrder"].GetType() != typeof(DBNull))
	 {
	 menu.MenuOrder = Convert.ToInt32(item["MenuOrder"]);
	 }
	 if (item["MenuID"].GetType() != typeof(DBNull))
	 {
	 menu.MenuID = Convert.ToInt32(item["MenuID"]);
	 }

                menus.Add(menu);                 
            }            

            return menus;
        }

        public static int GetMenuCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetMenuMenuCount", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];                

                if (item["count"].GetType() != typeof(DBNull))
                {
                    count = Convert.ToInt32(item["count"]);
                }                
            }

            return count;       
        }

        public static void Delete(int id)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteMenu", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);            

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
