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
    public class BaseRoleDAL
    {
        public static List<RoleDataModel> GetAll()
        {
            List<RoleDataModel> roles = new List<RoleDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetRoles", connection);
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                RoleDataModel role = new RoleDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    role.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    role.Name = Convert.ToString(item["Name"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    role.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    role.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }

                roles.Add(role);
            }

            return roles;
        }

        public static RoleDataModel Get(int id)
        {
            RoleDataModel role = null;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetRoleByID", connection);
            MySqlParameter paramID = new MySqlParameter("pId", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();

            adapter.Fill(results);

            if (results.Rows.Count > 0)
            {
                DataRow item = results.Rows[0];
                role = new RoleDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    role.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    role.Name = Convert.ToString(item["Name"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    role.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    role.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }
            }

            return role;
        }

        public static void Update(RoleDataModel role)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_UpdateRole", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", role.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", role.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", role.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", role.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }

        public static void Create(RoleDataModel role)
        {
            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_CreateRole", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", role.ID);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);
            MySqlParameter paramName = new MySqlParameter("pName", role.Name);
            paramName.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramName);
            MySqlParameter paramDateCreated = new MySqlParameter("pDateCreated", role.DateCreated);
            paramDateCreated.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramDateCreated);
            MySqlParameter paramCreatedBy = new MySqlParameter("pCreatedBy", role.CreatedBy);
            paramCreatedBy.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramCreatedBy);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }        

        public static List<RoleDataModel> GetBy(int id)
        {
            List<RoleDataModel> roles = new List<RoleDataModel>();

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetRolesBy", connection);

            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable results = new DataTable();

            adapter.Fill(results);

            foreach (DataRow item in results.Rows)
            {
                RoleDataModel role = new RoleDataModel();

                if (item["ID"].GetType() != typeof(DBNull))
                {
                    role.ID = Convert.ToInt32(item["ID"]);
                }
                if (item["Name"].GetType() != typeof(DBNull))
                {
                    role.Name = Convert.ToString(item["Name"]);
                }
                if (item["DateCreated"].GetType() != typeof(DBNull))
                {
                    role.DateCreated = Convert.ToDateTime(item["DateCreated"]);
                }
                if (item["CreatedBy"].GetType() != typeof(DBNull))
                {
                    role.CreatedBy = Convert.ToInt32(item["CreatedBy"]);
                }

                roles.Add(role);
            }

            return roles;
        }

        public static int GetCount(int id)
        {
            int count = 0;

            MySqlConnection connection = new MySqlConnection(ConfigurationManager.AppSettings[BusinessUtilies.Const.Database.AppSetting]);
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_GetRoleCount", connection);
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
            MySqlDataAdapter adapter = new MySqlDataAdapter("Core_DeleteRole", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;


            MySqlParameter paramID = new MySqlParameter("pID", id);
            paramID.Direction = ParameterDirection.Input;
            adapter.SelectCommand.Parameters.Add(paramID);

            DataTable results = new DataTable();
            adapter.Fill(results);
        }
    }
}
