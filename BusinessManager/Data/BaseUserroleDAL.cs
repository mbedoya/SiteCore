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
    public class BaseUserroleDAL
    {
        public static List<UserroleDataModel> GetAll()
        {
            List<UserroleDataModel> userroles = new List<UserroleDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUserroles", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                UserroleDataModel userrole = new UserroleDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 userrole.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["UserID"].GetType() != typeof(DBNull))
	 {
	 userrole.UserID = Convert.ToInt32(item["UserID"]);
	 }
	 if (item["RoleID"].GetType() != typeof(DBNull))
	 {
	 userrole.RoleID = Convert.ToInt32(item["RoleID"]);
	 }

                userroles.Add(userrole);                 
            }            

            return userroles;
        }

        public static UserroleDataModel Get(int id)
        {
            UserroleDataModel userrole = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUserroleByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if(results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                userrole = new UserroleDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 userrole.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["UserID"].GetType() != typeof(DBNull))
	 {
	 userrole.UserID = Convert.ToInt32(item["UserID"]);
	 }
	 if (item["RoleID"].GetType() != typeof(DBNull))
	 {
	 userrole.RoleID = Convert.ToInt32(item["RoleID"]);
	 }                
            }

            return userrole;
        }

        public static void Update(UserroleDataModel userrole)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateUserrole", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",userrole.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramUserID = new MySqlParameter("pUserID",userrole.UserID);
	 paramUserID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramUserID);
	 MySqlParameter paramRoleID = new MySqlParameter("pRoleID",userrole.RoleID);
	 paramRoleID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramRoleID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(UserroleDataModel userrole)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateUserrole", connection);                        
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            
	 MySqlParameter paramID = new MySqlParameter("pID",userrole.ID);
	 paramID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramID);
	 MySqlParameter paramUserID = new MySqlParameter("pUserID",userrole.UserID);
	 paramUserID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramUserID);
	 MySqlParameter paramRoleID = new MySqlParameter("pRoleID",userrole.RoleID);
	 paramRoleID.Direction = ParameterDirection.Input;
	 adapter.SelectCommand.Parameters.Add(paramRoleID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static List<UserroleDataModel> GetRole(int id)
        {

            List<UserroleDataModel> userroles = new List<UserroleDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetByRoleID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                UserroleDataModel userrole = new UserroleDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 userrole.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["UserID"].GetType() != typeof(DBNull))
	 {
	 userrole.UserID = Convert.ToInt32(item["UserID"]);
	 }
	 if (item["RoleID"].GetType() != typeof(DBNull))
	 {
	 userrole.RoleID = Convert.ToInt32(item["RoleID"]);
	 }

                userroles.Add(userrole);                 
            }            

            return userroles;
        }

        public static List<UserroleDataModel> GetByRole(int id)
        {
            List<UserroleDataModel> userroles = new List<UserroleDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUserrolesByRole", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;        
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                UserroleDataModel userrole = new UserroleDataModel();                
                
	 if (item["ID"].GetType() != typeof(DBNull))
	 {
	 userrole.ID = Convert.ToInt32(item["ID"]);
	 }
	 if (item["UserID"].GetType() != typeof(DBNull))
	 {
	 userrole.UserID = Convert.ToInt32(item["UserID"]);
	 }
	 if (item["RoleID"].GetType() != typeof(DBNull))
	 {
	 userrole.RoleID = Convert.ToInt32(item["RoleID"]);
	 }

                userroles.Add(userrole);                 
            }            

            return userroles;
        }

        public static int GetCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetUserroleCount", connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteUserrole", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);            

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
