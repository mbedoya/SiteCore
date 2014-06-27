using BusinessManager.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessManager.Data
{
    public class MenuDAL : BaseMenuDAL
    {
        public static List<MenuDataModel> GetParentMenus()
        {
            List<MenuDataModel> menus = new List<MenuDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("GetParentMenus", connection);
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

        public static List<MenuDataModel> GetMenuItems(string menuName)
        {
            List<MenuDataModel> menus = new List<MenuDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetMenuItems", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            MySqlParameter paramID = new MySqlParameter("pMenuName", menuName);
            paramID.Direction = ParameterDirection.Input;            
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
    }
}